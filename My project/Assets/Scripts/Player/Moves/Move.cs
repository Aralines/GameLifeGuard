using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Move : MonoBehaviour
{
    public bool PlayerOnGround;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck; // Обьект который проверяет наступил ли игрок на землю
    [SerializeField] private gameInput input; // С этого класса получаем информацию о вводе данных
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float jumpForce = 300.0f; // Сила прыжка
    [SerializeField] private float checkRadius = 4.0f; // Расстояние от земли с которо можно прыгать
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerOnTheGround();
        movePlayer();
        jump();
    }


    private void movePlayer()
    {
        Vector2 moveVector = input.GetMoventVector2();
        _rb.linearVelocity = new Vector2(moveVector.x * moveSpeed, _rb.linearVelocity.y);
    }

    private void jump()
    {
        if (input.PlayerJump() &&
            PlayerOnGround)
        {
            _rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void playerOnTheGround()
    {
        PlayerOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
    
}