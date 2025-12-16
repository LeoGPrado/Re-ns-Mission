using UnityEngine;
using UnityEngine.SceneManagement;

public class Salirdeltutorial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("protagonista"))
        {
            SceneManager.LoadScene("Pantalla inicio");
        }
    }
}
