using UnityEngine;

public class InteraccionNPC : MonoBehaviour
{
    private bool jugadorCerca;
    private DialogosCreditos npcDialogo;

    [Header("UI")]
    [SerializeField] private GameObject iconoTeclaE;

    private void Start()
    {
        npcDialogo = GetComponent<DialogosCreditos>();

        if (iconoTeclaE != null)
            iconoTeclaE.SetActive(false);
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (!DialogoManager.Instancia.DialogoActivo())
            {
                DialogoManager.Instancia.IniciarDialogo(npcDialogo.dialogos);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("protagonista"))
        {
            jugadorCerca = true;

            if (iconoTeclaE != null)
                iconoTeclaE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("protagonista"))
        {
            jugadorCerca = false;

            if (iconoTeclaE != null)
                iconoTeclaE.SetActive(false);

            DialogoManager.Instancia.CerrarDialogo();
        }
    }
}

