using UnityEngine;
using UnityEngine.SceneManagement;

public class salirDelJuego : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

    }
    public void CargarSiguienteEscena(int Cambio)
    {
        // SceneManager.LoadScene() puede tomar un índice entero
        Application.Quit();

    }
}
