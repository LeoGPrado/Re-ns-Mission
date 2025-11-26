using System;
using UnityEngine;
using System.Collections;

public class TutorialQuemar : MonoBehaviour
{
    public SpriteRenderer SpriteMuñeco;
    public bool Colisionando = false;

    public static TutorialQuemar controlTutorialQuemar;

    public void Awake()
    {
        if(controlTutorialQuemar == null)
        {
            controlTutorialQuemar = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*GameObject Muñeco = GameObject.Find("Muñeco");
        SpriteMuñeco = Muñeco.GetComponent<SpriteRenderer>();*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MuñecoPrueba")
        {
            Colisionando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MuñecoPrueba")
        {
            Colisionando = false;
        }
    }

    public void detectarMuñeco()
    {
        GameObject Muñeco = GameObject.Find("Muñeco");
        SpriteMuñeco = Muñeco.GetComponent<SpriteRenderer>();
    }

    void quemarMuñeco()
    {

        if (Colisionando == true)
        {
            TutorialMuñeco.muñecoScript.AnimacionRecibirDañlo();
            SpriteMuñeco.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine("volverNomalidad");
        }
    }
    IEnumerator volverNomalidad()
    {

        yield return new WaitForSeconds(3f);
        SpriteMuñeco.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
