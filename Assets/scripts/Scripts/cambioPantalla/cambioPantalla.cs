using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioPantalla : MonoBehaviour
{
    public void CargarSiguienteEscena(int Cambio)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Cambio);

    }
}
