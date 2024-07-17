using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZFramework;
using System;
public class GameInput : SingletonMono<GameInput>
{
    public event EventHandler OnInteractAction;
    PlayerInputAction playerInputActions;
    private void Awake()
    {

        base.Awake();
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();
        //��ָ���İ���������ʱ����
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        //Vector2 inputVector = Vector2.zero;
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
