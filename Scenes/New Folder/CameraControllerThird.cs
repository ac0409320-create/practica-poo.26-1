using UnityEngine;

public class CameraControllerThird : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform target; // El objeto que la cámara seguirá (por ejemplo, el jugador)

    [Header("Ajustes de seguimiento")]
    public float distance = 5f;  // Distancia detrás del objetivo
    public float height = 2f;    // Altura sobre el objetivo
    public float rotationSpeed = 5f; // Velocidad de rotación con el mouse
    public float followSmoothness = 10f; // Suavizado del movimiento

    [Header("Límites verticales de la cámara")]
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float currentYaw = 0f;
    private float currentPitch = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Movimiento del mouse para rotar la cámara
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Acumular rotaciones
        currentYaw += mouseX;
        currentPitch -= mouseY;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // Crear la rotación basada en el pitch y yaw
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        // Calcular la posición deseada detrás del target
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = target.position + Vector3.up * height + offset;

        // Movimiento suave hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSmoothness);

        // Mantener la cámara mirando hacia el target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
//camara