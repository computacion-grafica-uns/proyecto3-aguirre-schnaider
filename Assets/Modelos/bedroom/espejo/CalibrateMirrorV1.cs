using UnityEngine;

public class CalibrateMirrorV1 : MonoBehaviour
{
    // Asigna tu c�mara principal (la del jugador/habitaci�n) aqu�
    public Camera RoomCamera;

    // Asigna la c�mara que usas para el reflejo aqu�
    public Camera MirrorCamera;

    // El plano de reflexi�n es el plano XY, con su normal apuntando en Z+
    private Vector3 mirrorNormal = Vector3.forward;

    // Usamos LateUpdate para asegurarnos de que se ejecuta despu�s de que la c�mara principal se haya movido
    void Start()
    {
        if (RoomCamera == null || MirrorCamera == null)
        {
            Debug.LogWarning("Asigna ambas c�maras en el Inspector.");
            return;
        }

        // 1. Calcular el vector distancia desde la RoomCamera hasta la MirrorCamera, como pediste.
        Vector3 distanceVector = MirrorCamera.transform.position - RoomCamera.transform.position;

        // 2. Reflejar ese vector usando la normal del plano (Z+).
        Vector3 reflectedDirection = Vector3.Reflect(distanceVector, mirrorNormal);

        // 3. Asignar esta nueva direcci�n como el "forward" de la MirrorCamera.
        // Tambi�n reflejamos el vector "up" para mantener la orientaci�n correcta.
        Vector3 reflectedUp = Vector3.Reflect(RoomCamera.transform.up, mirrorNormal);
        MirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedDirection, reflectedUp);
    }
}