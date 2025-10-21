using UnityEngine;
using UnityEngine.SceneManagement;
public class cambioPantallas : MonoBehaviour
{
  

    public void cambioEscena(int nivel)
    {
        SceneManager.LoadScene(nivel);
    }

}