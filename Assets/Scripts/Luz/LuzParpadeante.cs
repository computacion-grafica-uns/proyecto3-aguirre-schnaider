using UnityEngine;
using System.Collections; // Necesario para usar Corrutinas

public class LightFlickerController : MonoBehaviour
{
    // Arrastra aquí la luz que quieres que parpadee desde el editor de Unity.
    [Tooltip("La luz que será controlada por este script.")]
    public Light lightToFlicker;

    // --- PARÁMETROS PARA PERSONALIZAR EL PARPADEO ---

    [Header("Tiempos de Parpadeo (en segundos)")]
    [Tooltip("El tiempo mínimo que la luz permanecerá ENCENDIDA durante un parpadeo.")]
    [SerializeField] private float minOnTime = 0.05f;

    [Tooltip("El tiempo máximo que la luz permanecerá ENCENDIDA durante un parpadeo.")]
    [SerializeField] private float maxOnTime = 0.15f;

    [Tooltip("El tiempo mínimo que la luz permanecerá APAGADA entre parpadeos.")]
    [SerializeField] private float minOffTime = 0.1f;

    [Tooltip("El tiempo máximo que la luz permanecerá APAGADA entre parpadeos.")]
    [SerializeField] private float maxOffTime = 0.4f;


    void Start()
    {
        // Verificación para evitar errores si se nos olvida asignar la luz.
        if (lightToFlicker == null)
        {
            Debug.LogError("ERROR: No se ha asignado una luz al script 'LightFlickerController' en el GameObject: " + this.name);
            // Desactivamos este componente para que no siga dando errores.
            this.enabled = false;
            return;
        }

        // Iniciamos la corrutina que se encargará del parpadeo de forma infinita.
        StartCoroutine(FlickerCoroutine());
    }

    /// <summary>
    /// Corrutina que gestiona el ciclo de encendido y apagado de la luz.
    /// </summary>
    private IEnumerator FlickerCoroutine()
    {
        // Bucle infinito que se ejecutará mientras el objeto esté activo.
        while (true)
        {
            // 1. Encender la luz
            lightToFlicker.enabled = true;

            // 2. Esperar un tiempo aleatorio corto mientras está encendida
            float onDuration = Random.Range(minOnTime, maxOnTime);
            yield return new WaitForSeconds(onDuration);

            // 3. Apagar la luz
            lightToFlicker.enabled = false;

            // 4. Esperar un tiempo aleatorio antes del siguiente parpadeo
            float offDuration = Random.Range(minOffTime, maxOffTime);
            yield return new WaitForSeconds(offDuration);
        }
    }
}