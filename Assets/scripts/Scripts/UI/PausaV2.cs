using UnityEditor;
using UnityEngine;

public class PausaV2 : MonoBehaviour
{

    public GameObject ObjetoMenuPausa;
    public GameObject CanvasGameplay;
    public bool Pausa = false;

    public static PausaV2 pausa;

    private void Awake()
    {
        if (pausa == null)
        {
            pausa = this;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
                PausarJuego();
            else
                Continuar();
        
    }

    }

    public void Continuar()
    {
        ObjetoMenuPausa.SetActive(false);
        CanvasGameplay.SetActive(true);

        Pausa = false;



        Time.timeScale = 1;
        Cursor.visible = true;

    }

    public void PausarJuego()
    {
        Pausa = true;
        ObjetoMenuPausa.SetActive(true);
        CanvasGameplay.SetActive(false);


        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   
}