using System.Collections;
using UnityEngine;

public class PruebaTorreta : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float range = 7f;
    [SerializeField] private float fireRate = 0.5f;
    public bool isSummoned = false;

    void Start()
    {

    
    }

    private void Update()
    {


    }

    void DoDmg()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");


        bool enemyInRange = false;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector2.Distance(transform.position, enemies[i].transform.position) <= range)
            {
                enemyInRange = true;
                break;
            }
        }


        if (!enemyInRange) return;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distancia = Vector2.Distance(transform.position, enemies[i].transform.position);

            if (distancia <= range)
            {
                GameObject b = Instantiate(orbPrefab, transform.position, Quaternion.identity);
                b.GetComponent<SummonOrbScript>()?.SetTarget(enemies[i]);
            }
        }

    }

    public void Dispara()
    {
        isSummoned = true;

        anim.SetBool("isSummoned", true);
        InvokeRepeating("DoDmg", 0, fireRate);
        StartCoroutine(DeactivateTurret());


    }

    IEnumerator DeactivateTurret()
    {
        yield return new WaitForSeconds(15f);
        isSummoned = false;
        anim.SetBool("isSummoned", false);
        CancelInvoke("DoDmg");
        
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }








}