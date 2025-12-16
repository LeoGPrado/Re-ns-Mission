using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioPantallaCargando : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private float delay;
    void Start()
    {
        Time.timeScale = 1f;
        Invoke("CargarEscena", delay);
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(scene);
    }
}
