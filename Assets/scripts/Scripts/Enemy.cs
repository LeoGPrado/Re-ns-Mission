using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject manaParticlePrefab;
    public int hitNumber = 0;

    void EnemyDeath()
    {
        Instantiate(manaParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if(hitNumber == 3)
        {
            EnemyDeath();
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            hitNumber++;
            Destroy(collision.gameObject);
        }
    }

}
