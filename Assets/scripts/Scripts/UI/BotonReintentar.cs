using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReintentar : MonoBehaviour
{
    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
