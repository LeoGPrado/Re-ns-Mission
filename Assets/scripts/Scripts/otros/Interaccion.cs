using UnityEngine;

public class Interaccion : MonoBehaviour
{

    [SerializeField] GameObject activarCuadro;
    [SerializeField] GameObject activarCementerio;

    public Rigidbody2D personaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool enRango;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && enRango == true)
        {
            activarCuadro.SetActive(true);
            activarCementerio.SetActive(true);
            CambioDialogios.reiniciarDialogo.indiceDialogoInicial = 0;
            congelar();
        }
    }

    void congelar()
    {
        print("congelado");
        personaje.constraints = RigidbodyConstraints2D.FreezeAll;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {

            enRango = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {

            enRango = false;

        }
    }
}
