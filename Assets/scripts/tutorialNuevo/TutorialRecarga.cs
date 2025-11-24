using UnityEngine;

public class TutorialRecarga : MonoBehaviour
{
    public GameObject BarraUltiLLena;

    [SerializeField] GameObject Espada;
    [SerializeField] GameObject Pollo;
    [SerializeField] GameObject Mazo;
    [SerializeField] GameObject Pescado;
    [SerializeField] GameObject Arco;
    [SerializeField] GameObject Pincel;
    [SerializeField] GameObject Baston;
    [SerializeField] GameObject Cuchilla;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "protagonista")
        {
            if (Cuchilla.activeInHierarchy)
            {
                cuchillasControl.controlCuchilla.ActivarEspacialCuchilla = true;
            }
            else if (Arco.activeInHierarchy)
            {
                TutorialArcoControl.TArcoEspecial.AtqueEspecial = true;
            }
            else if (Pincel.activeInHierarchy)
            {
                cuchillasControl.controlCuchilla.ActivarEspacialCuchilla = true;
            }
            else if (Baston.activeInHierarchy)
            {
                cuchillasControl.controlCuchilla.ActivarEspacialCuchilla = true;
            }
            else
            {

            }

            TutorialArmasEspeciales.TutorialControlEspecialE.ActivarEspecial2=true;

            BarraUltiLLena.SetActive(true);
        }
    }
}
