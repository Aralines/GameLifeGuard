using System;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float enemySpeed = 2f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        Vector3 direction = target.transform.position - transform.position;
        if (target.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        transform.position += direction * enemySpeed * Time.deltaTime;
    }
}
