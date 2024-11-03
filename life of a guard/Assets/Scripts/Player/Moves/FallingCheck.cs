using System;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    [SerializeField] private PlayerInfo player;
    [SerializeField] private float fallsWithoutDamage = 2f;
    private float _timeOfFall = 0f;
    private short _stayOn = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        _stayOn++;
        if (_timeOfFall > fallsWithoutDamage)
        {
            player.TakeDamage((float)Math.Pow(_timeOfFall, 3f));        
        }
        _timeOfFall = 0f;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _stayOn--;
    }

    private void FixedUpdate()
    {
        if (_stayOn <= 0)
        {
            _timeOfFall += Time.deltaTime;
        }
    }
}
