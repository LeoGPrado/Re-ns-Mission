using UnityEngine;
using System.Collections;

public class EspecialPescado : MonoBehaviour
{
    public GameObject Especial;

    public void iniciarSpecialPescado()
    {
        StartCoroutine(TiempoEspecial());
    }

    IEnumerator TiempoEspecial()
    {
        Especial.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Especial.SetActive(false);
    }
}
