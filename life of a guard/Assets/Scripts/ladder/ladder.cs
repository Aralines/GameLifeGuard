using System;
using UnityEngine;

public class ladder : MonoBehaviour
{
    [SerializeField] private gameInput input;
    private Rigidbody2D _rb;
    [SerializeField, Range(0f, 10f)] private float speed = 0.1f;
    
    private float _baseGravityScale;
        
    private const string PLAYERTAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            _rb = other.GetComponent<Rigidbody2D>();
            _baseGravityScale = _rb.gravityScale;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            _rb.gravityScale = 0f;
            UpAndDown(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            _rb.gravityScale = _baseGravityScale;
        }
    }

    private void UpAndDown(Collider2D other)
    {
        float direction = 0f;
        if (input.PlayerUp())
            direction = 1f;
        else if (input.PlayerDown())
            direction = -1f;
        other.transform.position += Vector3.up * direction * speed;
    }
}
