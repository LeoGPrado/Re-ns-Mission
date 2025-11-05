using UnityEditor;
using UnityEngine;

public class CodigoPausa : MonoBehaviour
{

    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(Pausa == true)
            {
                Continuar();
            }

        }

    }

    public void Continuar()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;



        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
