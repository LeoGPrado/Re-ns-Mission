using UnityEngine;

public class NuevoEspadaControl : MonoBehaviour
{

    public Transform FlipEspada;


    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Espada;
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;
    [SerializeField] GameObject muroPrefab;
    private bool ultiActive = false;

    private void Start()
    {

    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipEspada = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            Espada.flipX = true;

            Espada.transform.localPosition = FlipEspada.localPosition + new Vector3(0f, 0f, 0f);
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Espada.flipX = false;

            Espada.transform.localPosition = FlipEspada.localPosition + new Vector3(0f, 0f, 0f);
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }


        if (Input.GetMouseButtonDown(1) && medidor.canUseUltimate)
        {
            playerEC.Ultimate();
            MurodeFuego();
        }
        else
        {

        }
    }


    void MurodeFuego()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        //Calcular la dirección
        Vector3 direction = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 180f; // porque el prefab apunta hacia abajo


        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // 4. Instanciar el muro un poquito delante del jugador (opcional)
        Vector3 spawnPos = transform.position + direction;


        GameObject wall = Instantiate(muroPrefab, spawnPos, rotation);

        wall.GetComponent<FireWallMovemnt>().Init(direction);

    }



}
