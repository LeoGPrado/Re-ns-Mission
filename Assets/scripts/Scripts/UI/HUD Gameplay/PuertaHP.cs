using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaHP : MonoBehaviour
{
    public RectTransform HealthUI;
    private float HealthSize = 700f;
    public static PuertaHP BarraVida;
    private void Awake()
    {
        if (BarraVida == null) 
        {
            BarraVida = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BajarHP()
    {
        HealthSize -= 400;
        HealthUI.sizeDelta = new Vector2(HealthSize, 50);
        if (HealthSize < 0)
        {
            SceneManager.LoadScene("FinDemo");
        }
    }
}
