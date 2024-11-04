using UnityEngine;
using System.Collections;
public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // ������ ������
    public Camera camera2; // ������ ������
    public Transform targetPosition; // ������� ������� ��� ����������� ������
    public float transitionTime = 1.0f; // ����� ��������

    private void Start()
    {
        // ���������, ��� � ������ ������� ������ ������ ������
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ��������, ����� ����� ������ �������
        if (Input.GetKeyDown(KeyCode.Space)) // �������� �� ���� �������
        {
            StartCoroutine(SwitchCamera());
        }
    }

    private IEnumerator SwitchCamera()
    {
        // ����������� ������1 � targetPosition
        float elapsedTime = 0f;
        Vector3 startingPosition = camera1.transform.position;

        while (elapsedTime < transitionTime)
        {
            camera1.transform.position = Vector3.Lerp(startingPosition, targetPosition.position, (elapsedTime / transitionTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���������� ������ ������ � ��������� ������
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
    }
}
