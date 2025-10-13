using UnityEngine;

public class DestruirEnemigos : MonoBehaviour
{


    void Start()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Enemigo")
        {


                if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
                {
                    esqueleto.controlVida();
                }
                else if (collision.TryGetComponent<SlieControl>(out var slime))
                {
                    slime.controlVida();
                }
                //Destroy(gameObject);        
        }

    }


}

