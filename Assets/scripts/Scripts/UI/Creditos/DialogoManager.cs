using TMPro;
using UnityEngine;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager Instancia;

    [Header("UI")]
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;

    private string[] dialogosActuales;
    private int indice;
    private bool dialogoActivo;

    private void Awake()
    {
        Instancia = this;
        panelDialogo.SetActive(false);
    }

    private void Update()
    {
        if (dialogoActivo && Input.GetKeyDown(KeyCode.E))
        {
            SiguienteLinea();
        }
    }

    public void IniciarDialogo(string[] dialogos)
    {
        dialogosActuales = dialogos;
        indice = 0;
        dialogoActivo = true;

        panelDialogo.SetActive(true);
        textoDialogo.text = dialogosActuales[indice];
    }

    public void SiguienteLinea()
    {
        indice++;

        if (indice >= dialogosActuales.Length)
        {
            CerrarDialogo();
        }
        else
        {
            textoDialogo.text = dialogosActuales[indice];
        }
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        dialogoActivo = false;
    }

    public bool DialogoActivo()
    {
        return dialogoActivo;
    }
}
