using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioPantallaCargando : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private float delay;
    void Start()
    {
        Invoke("CargarEscena", delay);
    }

    // Update is called once per frame
    void CargarEscena()
    {
        SceneManager.LoadScene(scene);
    }
}
