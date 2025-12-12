using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Special3 : MonoBehaviour
{
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;
    public ControlPersonaje personaje;

    public GameObject ataqueArea;
    public Animator renAnimator;
    void Update()
    {
        if(medidor.canUseUltimate && Input.GetMouseButtonDown(2) && personaje.vidaInicial <= 2)
        {
            ataqueArea.SetActive(true);
            StartCoroutine(FrenarRetroceso());
            renAnimator.SetTrigger("AtaqueTerceario");
            medidor.canUseUltimate = false;
            playerEC.Ultimate();
        }

    }

    IEnumerator FrenarRetroceso()
    {
        yield return new WaitForSeconds(1f);
        ataqueArea.SetActive(false);


    }
}
