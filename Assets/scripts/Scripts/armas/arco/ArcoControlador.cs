using UnityEngine;

public class ArcoControlador : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicion;


    public Transform FlipArco;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer arco;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (mousePos.x < transform.position.x)
        {
            arco.flipX = true;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;
            arco.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            arco.flipX = false;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;
            arco.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DisparoNormal();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DisparoEspecial();
        }
    }

    void DisparoNormal()
    {

        GameObject balNormal = Instantiate(balaNormal, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(balNormal, 3f);

    }

    void DisparoEspecial()
    {

        GameObject bala = Instantiate(balaEspecialPrefab, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(bala, 1f);

    }
}
