using UnityEngine;
using System.Collections.Generic;

public class SummonOrbScript : MonoBehaviour
{
    
    [SerializeField] private float speed = 4f;
    [SerializeField] private Transform target;


    public void SetTarget(GameObject enemy)
    {
        if(enemy != null)
        target = enemy.transform;
    }



    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == target.gameObject)
        {
            collision.GetComponent<SlieControl>()?.Instakill();
            Destroy(gameObject);
        }
    }
}
