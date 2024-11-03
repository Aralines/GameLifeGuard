using System;
using Unity.Cinemachine;
using UnityEngine;

public class observes : MonoBehaviour
{
    [SerializeField] private gameInput input;
    [SerializeField] private Transform viewPoint;
    [SerializeField] private CinemachineCamera camera;
    private Transform _playerTransform;
    
    private const string PLAYERTAG = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        _playerTransform = other.transform;
        camera.Follow = viewPoint;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            camera.Follow = _playerTransform;
        }
    }
}
