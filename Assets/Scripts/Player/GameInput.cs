using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZFramework;
public class GameInput : SingletonMono<GameInput>
{
    PlayerInputAction playerInputActions;
    private void Awake()
    {
        base.Awake();
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();
        //当指定的按键被按下时触发
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log(obj);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        //Vector2 inputVector = Vector2.zero;
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
