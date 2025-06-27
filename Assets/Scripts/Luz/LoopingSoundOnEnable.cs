using UnityEngine;

// Aseguramos que el GameObject tenga un AudioSource.
[RequireComponent(typeof(AudioSource))]
public class LoopingSoundOnEnable : MonoBehaviour
{
    // NO NECESITAMOS un AudioClip aquí, lo configuraremos directamente en el AudioSource.

    private AudioSource audioSource;

    void Awake()
    {
        // Obtenemos la referencia al componente AudioSource.
        audioSource = GetComponent<AudioSource>();

        // Forzamos configuraciones importantes en el AudioSource para que funcione correctamente.
        // Esto evita errores de configuración en el Inspector.
        ConfigureAudioSource();
    }

    /// <summary>
    /// Este método se llama automáticamente cada vez que el GameObject se activa.
    /// </summary>
    void OnEnable()
    {
        // Si el AudioSource ya está reproduciendo, no hacemos nada para evitar reinicios innecesarios.
        if (!audioSource.isPlaying)
        {
            // Inicia la reproducción del sonido. Como está en bucle, continuará indefinidamente.
            audioSource.Play();
        }
    }

    /// <summary>
    /// Este método se llama automáticamente cada vez que el GameObject se desactiva.
    /// </summary>
    void OnDisable()
    {
        // Detiene la reproducción del sonido inmediatamente.
        audioSource.Stop();
    }

    /// <summary>
    /// Configura el AudioSource con los parámetros necesarios para este script.
    /// </summary>
    private void ConfigureAudioSource()
    {
        // ¡MUY IMPORTANTE! Queremos que el sonido se repita.
        audioSource.loop = true;

        // No queremos que el sonido se inicie automáticamente al empezar el juego,
        // sino cuando nosotros lo indiquemos en OnEnable.
        audioSource.playOnAwake = false;
    }
}