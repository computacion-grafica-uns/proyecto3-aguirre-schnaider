using UnityEngine;

public class MecheroLight : MonoBehaviour
{
    public Light luz;
    public float duracionEncendido = 0.3f;
    public float duracionApagado = 0.1f;
    public AnimationCurve intensidadCurve;
    public float maxIntensidad = 2f;

    private bool prendido;

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light>();

        if (luz == null)
        {
            Debug.LogError("No se encontró un componente Light.");
            return;
        }

        // Si no asignaste una curva en el Inspector, usamos una por defecto
        if (intensidadCurve == null || intensidadCurve.length == 0)
        {
            intensidadCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }

        luz.intensity = 0f;
        StartCoroutine(FlickerEncendido());
    }

    System.Collections.IEnumerator FlickerEncendido()
    {
        prendido = true;
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / duracionEncendido;
            luz.intensity = intensidadCurve.Evaluate(t) * maxIntensidad;
            yield return null;
        }
        luz.intensity = maxIntensidad;
    }

    public void ApagarChispero()
    {
        if (prendido)
            StartCoroutine(Apagar());
    }

    System.Collections.IEnumerator Apagar()
    {
        prendido = false;
        float inicio = luz.intensity;
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / duracionApagado;
            luz.intensity = Mathf.Lerp(inicio, 0, t);
            yield return null;
        }
        luz.intensity = 0;
    }
}
