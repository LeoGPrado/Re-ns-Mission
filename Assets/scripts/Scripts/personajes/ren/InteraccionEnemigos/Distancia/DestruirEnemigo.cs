using UnityEngine;

public class DestruirEnemigo : MonoBehaviour
{
    [SerializeField] float velocidad = 8f;
    public bool quieto = true;
    [SerializeField] Animator ImpoctoArma;
    public static DestruirEnemigo DEnemigo;
    [SerializeField] private Rigidbody2D rb;

    public bool DFuego=false;
    public bool Dhielo=false;
    public bool Dnaturaleza=false;
    public bool Dnormal=false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (DEnemigo == null)
        {
            DEnemigo = this;
        }
    }

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

    private void Update()
    {
        Vector2 dir = rb.linearVelocity;
        if(dir.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemigo")
        {
            if(ImpoctoArma == null)
            {
                if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
                {
                    esqueleto.controlVida();
                }
                else if (collision.TryGetComponent<SlieControl>(out var slime))
                {
                    string tipoSlime = slime.confirmarElemento();
                    print("Elemento detectado en enemigo: " + tipoSlime);

                    //si coloco un nuevo metodo en slimecontrol que decuelva un true o folse
                    if (tipoSlime=="fuego")//y lo cocloca aqui ya que slimecontrol es static
                    {
                        if (DFuego == true)
                        {
                            slime.controlVida();
                        }
                        else if (Dhielo == true)
                        {
                            slime.controlVida();
                            slime.controlVida();
                            slime.controlVida();
                        }
                        else
                        {
                            slime.controlVida();
                            slime.controlVida();
                        }
                        /*print("La bala ha entrado a enemigo de fuego");
                        slime.controlVida();
                        slime.controlVida();
                        slime.controlVida();*/
                    }
                    else if (tipoSlime == "hielo")
                    {
                        if (Dhielo == true)
                        {
                            slime.controlVida();
                        }
                        else if (Dnaturaleza == true)
                        {
                            slime.controlVida();
                            slime.controlVida();
                            slime.controlVida();
                        }
                        else
                        {
                            slime.controlVida();
                            slime.controlVida();
                        }

                        /*print("La bala ha entrado a enemigo de hielo");
                        slime.controlVida();
                        slime.controlVida();
                        slime.controlVida();*/
                    }
                    else if (tipoSlime == "naturaleza")
                    {
                        if (Dnaturaleza == true)
                        {
                            slime.controlVida();
                        }
                        else if (DFuego == true)
                        {
                            slime.controlVida();
                            slime.controlVida();
                            slime.controlVida();
                        }
                        else
                        {
                            slime.controlVida();
                            slime.controlVida();
                        }

                        /*print("La bala ha entrado a enemigo de naturaleza");
                        slime.controlVida();
                        slime.controlVida();
                        slime.controlVida();*/
                    }
                    else if (tipoSlime == "normal")
                    {
                        print("La bala ha entrado a enemigo normal");
                        slime.controlVida();
                        slime.controlVida();
                    }
                    else
                    {
                        /*print("La bala ha entrado a resistencia");
                        slime.controlVida();*/
                    }
                    //slime.controlVida();
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
