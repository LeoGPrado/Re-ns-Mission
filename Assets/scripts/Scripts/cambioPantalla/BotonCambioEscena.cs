using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonCambioEscena : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }

}
