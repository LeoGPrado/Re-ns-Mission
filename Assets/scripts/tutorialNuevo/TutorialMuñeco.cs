using Unity.VisualScripting;
using UnityEngine;

public class TutorialMuñeco : MonoBehaviour
{
    [SerializeField] Animator muñeco;

    public static TutorialMuñeco muñecoScript;

    private void Awake()
    {
        muñecoScript = this;
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
    }

    void AnimacionRecibirDañlo()
    {
        muñeco.SetTrigger("ImpactoMP");
    }
}
