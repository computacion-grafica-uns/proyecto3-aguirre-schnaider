using UnityEngine;

// Aseguramos que el GameObject tenga un AudioSource.
[RequireComponent(typeof(AudioSource))]
public class LoopingSoundOnEnable : MonoBehaviour
{
    // NO NECESITAMOS un AudioClip aqu�, lo configuraremos directamente en el AudioSource.

    private AudioSource audioSource;

    void Awake()
    {
        // Obtenemos la referencia al componente AudioSource.
        audioSource = GetComponent<AudioSource>();

        // Forzamos configuraciones importantes en el AudioSource para que funcione correctamente.
        // Esto evita errores de configuraci�n en el Inspector.
        ConfigureAudioSource();
    }

    /// <summary>
    /// Este m�todo se llama autom�ticamente cada vez que el GameObject se activa.
    /// </summary>
    void OnEnable()
    {
        // Si el AudioSource ya est� reproduciendo, no hacemos nada para evitar reinicios innecesarios.
        if (!audioSource.isPlaying)
        {
            // Inicia la reproducci�n del sonido. Como est� en bucle, continuar� indefinidamente.
            audioSource.Play();
        }
    }

    /// <summary>
    /// Este m�todo se llama autom�ticamente cada vez que el GameObject se desactiva.
    /// </summary>
    void OnDisable()
    {
        // Detiene la reproducci�n del sonido inmediatamente.
        audioSource.Stop();
    }

    /// <summary>
    /// Configura el AudioSource con los par�metros necesarios para este script.
    /// </summary>
    private void ConfigureAudioSource()
    {
        // �MUY IMPORTANTE! Queremos que el sonido se repita.
        audioSource.loop = true;

        // No queremos que el sonido se inicie autom�ticamente al empezar el juego,
        // sino cuando nosotros lo indiquemos en OnEnable.
        audioSource.playOnAwake = false;
    }
}