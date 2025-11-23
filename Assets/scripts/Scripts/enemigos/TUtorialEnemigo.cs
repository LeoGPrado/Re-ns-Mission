using UnityEngine;
using System.Collections;

public class TUtorialEnemigo : MonoBehaviour
{
    public GameObject TutorialmesaGoblin;
    public GameObject goblinTutorialPrefab;
    public Transform puntoRespawn;

    public static TUtorialEnemigo goblin;

    private void Awake()
    {
        goblin = this;
    }



    public void ApareceGoblin()
    {
        StartCoroutine(DropAndCooldown());

    }

    IEnumerator DropAndCooldown()
    {
        TutorialmesaGoblin.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        Instantiate(goblinTutorialPrefab, puntoRespawn.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        TutorialmesaGoblin.SetActive(false);

    }
}
