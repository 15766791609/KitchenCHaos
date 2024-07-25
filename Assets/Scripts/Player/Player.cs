using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ZFramework;
using System;

public class Player : SingletonMono<Player>,IKitchenObjectParent
{
    public event EventHandler<OnSelectedConterChangerEventArgs> OnSelectedCounterChanged;
    public class OnSelectedConterChangerEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }


    public float moveSpeed;
    public float rotateSpeed;
    public float playerRadius = 2.7f;
    public float playerHeight = 2.7f;
    [SerializeField] private Transform kitchenObjectHoldPoint;
     

    public LayerMask countLayeMask;
    private bool isWarking;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;


    private KitchenObject kitchenObject;


    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        GameInput.Instance.OnInteractAction += OnInteractAction;
        GameInput.Instance.OnInteractAlternateAction += OnInteractAlternateAction;
    }

    private void OnInteractAlternateAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternaten(this);
        }
    }

    private void OnInteractAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInterctions();
    }

    public bool IsWarking()
    {
        return isWarking;
    }

    private void HandleInterctions()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
            lastInteractDir = moveDir;

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycast, interactDistance, countLayeMask))
        {
            //检查是否携带某个控件
            if (raycast.transform.TryGetComponent(out BaseCounter caseCounter))
            {
                //clearCounter.Interact();
                if (caseCounter != selectedCounter)
                {
                    SetSelectedConter(caseCounter);
                }
            }
            else
                SetSelectedConter(null);
        }
        else
            SetSelectedConter(null);
    }
    private void HandleMovement()
    {

        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);



        float moveDistance = moveSpeed * Time.deltaTime;
        //球形碰撞射线或者胶囊体碰撞射线(位置（低点），位置（高点）,半径，方向，移动距离)
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position
            + Vector3.up * playerRadius, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            //尝试单个轴向是否可以移动
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x !=0 && !Physics.CapsuleCast(transform.position, transform.position
           + Vector3.up * playerRadius, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                //尝试单个轴向是否可以移动
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position
               + Vector3.up * playerRadius, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        isWarking = moveDir != Vector3.zero;


        transform.forward = Vector3.Lerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);

    }
    /// <summary>
    /// 设定当前选中的柜子
    /// </summary>
    private void SetSelectedConter(BaseCounter baseCounter)
    {
        this.selectedCounter = baseCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedConterChangerEventArgs
        {
            selectedCounter = baseCounter
        });
    }



    public Transform GetKitchenObjectFollowTransrom()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObjetc()
    {
        return (kitchenObject != null);
    }
}
