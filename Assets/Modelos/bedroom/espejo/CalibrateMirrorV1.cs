using UnityEngine;

public class CalibrateMirrorV1 : MonoBehaviour
{
    // Asigna tu cámara principal (la del jugador/habitación) aquí
    public Camera RoomCamera;

    // Asigna la cámara que usas para el reflejo aquí
    public Camera MirrorCamera;

    // El plano de reflexión es el plano XY, con su normal apuntando en Z+
    private Vector3 mirrorNormal = Vector3.forward;

    // Usamos LateUpdate para asegurarnos de que se ejecuta después de que la cámara principal se haya movido
    void Start()
    {
        if (RoomCamera == null || MirrorCamera == null)
        {
            Debug.LogWarning("Asigna ambas cámaras en el Inspector.");
            return;
        }

        // 1. Calcular el vector distancia desde la RoomCamera hasta la MirrorCamera, como pediste.
        Vector3 distanceVector = MirrorCamera.transform.position - RoomCamera.transform.position;

        // 2. Reflejar ese vector usando la normal del plano (Z+).
        Vector3 reflectedDirection = Vector3.Reflect(distanceVector, mirrorNormal);

        // 3. Asignar esta nueva dirección como el "forward" de la MirrorCamera.
        // También reflejamos el vector "up" para mantener la orientación correcta.
        Vector3 reflectedUp = Vector3.Reflect(RoomCamera.transform.up, mirrorNormal);
        MirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedDirection, reflectedUp);
    }
}