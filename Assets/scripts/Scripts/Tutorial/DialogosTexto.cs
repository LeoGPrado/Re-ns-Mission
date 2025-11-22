using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro
using UnityEngine.SceneManagement;

public class DialogosTexto : MonoBehaviour
{

    public GameObject panelDialogoInicial;
    //public GameObject PanelSaltear;

    public GameObject armaTutorial;
    public GameObject EnemigoTutorial;

    public TextMeshProUGUI textoDialogoInicial;


    // Puedes tener diferentes diálogos aquí, o cargarlos desde un archivo/lista
    public string[] dialogosIniciales = {
        "Bienvenido a la demo de ren mission,para continuar da click en 'siguiente' ",
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
            if (indiceDialogoInicial == 2)
            {
                EnemigoTutorial.SetActive(true);
            }
            else if (indiceDialogoInicial == 3)
            {
                armaTutorial.SetActive(true);
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
