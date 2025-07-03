using UnityEngine;
using System.Collections;

public class LightFlickerController : MonoBehaviour
{
    [Tooltip("La luz que será controlada por este script.")]
    public Light lightToFlicker;

    [Header("Tiempos de Parpadeo (en segundos)")]
    [Tooltip("El tiempo mínimo que la luz permanecerá ENCENDIDA durante un parpadeo.")]
    [SerializeField] private float minOnTime = 0.05f;

    [Tooltip("El tiempo máximo que la luz permanecerá ENCENDIDA durante un parpadeo.")]
    [SerializeField] private float maxOnTime = 0.15f;

    [Tooltip("El tiempo mínimo que la luz permanecerá APAGADA entre parpadeos.")]
    [SerializeField] private float minOffTime = 0.1f;

    [Tooltip("El tiempo máximo que la luz permanecerá APAGADA entre parpadeos.")]
    [SerializeField] private float maxOffTime = 0.4f;

    private Coroutine flickerCoroutine;

    void OnEnable()
    {
        Debug.Log("Se activa el GameObject y se inicia el parpadeo");
        if (lightToFlicker == null)
        {
            Debug.LogError("ERROR: No se ha asignado una luz al script 'LightFlickerController' en el GameObject: " + this.name);
            this.enabled = false;
            return;
        }
        flickerCoroutine = StartCoroutine(FlickerCoroutine());
    }

    void OnDisable()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
            flickerCoroutine = null;
        }
        // Al desactivar el GameObject, la luz queda encendida
        if (lightToFlicker != null)
        {
            lightToFlicker.enabled = true;
        }
    }
    
    private IEnumerator FlickerCoroutine()
    {
        while (true)
        {
            lightToFlicker.enabled = true;
            float onDuration = Random.Range(minOnTime, maxOnTime);
            Debug.Log("Entró a loop y espera " + onDuration);
            yield return new WaitForSeconds(onDuration);

            lightToFlicker.enabled = false;
            Debug.Log("Se apaga");

            float offDuration = Random.Range(minOffTime, maxOffTime);
            yield return new WaitForSeconds(offDuration);
        }
    }
}