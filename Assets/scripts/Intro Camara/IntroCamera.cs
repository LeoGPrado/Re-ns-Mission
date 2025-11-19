using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class IntroCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera playerCamara;
    [SerializeField] private CinemachineCamera camIntro;
    [SerializeField] private GameObject textoIndicativo;

    [SerializeField] private float tiempoDeEspera = 3f;
    [SerializeField] private float textoDelay = 1.5f;

    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        camIntro.Priority = 20;
        playerCamara.Priority = 10;
        textoIndicativo.SetActive(false);
        yield return new WaitForSeconds(textoDelay);
        textoIndicativo.SetActive(true);
        yield return new WaitForSeconds(tiempoDeEspera - textoDelay);

        textoIndicativo.SetActive(false);
        camIntro.Priority = 5;
        playerCamara.Priority = 20;
    }
}
