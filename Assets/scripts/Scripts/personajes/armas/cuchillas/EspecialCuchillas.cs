using UnityEngine;
using UnityEngine.AI;

public class EspecialCuchillas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            print("congelando NAVMESH");
            NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            SlieControl.slime.CongelamientoControl();
        }
    }
}
