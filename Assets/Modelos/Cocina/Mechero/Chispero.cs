using UnityEngine;

public class Chispero : MonoBehaviour
{
    public Light luz;
    public float minIntensidad = 0f;
    public float maxIntensidad = 2f;
    public float velocidadChispa = 0.05f; // tiempo entre chispas

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light>();

        if (luz == null)
        {
            Debug.LogError("No se encontró un componente Light.");
            return;
        }

        StartCoroutine(Chispear());
    }

    System.Collections.IEnumerator Chispear()
    {
        while (true)
        {
            float nuevaIntensidad = Random.Range(minIntensidad, maxIntensidad);
            luz.intensity = nuevaIntensidad;
            yield return new WaitForSeconds(velocidadChispa);
        }
    }
}
