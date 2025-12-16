using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CamaraShake : MonoBehaviour
{
    [SerializeField] private CinemachineCamera camaraNormal;
    [SerializeField] private CinemachineCamera camarashake;

    [SerializeField] private float duracion = 0.25f;

    private int prioridadOriginal;

    void Awake()
    {
        prioridadOriginal = camarashake.Priority;
    }

    public void Shake()
    {
        StartCoroutine(ShakeEjecutar());
    }

    IEnumerator ShakeEjecutar()
    {
        camarashake.Priority = 100;

        yield return new WaitForSeconds(duracion);
        camarashake.Priority = prioridadOriginal;
    }
}


