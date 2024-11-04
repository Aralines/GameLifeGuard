using System;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] float damage = 0.2f;
    [SerializeField] float range = 1f;
    private float _currentRenge;
    private PlayerInfo _player;
    private Move _move;
    private short targets = 0;
    
    private const string PLAYERTAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYERTAG))
        {
            targets++;
            _currentRenge = range;
            _move = collision.GetComponent<Move>();
            _player = collision.GetComponent<PlayerInfo>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYERTAG))
        {
            targets--;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_currentRenge <= 0 && 
            targets > 0 &&
            other.CompareTag(PLAYERTAG))
        {
            _player.TakeDamage(damage);
            _currentRenge = range;
            //_move.moveSpeed /= 2;
        }
    }

    private void FixedUpdate()
    {
        if(_currentRenge > 0 && 
           targets > 0)
            _currentRenge -= Time.deltaTime;
    }
}
