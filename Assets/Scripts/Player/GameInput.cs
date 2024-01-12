using System.Collections;
using System.Collections.Generic;
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
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        //Vector2 inputVector = Vector2.zero;
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
