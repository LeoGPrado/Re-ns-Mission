using System.Collections;
using UnityEngine;


public class SummonController : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] private GameObject orbPrefab;

    [SerializeField] private float range = 7f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float summonDuration = 15f;
    public bool isSummoned = false;

    private Coroutine attackRout;
    private Coroutine durationRout;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SummonTurret()
    {
        if (isSummoned) return;

        isSummoned = true;
        anim.SetBool("isSummoned", true);

        attackRout = StartCoroutine(AttackLoop());
        durationRout = StartCoroutine(DeactivateTurret());
    }

    private void Update()
    {

        if (!isSummoned)
            return;

        if (isSummoned)
        {
            anim.SetBool("isSummoned", true);
            
            StartCoroutine(DeactivateTurret());
            
        }
           
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

            if(distancia <= range)
            {
                GameObject b = Instantiate(orbPrefab, transform.position, Quaternion.identity);
                b.GetComponent<SummonOrbScript>()?.SetTarget(enemies[i]);
            }
        }
        
    }

    IEnumerator AttackLoop()
    {
        while (isSummoned)
        {
            DoDmg();
            yield return new WaitForSeconds(fireRate);
        }
       
    }

    IEnumerator DeactivateTurret()
    {
        yield return new WaitForSeconds(fireRate);
        Deactivate();
    }
    
    void Deactivate()
    {
        isSummoned = false;
        anim.SetBool("isSummoned", false);

        if(attackRout != null)
        {
            StopCoroutine(attackRout);
            attackRout = null;
        }
        if(durationRout != null)
        {
            StopCoroutine(durationRout);
            durationRout = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
