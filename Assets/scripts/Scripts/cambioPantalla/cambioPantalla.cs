using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioPantalla : MonoBehaviour
{
    public void CargarSiguienteEscena(int Cambio)
    {
        // SceneManager.LoadScene() puede tomar un �ndice entero
        SceneManager.LoadScene(Cambio);

    }
}
