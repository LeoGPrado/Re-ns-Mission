using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class TutorialDialogos : MonoBehaviour
{
    public GameObject panelDialogoInicial;

    //Activarobjetos
    public GameObject movimientosTutorial;
    public GameObject AparecerMuñeco;
    public GameObject AparecerSelectorArmas;
    public GameObject AparecerSelectorArmasCuerpoACuerpo;
    public GameObject barraEspecial;

    public GameObject arcoActivado;
    public GameObject espadaActivador;


    //activarScripts
    public GameObject RenScripts;
    public TutorialControlP MPersonaje;
    public TutorialArmas APersoaje;


    //public GameObject armaTutorial;
    //public GameObject EnemigoTutorial;

    public TextMeshProUGUI textoDialogoInicial;

    public static TutorialDialogos ActivarTutorialDialogosScript;

    private void Awake()
    {
        if( ActivarTutorialDialogosScript == null)
        {
            ActivarTutorialDialogosScript = this;
        }
    }


    public string[] dialogosIniciales = {
        "Bienvenido a Ren Mission, acontinuacion te diremos los controles de este juego ",
        "Para moverte por la sala usa A,S,D,W.",
        "Lo que acaba de aoarecer es un enemigo",
        "Te daremos un arma para este tutorial",
        "Con click izquierdo podras lanzar un ataque normal con el arma",
        "Con Click Derecho podras lanzar un ataque especial con el arma",
        "La gran maypria de armas tendra un ataque normal y especial , algunas solo tienen un ataque normal",
        "Ahora que ya aprendiste como jugar dale a 'siguiente' una vez mas para empezar el juego"
    };


    private int indiceDialogoInicial = 0;

    void Start()
    {
        RenScripts = GameObject.Find("personaje");
        MPersonaje= RenScripts.GetComponent<TutorialControlP>();
        APersoaje=RenScripts.GetComponent<TutorialArmas>();



        panelDialogoInicial.SetActive(true);


        MostrarDialogoInicial();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinuarDialogoInicial();
        }
    }

    void MostrarDialogoInicial()
    {
        if (indiceDialogoInicial < dialogosIniciales.Length)
        {
            textoDialogoInicial.text = dialogosIniciales[indiceDialogoInicial];
            if (indiceDialogoInicial == 1)
            {
                MPersonaje.enabled=true;
                movimientosTutorial.SetActive(true);
            }
            else if (indiceDialogoInicial == 2)
            {
                movimientosTutorial.SetActive(false);
                AparecerMuñeco.SetActive(true);
                TutorialQuemar.controlTutorialQuemar.detectarMuñeco();
            }
            else if (indiceDialogoInicial == 4)
            {
                //selectorArmas
                AparecerSelectorArmas.SetActive(true);
            }
            else if (indiceDialogoInicial == 6)
            {
                TutorialArmasEspeciales.TutorialControlEspecialE.ActivarEspecial2 = true;

                if (arcoActivado.activeInHierarchy)
                {
                    TutorialArcoControl.TArcoEspecial.AtqueEspecial = true;
                }
                barraEspecial.SetActive(true);
            }
            else if (indiceDialogoInicial == 8)
            {
                //selectorArmas
                APersoaje.enabled = false;
                arcoActivado.SetActive(false);
                AparecerSelectorArmasCuerpoACuerpo.SetActive(true);
            }

        }
        else
        {

            panelDialogoInicial.SetActive(false);
            SceneManager.LoadScene("CinematicaPostTutorial");

            Debug.Log("Diálogo inicial terminado. El juego puede comenzar ahora.");
        }
    }
    public void ContinuarDialogoInicial()
    {
        indiceDialogoInicial++;
        MostrarDialogoInicial();
    }
    public void ActivarScriptAtacque()
    {
        APersoaje.enabled = true;
    }
}
