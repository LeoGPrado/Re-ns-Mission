using UnityEngine;
using System.Collections;

public class ataquePrincipal : MonoBehaviour
{
    [SerializeField] Animator ImpoctoArma;
    /*public Transform puntoAtaque;
    public Transform espada;*/

    void Update()
    {
        //espada.localPosition = puntoAtaque.localPosition;

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ataqueCuerpoCuerpo());
        }
    }


    IEnumerator ataqueCuerpoCuerpo()
    {
        ImpoctoArma.SetBool("ImpactoP", true);

        yield return new WaitForSeconds(0.5f);

        ImpoctoArma.SetBool("ImpactoP", false);

    }
}
