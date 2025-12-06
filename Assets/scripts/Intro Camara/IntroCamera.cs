using Unity.Cinemachine;
using UnityEngine;
using System.Collections;


public class IntroCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera playerCamara;
    [SerializeField] private CinemachineCamera camIntro;
    [SerializeField] private CinemachineCamera camSpawn;
    [SerializeField] private GameObject textoIndicativo;
    [SerializeField] private Animator textoAnimator; 
    [SerializeField] private Transform player;

    [SerializeField] private float tiempoDeEspera = 3f;
    [SerializeField] private float textoDelay = 1.5f;
    [SerializeField] private float delayInicial = 1f;
    [SerializeField] private float tiempoCamaraSpawn = 2f;



    void Start()
    {
        StartCoroutine(IntroConDelay());
    }

    IEnumerator IntroConDelay()
    {
        yield return new WaitForSeconds(delayInicial);
        playerCamara.ForceCameraPosition(player.position, playerCamara.transform.rotation);
        camIntro.Priority = 3;
        playerCamara.Priority = 1;
        camSpawn.Priority = 1;

        yield return new WaitForSeconds(textoDelay);

        textoAnimator.SetTrigger("Mostrar");

        yield return new WaitForSeconds(tiempoDeEspera - textoDelay);

        camIntro.Priority = 1;
        camSpawn.Priority = 3;

        yield return new WaitForSeconds(tiempoCamaraSpawn);

        camSpawn.Priority = 1;
        playerCamara.Priority = 3;
    }
}

