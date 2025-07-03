using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    // Creamos un array público para guardar una referencia a cada uno de los efectos de las cámaras.
    // El tipo de dato es "EmbossEffect", el nombre de tu script.
    public EmbossEffect[] cameraEffects1;
    public ScanlinesEffect[] cameraEffects2;

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
        if (cameraEffects1.Length > 0 && cameraEffects2.Length > 0)
        {
           for(int i=0; i < cameraEffects1.Length; i++)
            {
                if (cameraEffects1[i]!=null)
                    cameraEffects1[i].on = !cameraEffects1[i].on;
                if (cameraEffects2[i]!=null)
                    cameraEffects2[i].on = !cameraEffects2[i].on;
            }

        }
    }
}