using System;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float enemySpeed = 2f;

    private void FixedUpdate()
    {
        moveEnemy();
        
    }

    private void moveEnemy()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.position += direction * enemySpeed * Time.deltaTime;
    }
}
