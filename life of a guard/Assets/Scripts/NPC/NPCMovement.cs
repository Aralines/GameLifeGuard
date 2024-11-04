using System.Collections;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform pointA; // Левая граница
    public Transform pointB; // Правая граница
    public float speed = 2f; // Скорость движения
    public float waitTime = 2f; // Время ожидания на точке

    private bool movingToPointB = true; // Направление движения (к B или к A)
    private bool isWaiting = false;
    private Animator animator; // Ссылка на компонент Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // Получаем компонент Animator
    }

    private void Update()
    {
        if (!isWaiting)
        {
            MoveNPC();
        }
        else
        {
            animator.SetBool("isWalking", false); // Устанавливаем Idle анимацию
        }
    }

    private void MoveNPC()
    {
        Vector2 targetPosition = movingToPointB ? pointB.position : pointA.position;

        Debug.Log($"Moving to: {targetPosition}");

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f) // Увеличиваем значение
        {
            Debug.Log("Reached target");
            StartCoroutine(WaitBeforeNextMove());
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if (movingToPointB)
            {
                animator.SetTrigger("WalkRight");
            }
            else
            {
                animator.SetTrigger("WalkLeft");
            }
        }
    }

    private IEnumerator WaitBeforeNextMove()
    {
        isWaiting = true;

        // Ждем указанное время
        yield return new WaitForSeconds(waitTime);

        // Меняем направление движения
        movingToPointB = !movingToPointB;

        isWaiting = false;
    }
}