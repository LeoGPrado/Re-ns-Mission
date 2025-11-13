using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiarEscenas : MonoBehaviour
{
    public GameObject gameObjectOscurecer;
    public RawImage Oscurecer;
    public float TOscurecer = 2f;

    //aclarar
    public GameObject gameObjectAclarecer;
    public RawImage aclararEscena;
    public float TAclarar = 2f;

    private void Start()
    {
        if (aclararEscena!=null)
        {
            StartCoroutine(aclarar());
        }

    }

    public void CambiarEscena(int indiceEscena)
    {
        if (gameObjectOscurecer != null)
        {
            gameObjectOscurecer.SetActive(true);
            StartCoroutine(oscuro(indiceEscena));
        }


    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CambiarEscena(0);
        }
    }

    IEnumerator oscuro(int Indice)
    {
        float tiempo = 0;
        Color oscurecer = Oscurecer.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TOscurecer)
        {
            tiempo += Time.deltaTime;
            oscurecer.a = Mathf.Lerp(0, 1, tiempo / TOscurecer);
            Oscurecer.color = oscurecer;
            yield return null;
        }

        //Application.Quit();
        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(Indice);
    }

    IEnumerator aclarar()
    {
        float tiempo = 0;
        Color Aclarar = aclararEscena.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TAclarar)
        {
            tiempo += Time.unscaledDeltaTime;
            Aclarar.a = Mathf.Lerp(1, 0, tiempo / TAclarar);
            aclararEscena.color = Aclarar;
            yield return null;
        }
        gameObjectAclarecer.SetActive(false);

        //yield return new WaitForSecondsRealtime(1f);

    }
}
