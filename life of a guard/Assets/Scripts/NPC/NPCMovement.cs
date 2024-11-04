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
        // Определяем, к какой точке движемся
        Vector2 targetPosition = movingToPointB ? pointB.position : pointA.position;

        // Двигаем NPC к цели
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Если достигли точки назначения
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(WaitBeforeNextMove());
            animator.SetBool("isWalking", false); // Устанавливаем Idle анимацию
        }
        else
        {
            // Устанавливаем анимацию в зависимости от направления
            animator.SetBool("isWalking", true); // Устанавливаем анимацию ходьбы

            if (movingToPointB)
            {
                animator.SetTrigger("WalkRight"); // Анимация ходьбы вправо
            }
            else
            {
                animator.SetTrigger("WalkLeft"); // Анимация ходьбы влево
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