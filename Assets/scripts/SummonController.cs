using UnityEngine;


public class SummonController : MonoBehaviour
{
    
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float range = 5f;
    [SerializeField] private float fireRate = 0.5f;
   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("DoDmg", 0f, fireRate);

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
