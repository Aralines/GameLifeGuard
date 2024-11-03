using System;
using Unity.Cinemachine;
using UnityEngine;

public class observes : MonoBehaviour
{
    [SerializeField] private gameInput input;
    [SerializeField] private Transform viewPoint;
    [SerializeField] private CinemachineCamera camera;
    [SerializeField] private float newSize = 10f;
    private float baseSize;
    private Transform _playerTransform;
    
    private const string PLAYERTAG = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            baseSize = camera.Lens.OrthographicSize;
            camera.Lens.OrthographicSize = newSize;
            _playerTransform = other.transform;
            camera.Follow = viewPoint;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PLAYERTAG))
        {
            camera.Follow = _playerTransform;
            camera.Lens.OrthographicSize = baseSize;
        }
    }
}
