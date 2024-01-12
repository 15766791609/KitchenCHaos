using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ZFramework;
public class Player : SingletonMono<Player>
{
    public float speed;
    public float rotateSpeed;
    private bool isWarking;
    void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * speed * Time.deltaTime;
        isWarking = moveDir != Vector3.zero;
        transform.forward = Vector3.Lerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    public bool IsWarking()
    {
        return isWarking;
    }
}
