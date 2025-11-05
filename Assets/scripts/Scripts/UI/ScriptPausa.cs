using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptPausa : MonoBehaviour
{
    [SerializeField] private GameObject ObjectMenuPuase;
    [SerializeField] private bool Pause = false;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ObjectMenuPuase.SetActive(true);
            if (Pause)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        Pause = true;
        Time.timeScale = 0;
        ObjectMenuPuase.SetActive(true);
    }

    public void Reanudar()
    {
        Pause = false;
        Time.timeScale = 1;
        ObjectMenuPuase.SetActive(false);

    }

    public void Reiniciar()
    {
        Pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}