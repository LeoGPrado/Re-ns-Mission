using UnityEditor;
using UnityEngine;

public class PausaV2 : MonoBehaviour
{

    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    public static PausaV2 pausa;

    private void Awake()
    {
        if (pausa == null)
        {
            pausa = this;
        }
    }

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
                SeguirTiempo();
                /*Pausa = true;
                ObjetoMenuPausa.SetActive(true);
                //ParaTiempo();
                //Pausa = true;
                
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;*/
            }
            else if (Pausa == true)
            {
                Continuar();
            }

        }

    }

    public void Continuar()
    {
        ObjetoMenuPausa.SetActive(false);
        //SeguirTiempo();
        Pausa = false;



        Time.timeScale = 1;
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    public void SeguirTiempo()
    {
        Pausa = true;
        ObjetoMenuPausa.SetActive(true);
        //ParaTiempo();
        //Pausa = true;

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /*public void ParaTiempo()
    {
        Pausa = true;
        Time.timeScale = 0;

    }*/
}