using UnityEngine;

// Este atributo te permite ejecutar el script en el modo editor
[ExecuteInEditMode]
public class CalibrateMirrorV2 : MonoBehaviour
{
    [Header("Objetos de la Escena")]
    // La cámara principal de la habitación (la que está fija)
    public Camera RoomCamera;

    // La cámara que usaremos para el reflejo
    public Camera MirrorCamera;

    // El objeto que actúa como espejo
    public Transform MirrorPlane;

    void Start()
    {
        // Si estamos en modo Play, calcula la posición al empezar
        if (Application.isPlaying)
        {
            PositionAndRotateMirrorCamera();
        }
    }

    // Este atributo crea un botón en el menú contextual del componente en el Inspector.
    // ¡Es súper útil para ejecutar la función sin darle a Play!
    [ContextMenu("Actualizar Posición y Rotación del Espejo")]
    void PositionAndRotateMirrorCamera()
    {
        if (RoomCamera == null || MirrorCamera == null || MirrorPlane == null)
        {
            Debug.LogError("Por favor, asigna la RoomCamera, MirrorCamera y el MirrorPlane en el Inspector.");
            return;
        }

        // --- 1. CALCULAR LA POSICIÓN REFLEJADA ---

        // Vector desde el centro del espejo hasta la cámara de la habitación
        Vector3 vectorToCamera = RoomCamera.transform.position - MirrorPlane.position;

        // La normal del espejo (la dirección hacia la que "mira" su superficie)
        // Asumimos que el eje Z (azul) del objeto espejo apunta hacia la habitación
        Vector3 mirrorNormal = MirrorPlane.forward;

        // Proyectamos el vector sobre la normal y lo restamos dos veces.
        // Esto "refleja" la posición de la cámara al otro lado del plano.
        MirrorCamera.transform.position = RoomCamera.transform.position - 2 * mirrorNormal * Vector3.Dot(vectorToCamera, mirrorNormal);


        // --- 2. CALCULAR LA ROTACIÓN REFLEJADA ---

        // Reflejamos la dirección de visión de la cámara de la habitación
        Vector3 reflectedLookDirection = Vector3.Reflect(RoomCamera.transform.forward, mirrorNormal);

        // Reflejamos también el vector "arriba" para que la cámara no se voltee
        Vector3 reflectedUpDirection = Vector3.Reflect(RoomCamera.transform.up, mirrorNormal);

        // Apuntamos la cámara del espejo usando las nuevas direcciones reflejadas
        MirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedLookDirection, reflectedUpDirection);

        Debug.Log("¡Cámara del espejo actualizada!");
    }
}