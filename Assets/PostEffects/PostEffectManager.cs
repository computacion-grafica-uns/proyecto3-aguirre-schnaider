using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    // Creamos un array p�blico para guardar una referencia a cada uno de los efectos de las c�maras.
    // El tipo de dato es "EmbossEffect", el nombre de tu script.
    public EmbossEffect[] cameraEffects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Llama a la funci�n para alternar el efecto de la c�mara en la posici�n 0 del array.
            ToggleEffect();
        }
    }
        

    // Funci�n para activar/desactivar el efecto de una c�mara espec�fica
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