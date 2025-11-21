using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaHP : MonoBehaviour
{
    public RectTransform HealthUI;
    private float HealthSize = 647.5f;
    public static PuertaHP BarraVida;
    private void Awake()
    {
        if (BarraVida == null) 
        {
            BarraVida = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo") 
        {
            BajarHP();
            Destroy(collision.gameObject);
        }
    }

    public void BajarHP()
    {
        HealthSize -= 50;
        HealthUI.sizeDelta = new Vector2(HealthSize, 4.945001f);
        if (HealthSize < 0)
        {
            SceneManager.LoadScene("FinDemo");
        }
    }
}
