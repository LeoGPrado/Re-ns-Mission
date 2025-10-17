using UnityEngine;
using System.Collections;


public class SpawnEnemyV2 : MonoBehaviour

{
    //Prefabs
    [SerializeField] private GameObject slimeNormal;
    [SerializeField] private GameObject slimeHielo;
    [SerializeField] private GameObject slimeFuego;
    [SerializeField] private GameObject slimeNaturaleza;

    /// Transforms de los spawners 
    [SerializeField] private Transform punto1;
    [SerializeField] private Transform punto2;
    [SerializeField] private Transform punto3;
    [SerializeField] private Transform punto4;

    /// Probabilidades 
    [SerializeField] private float probNormal = 50f;
    [SerializeField] private float probHielo = 20f;
    [SerializeField] private float probFuego = 15f;
    [SerializeField] private float probNaturaleza = 15f;


    [SerializeField] private float tiempoMin = 2f;
    [SerializeField] private float tiempoMax = 4f;

    private void Start()
    {
        StartCoroutine(SpawnSlimes());
    }

    private IEnumerator SpawnSlimes()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));

            CrearSlime(punto1);
            CrearSlime(punto2);
            CrearSlime(punto3);
            CrearSlime(punto4);
        }
    }

    private void CrearSlime(Transform punto)
    {
        if (punto == null) return;

        Instantiate(ElegirSlime(), punto.position, Quaternion.identity);
    }

    private GameObject ElegirSlime()
    {
        float valor = Random.Range(0f, 100f);

        if (valor < probNormal)
            return slimeNormal;
        else if (valor < probNormal + probHielo)
            return slimeHielo;
        else if (valor < probNormal + probHielo + probFuego)
            return slimeFuego;
        else
            return slimeNaturaleza;
    }
}