using System.Collections;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform pointA; // ����� �������
    public Transform pointB; // ������ �������
    public float speed = 2f; // �������� ��������
    public float waitTime = 2f; // ����� �������� �� �����

    private bool movingToPointB = true; // ����������� �������� (� B ��� � A)
    private bool isWaiting = false;
    private Animator animator; // ������ �� ��������� Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // �������� ��������� Animator
    }

    private void Update()
    {
        if (!isWaiting)
        {
            MoveNPC();
        }
        else
        {
            animator.SetBool("isWalking", false); // ������������� Idle ��������
        }
    }

    private void MoveNPC()
    {
        // ����������, � ����� ����� ��������
        Vector2 targetPosition = movingToPointB ? pointB.position : pointA.position;

        // ������� NPC � ����
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ���� �������� ����� ����������
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(WaitBeforeNextMove());
            animator.SetBool("isWalking", false); // ������������� Idle ��������
        }
        else
        {
            // ������������� �������� � ����������� �� �����������
            animator.SetBool("isWalking", true); // ������������� �������� ������

            if (movingToPointB)
            {
                animator.SetTrigger("WalkRight"); // �������� ������ ������
            }
            else
            {
                animator.SetTrigger("WalkLeft"); // �������� ������ �����
            }
        }
    }

    private IEnumerator WaitBeforeNextMove()
    {
        isWaiting = true;

        // ���� ��������� �����
        yield return new WaitForSeconds(waitTime);

        // ������ ����������� ��������
        movingToPointB = !movingToPointB;

        isWaiting = false;
    }
}