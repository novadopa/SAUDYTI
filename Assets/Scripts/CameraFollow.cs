using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Перетащи сюда объект игрока
    public float smoothSpeed = 5f; // Скорость плавности
    public Vector3 offset = new Vector3(0, 2, -10); // Смещение камеры

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
