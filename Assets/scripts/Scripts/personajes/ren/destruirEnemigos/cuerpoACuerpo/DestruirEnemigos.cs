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

            Destroy(collision.gameObject);
            //Destroy(gameObject);            
        }

    }


}

