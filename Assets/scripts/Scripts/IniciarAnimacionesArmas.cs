using UnityEngine;
using System.Collections;

public class IniciarAnimacionesArmas : MonoBehaviour
{
    public ControlDeAnimacionesArmas animacionArmasScript;

    public void ActivarAArmas()
    {
        StartCoroutine("iniciaracativadorScript");
    }
    IEnumerator iniciaracativadorScript()
    {
        yield return new WaitForSeconds(0.1f);
        animacionArmasScript.enabled = true;
    }
}
