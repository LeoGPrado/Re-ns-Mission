using UnityEngine;

public class QuemarEnemigo : MonoBehaviour
{
    void Start()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemigo")
        {
            print("ha chocado");

            EsqueletoControl.Esqueleto.quemarEsqueleto();
            //Destroy(gameObject);            
        }
    }
}
