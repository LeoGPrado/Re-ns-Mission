using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class TutorialDialogos : MonoBehaviour
{
    public GameObject panelDialogoInicial;

    //Activarobjetos
    public GameObject movimientosTutorial;
    public GameObject AparecerMuñeco;


    //activarScripts
    public GameObject RenScripts;
    public TutorialControlP MPersonaje;


    //public GameObject armaTutorial;
    //public GameObject EnemigoTutorial;

    public TextMeshProUGUI textoDialogoInicial;



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
            else if (indiceDialogoInicial == 3)
            {

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
}
