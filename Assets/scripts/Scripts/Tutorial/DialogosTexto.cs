using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro
using UnityEngine.UI; // Necesario para usar UI en general
using UnityEngine.SceneManagement;

public class DialogosTexto : MonoBehaviour
{
    // Asigna estos GameObjects desde el Inspector de Unity
    public GameObject panelDialogoInicial;
    //public GameObject PanelSaltear;
    //public GameObject BotonJugar;
    //public GameObject CambioTutorial;
    //public GameObject presionarJugar;
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
        // Asegúrate de que los paneles estén configurados correctamente al inicio
        panelDialogoInicial.SetActive(true); // El primer diálogo está activo al inicio

        // Muestra el primer diálogo inicial
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
            // Si no hay más diálogos iniciales, ocultar el panel inicial
            panelDialogoInicial.SetActive(false);
            SceneManager.LoadScene("prueba mapa 1");
            //PanelSaltear.SetActive(false);
            //BotonJugar.SetActive(true);
            //CambioTutorial.SetActive(true);
            //presionarJugar.SetActive(true);
            // Aquí puedes hacer que el juego comience si el diálogo inicial es una intro
            Debug.Log("Diálogo inicial terminado. El juego puede comenzar ahora.");
        }
    }

    // Esta función se llamará cuando pulses el botón de "Continuar" del primer diálogo
    public void ContinuarDialogoInicial()
    {
        indiceDialogoInicial++;
        MostrarDialogoInicial();
    }
}
