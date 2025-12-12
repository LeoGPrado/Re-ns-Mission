using UnityEngine;

public class Special3 : MonoBehaviour
{
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

    public GameObject ataqueArea;
    public Animator renAnimator;
    void Update()
    {
        if(medidor.canUseUltimate && Input.GetMouseButtonDown(2))
        {

            renAnimator.SetTrigger("AtaqueTerceario");
            medidor.canUseUltimate = false;
            playerEC.Ultimate();
        }

    }
}
