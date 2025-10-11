using UnityEngine;

public class SlieControl : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velo = Vector3.zero;
    GameObject obj;

    public static SlieControl slime;

    public int VidaEnemigo = 1;



    private void Awake()
    {
        if (slime == null)
        {
            slime = this;
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

        if (objetivo != null)  
        {
           transform.position = Vector3.SmoothDamp(transform.position, objetivo.position, ref velo, 3f);
          
            if (objetivo.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (objetivo.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

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
}
