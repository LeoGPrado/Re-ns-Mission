using Unity.VisualScripting;
using UnityEngine;

public class TutorialMuñeco : MonoBehaviour
{
    [SerializeField] Animator muñeco;

    public static TutorialMuñeco muñecoScript;

    private void Awake()
    {
        if (muñecoScript == null)
        {
            muñecoScript = this;
        }
 
    }


    void Start()
    {
        muñeco = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "proyectil")
        {
            AnimacionRecibirDañlo();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "areaPescado")
        {
            AnimacionRecibirDañlo();
        }
    }

    public void AnimacionRecibirDañlo()
    {
        muñeco.SetTrigger("ImpactoMP");
    }
}
