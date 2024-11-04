using System;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] PlayerInfo player;
    [SerializeField] float damage = 0.2f;
    [SerializeField] float range = 1f;
    private float _currentRenge;
    private short targets = 0;
    
    private const string PLAYERTAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYERTAG))
        {
            targets++;
            _currentRenge = range;   
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
            player.TakeDamage(damage);
            _currentRenge = range;
        }
    }

    private void FixedUpdate()
    {
        if(_currentRenge > 0 && 
           targets > 0)
            _currentRenge -= Time.deltaTime;
    }
}
