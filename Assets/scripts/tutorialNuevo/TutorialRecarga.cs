using UnityEngine;

public class TutorialRecarga : MonoBehaviour
{
    public GameObject BarraUltiLLena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            cuchillasControl.controlCuchilla.ActivarEspacialCuchilla = true;
            ArcoControlador.arcoEspecialT.ActivarEspacialArco = true;
            TutorialArmasEspeciales.TutorialControlEspecialE.ActivarEspecial2=true;
            //Disparo.controlDisparo.ActivarEspacialDisparo = true;
            BarraUltiLLena.SetActive(true);
        }
    }
}
