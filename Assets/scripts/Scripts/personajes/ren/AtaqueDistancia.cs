using UnityEngine;

public class AtaqueDistancia : MonoBehaviour
{
    public GameObject balaPrefab;   
    public Transform puntoAparicion;  
    public float velocidadBala = 20f;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        
        GameObject bala = Instantiate(balaPrefab, puntoAparicion.position, puntoAparicion.rotation);

        //Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        //bala.GetComponent<Rigidbody2D>().linearVelocity = puntoAparicion.right * velocidadBala;
            
        
        
        Destroy(bala, 3f);
    }
}
