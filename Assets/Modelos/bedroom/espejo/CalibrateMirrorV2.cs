using UnityEngine;

// Este atributo te permite ejecutar el script en el modo editor
[ExecuteInEditMode]
public class CalibrateMirrorV2 : MonoBehaviour
{
    [Header("Objetos de la Escena")]
    // La c�mara principal de la habitaci�n (la que est� fija)
    public Camera RoomCamera;

    // La c�mara que usaremos para el reflejo
    public Camera MirrorCamera;

    // El objeto que act�a como espejo
    public Transform MirrorPlane;

    void Start()
    {
        // Si estamos en modo Play, calcula la posici�n al empezar
        if (Application.isPlaying)
        {
            PositionAndRotateMirrorCamera();
        }
    }

    // Este atributo crea un bot�n en el men� contextual del componente en el Inspector.
    // �Es s�per �til para ejecutar la funci�n sin darle a Play!
    [ContextMenu("Actualizar Posici�n y Rotaci�n del Espejo")]
    void PositionAndRotateMirrorCamera()
    {
        if (RoomCamera == null || MirrorCamera == null || MirrorPlane == null)
        {
            Debug.LogError("Por favor, asigna la RoomCamera, MirrorCamera y el MirrorPlane en el Inspector.");
            return;
        }

        // --- 1. CALCULAR LA POSICI�N REFLEJADA ---

        // Vector desde el centro del espejo hasta la c�mara de la habitaci�n
        Vector3 vectorToCamera = RoomCamera.transform.position - MirrorPlane.position;

        // La normal del espejo (la direcci�n hacia la que "mira" su superficie)
        // Asumimos que el eje Z (azul) del objeto espejo apunta hacia la habitaci�n
        Vector3 mirrorNormal = MirrorPlane.forward;

        // Proyectamos el vector sobre la normal y lo restamos dos veces.
        // Esto "refleja" la posici�n de la c�mara al otro lado del plano.
        MirrorCamera.transform.position = RoomCamera.transform.position - 2 * mirrorNormal * Vector3.Dot(vectorToCamera, mirrorNormal);


        // --- 2. CALCULAR LA ROTACI�N REFLEJADA ---

        // Reflejamos la direcci�n de visi�n de la c�mara de la habitaci�n
        Vector3 reflectedLookDirection = Vector3.Reflect(RoomCamera.transform.forward, mirrorNormal);

        // Reflejamos tambi�n el vector "arriba" para que la c�mara no se voltee
        Vector3 reflectedUpDirection = Vector3.Reflect(RoomCamera.transform.up, mirrorNormal);

        // Apuntamos la c�mara del espejo usando las nuevas direcciones reflejadas
        MirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedLookDirection, reflectedUpDirection);

        Debug.Log("�C�mara del espejo actualizada!");
    }
}