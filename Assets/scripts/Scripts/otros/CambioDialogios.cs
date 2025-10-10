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
        "Hola peque�o� si adivinaste, volvi� a pasar,necesitaba despejarme, hablar contigo me ayuda y m�s en momentos como este, seg�n el calendario hoy se cumplen 5 meses en racha,",
        "aun recuerdo cuando dormias conmigo en mi cama, a mam� no le gustaba eso� mam�, ya no hablamos como antes, est� m�s distante� yo de verdad te extra�o mucho, te necesito, por favor no me dejes�"

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



            Debug.Log("Di�logo inicial terminado. El juego puede comenzar ahora.");
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
