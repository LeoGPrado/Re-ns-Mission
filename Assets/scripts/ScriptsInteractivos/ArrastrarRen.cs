using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ArrastrarRen : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public bool Entro = false;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PasarCiudad")
        {
            Entro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PasarCiudad")
        {
            Entro = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Entro==true)
        {
            SceneManager.LoadScene("NuevoTutorial");
        }
    }
}
