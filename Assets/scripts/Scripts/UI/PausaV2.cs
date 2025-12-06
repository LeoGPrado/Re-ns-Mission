using UnityEngine;

public class PausaV2 : MonoBehaviour
{

    public GameObject ObjetoMenuPausa;
    public GameObject CanvasGameplay;
    public bool Pausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa)
                Continuar();
            else
                PausarJuego();
        }
    }

    public void Continuar()
    {
        Pausa = false;
        ObjetoMenuPausa.SetActive(false);
        CanvasGameplay.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PausarJuego()
    {
        Pausa = true;
        ObjetoMenuPausa.SetActive(true);
        CanvasGameplay.SetActive(false);
        Time.timeScale = 0f;  
    }
}
