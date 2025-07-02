using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    // Creamos un array público para guardar una referencia a cada uno de los efectos de las cámaras.
    // El tipo de dato es "EmbossEffect", el nombre de tu script.
    public EmbossEffect[] cameraEffects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Llama a la función para alternar el efecto de la cámara en la posición 0 del array.
            ToggleEffect();
        }
    }
        

    // Función para activar/desactivar el efecto de una cámara específica
    public void ToggleEffect()
    {
        // Verificamos que haya camaras
        if (cameraEffects.Length > 0)
        {
           for(int i=0; i < cameraEffects.Length; i++)
            {
                if (cameraEffects[i]!=null)
                    cameraEffects[i].on = !cameraEffects[i].on;
            }

        }
    }
}