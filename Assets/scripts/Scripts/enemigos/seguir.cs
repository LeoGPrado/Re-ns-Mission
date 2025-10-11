using UnityEngine;

public class seguir : MonoBehaviour
{
    public Transform objetivo;   
    public float velocidad = 5f; 
    private Vector3 velo = Vector3.zero;
    GameObject obj;

    private Vector3 ultimaPosicion;
    private Animator animSlime;
    private SpriteRenderer slimerender;


    void Start()
    {
        obj = GameObject.Find("personaje");

   
        if (obj != null)
        {
            objetivo = obj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo == true)
        {


            transform.position = Vector3.SmoothDamp(transform.position, objetivo.position, ref velo , 2f);

        }
    }
}
