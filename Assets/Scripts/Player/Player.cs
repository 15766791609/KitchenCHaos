using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ZFramework;
public class Player : SingletonMono<Player>
{
    public float moveSpeed;
    public float rotateSpeed;
    public float playerRadius = 2.7f;
    public float playerHeight = 2.7f;
    public LayerMask countLayeMask;
    private bool isWarking;
    private Vector3 lastInteractDir;
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
            //����Ƿ�Я��ĳ���ؼ�
            if (raycast.transform.TryGetComponent<ClearCounter>(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }

        }

    }
    private void HandleMovement()
    {

        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        //������ײ���߻��߽�������ײ����(λ�ã��͵㣩��λ�ã��ߵ㣩,�뾶�������ƶ�����)
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position
            + Vector3.up * playerRadius, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            //���Ե��������Ƿ�����ƶ�
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position
           + Vector3.up * playerRadius, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                //���Ե��������Ƿ�����ƶ�
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position
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
}