using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class CambioDialogios : MonoBehaviour
{
    
    public GameObject panelDialogoInicial;
    public GameObject cementerio;

    public TextMeshProUGUI textoDialogoInicial;

    public static CambioDialogios reiniciarDialogo;

    public Rigidbody2D personaje;

    private void Awake()
    {
        if (reiniciarDialogo == null)
        {
            reiniciarDialogo = this;
        }
    }


    public string[] dialogosIniciales = {
        "Hola pequeño… si adivinaste, volvió a pasar,necesitaba despejarme, hablar contigo me ayuda y más en momentos como este, según el calendario hoy se cumplen 5 meses en racha,",
        "aun recuerdo cuando dormias conmigo en mi cama, a mamá no le gustaba eso… mamá, ya no hablamos como antes, está más distante… yo de verdad te extraño mucho, te necesito, por favor no me dejes…"

    };


    public int indiceDialogoInicial = 0;

    void Start()
    {
        
        panelDialogoInicial.SetActive(true); 

        
        MostrarDialogoInicial();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ContinuarDialogoInicial();
        }
    }

    void MostrarDialogoInicial()
    {
        if (indiceDialogoInicial < dialogosIniciales.Length)
        {
            textoDialogoInicial.text = dialogosIniciales[indiceDialogoInicial];
  
        }
        else
        {
            reiniciarDialogoInicial();
            descongelar();



            Debug.Log("Diálogo inicial terminado. El juego puede comenzar ahora.");
            panelDialogoInicial.SetActive(false);
            cementerio.SetActive(false);
        }
    }

  
    public void ContinuarDialogoInicial()
    {
        indiceDialogoInicial++;
        //congelar();
        MostrarDialogoInicial();
    }

    public void reiniciarDialogoInicial()
    {
        indiceDialogoInicial = 0;
        textoDialogoInicial.text = dialogosIniciales[indiceDialogoInicial];
    }
    /*void congelar()
    {
        print("congelado");
        personaje.constraints = RigidbodyConstraints2D.FreezeAll;
    }*/

    void descongelar()
    {
        personaje.constraints = RigidbodyConstraints2D.None;
        personaje.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
