using UnityEngine;

public class pincelControl : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicionBala;


    public Transform FlipPincel;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer pincel;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (mousePos.x < transform.position.x)
        {
            pincel.flipX = true;
            Vector3 pos = puntoAparicionBala.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicionBala.localPosition = pos;
            pincel.transform.localPosition = FlipPincel.localPosition;
            pincel.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            pincel.flipX = false;
            Vector3 pos = puntoAparicionBala.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicionBala.localPosition = pos;
            pincel.transform.localPosition = FlipPincel.localPosition;
            pincel.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
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

        GameObject balNormal = Instantiate(balaNormal, puntoAparicionBala.position, puntoAparicionBala.rotation);
        Destroy(balNormal, 3f);

    }

    void DisparoEspecial()
    {

        GameObject bala = Instantiate(balaEspecialPrefab, puntoAparicionBala.position, puntoAparicionBala.rotation);
        Destroy(bala, 1f);

    }
}
