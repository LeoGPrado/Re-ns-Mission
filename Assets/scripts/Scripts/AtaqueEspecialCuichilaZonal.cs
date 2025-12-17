using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AtaqueEspecialCuichilaZonal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            collision.GetComponent<SlieControl>().CongelamientoControl();
            StartCoroutine("apagarEspecial");
        }
    }

    IEnumerator apagarEspecial()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
