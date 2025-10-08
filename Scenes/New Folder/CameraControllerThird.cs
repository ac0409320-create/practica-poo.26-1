using UnityEngine;

public class CameraControllerThird : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform target; // El objeto que la c�mara seguir� (por ejemplo, el jugador)

    [Header("Ajustes de seguimiento")]
    public float distance = 5f;  // Distancia detr�s del objetivo
    public float height = 2f;    // Altura sobre el objetivo
    public float rotationSpeed = 5f; // Velocidad de rotaci�n con el mouse
    public float followSmoothness = 10f; // Suavizado del movimiento

    [Header("L�mites verticales de la c�mara")]
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float currentYaw = 0f;
    private float currentPitch = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Movimiento del mouse para rotar la c�mara
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Acumular rotaciones
        currentYaw += mouseX;
        currentPitch -= mouseY;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // Crear la rotaci�n basada en el pitch y yaw
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        // Calcular la posici�n deseada detr�s del target
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = target.position + Vector3.up * height + offset;

        // Movimiento suave hacia la posici�n deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSmoothness);

        // Mantener la c�mara mirando hacia el target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
//camara