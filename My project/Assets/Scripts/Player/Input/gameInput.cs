using System;
using UnityEngine;

public class gameInput : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    
    // Считывает движения "влево в право"
    public Vector2 GetMoventVector2()
    {
        Vector2 moveVector = _playerInput.Player.Move.ReadValue<Vector2>();
        return moveVector;
    }

    public bool PlayerUp()
    {
        return Input.GetKey(KeyCode.W);
    }
    
    public bool PlayerDown()
    {
        return Input.GetKey(KeyCode.S);
    }

    public bool PlayerActivate()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    public bool PlayerJump()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
