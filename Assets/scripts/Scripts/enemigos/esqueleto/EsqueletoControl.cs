using UnityEngine;
using System.Collections;

public class EsqueletoControl : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velo = Vector3.zero;
    GameObject obj;

    public static EsqueletoControl Esqueleto;
    public Animator EsqueletoAnimacion;

    public int VidaEnemigo=2;

    private void Awake()
    {
        if (Esqueleto == null)
        {
            Esqueleto = this;
        }
    }


    void Start()
    {
        obj = GameObject.Find("personaje");


        if (obj != null)
        {
            objetivo = obj.transform;
        }
    }

    void Update()
    {
        if (objetivo == true)
        {


            transform.position = Vector3.SmoothDamp(transform.position, objetivo.position, ref velo, 2f);

        }
    }

    public void controlVida()
    {
        if (VidaEnemigo <= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            VidaEnemigo--;
        }
    }
    public void quemarEsqueleto()
    {
        StartCoroutine(DañoPorFuego());
    }

    IEnumerator DañoPorFuego()
    {
        int repeticiones = 3; 

        for (int i = 0; i < repeticiones; i++)
        {
            controlVida(); 

            GetComponent<SpriteRenderer>().color = Color.red;

            yield return new WaitForSeconds(2f);
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            EsqueletoAnimacion.SetBool("atacarP", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            EsqueletoAnimacion.SetBool("atacarP", false);
        }
    }

}
