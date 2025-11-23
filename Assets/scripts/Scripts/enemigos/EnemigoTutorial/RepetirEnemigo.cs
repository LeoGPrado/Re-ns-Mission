using UnityEngine;

public class RepetirEnemigo : MonoBehaviour
{
    private GameObject TutorialmesaGoblin;

    private void Awake()
    {
        Transform Mpadre = GameObject.Find("MesaPadre").transform;
        TutorialmesaGoblin = Mpadre.Find("Mesa tutorial (Goblin)").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "proyectil")
        {
            TutorialmesaGoblin.SetActive(true);
            TUtorialEnemigo.goblin.ApareceGoblin();
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
