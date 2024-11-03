using System;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private gameInput input;
    private const string PLAYERTAG = "Player";

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG) &&
            input.PlayerActivate())
        {
            other.transform.position = newPosition.position;
        }
    }
}
