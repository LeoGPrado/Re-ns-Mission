using UnityEngine;
using System.Collections;

public class ActivarcolisionesLimites : MonoBehaviour
{
    public BoxCollider2D ActivadorDeColliders;

    private void Start()
    {
        StartCoroutine("ActivarBox");
    }

    IEnumerator ActivarBox()
    {
        yield return new WaitForSeconds(1f);
        ActivadorDeColliders.enabled = true;
    }
}
