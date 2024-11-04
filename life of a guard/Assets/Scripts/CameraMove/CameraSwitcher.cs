using UnityEngine;
using System.Collections;
public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // Первая камера
    public Camera camera2; // Вторая камера
    public Transform targetPosition; // Целевая позиция для перемещения камеры
    public float transitionTime = 1.0f; // Время перехода

    private void Start()
    {
        // Убедитесь, что в начале активна только первая камера
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Проверка, когда нужно начать переход
        if (Input.GetKeyDown(KeyCode.Space)) // Замените на ваше условие
        {
            StartCoroutine(SwitchCamera());
        }
    }

    private IEnumerator SwitchCamera()
    {
        // Перемещение камеры1 к targetPosition
        float elapsedTime = 0f;
        Vector3 startingPosition = camera1.transform.position;

        while (elapsedTime < transitionTime)
        {
            camera1.transform.position = Vector3.Lerp(startingPosition, targetPosition.position, (elapsedTime / transitionTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Отключение первой камеры и включение второй
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
    }
}
