using UnityEngine;

public class DestruirEnemigo : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    public bool quieto = true;
    [SerializeField] Animator ImpoctoArma;

    void Start()
    {
        if (quieto == true)
        {

        }
        else
        {
  
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; 


            Vector2 direccion = (mousePos - transform.position).normalized;


            GetComponent<Rigidbody2D>().linearVelocity = direccion * velocidad;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            if(ImpoctoArma == null)
            {
                if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
                {
                    esqueleto.controlVida();
                }
                else if (collision.TryGetComponent<SlieControl>(out var slime))
                {
                    slime.controlVida();
                }
                Destroy(gameObject);
            }
            else
            {
                ImpoctoArma.SetTrigger("ImpactoP");
                GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                Destroy(collision.gameObject);
                //Destroy(gameObject);          
            }    
        }

    }


}
