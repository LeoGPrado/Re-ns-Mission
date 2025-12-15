using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrastrarRen : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [Header("Sprites de Ren")]
    [SerializeField] private Sprite spriteRenNormal;
    [SerializeField] private Sprite spriteRenClickeado;
    [Space(10)]

    [Header("Cursor del nivel")]
    [SerializeField] private Texture2D cursorNuevo;
    [SerializeField] private Vector2 posicionMouse = Vector2.zero;
    [SerializeField] private Color colorAlPasarCursor;
    [SerializeField] private float alphaAlClickear = 0.5f;
    [Space(10)]

    [Header("Audios")]
    [SerializeField] private AudioClip sonidoAlClickear;
    private AudioSource audioClick;
    [Space(10)]

    private Image ren;
    private RectTransform rect;
    private Vector3 posicionOriginal;
    private bool mouseSobreRen = false;
    private bool Entro = false;
    private Color colorOriginal;


    void Start()
    {
        Cursor.SetCursor(cursorNuevo, posicionMouse, CursorMode.Auto);

        ren = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        audioClick = GetComponent<AudioSource>();
        colorOriginal = ren.color;
        posicionOriginal = rect.position;
    }
    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        bool ahoraSobreRen = RectTransformUtility.RectangleContainsScreenPoint(rect, mouse);

        if (ahoraSobreRen != mouseSobreRen)
        {
            mouseSobreRen = ahoraSobreRen;
            ren.color = mouseSobreRen ? colorAlPasarCursor : colorOriginal;
        }


        if (Input.GetMouseButtonDown(0) && ahoraSobreRen)
        {
            ren.sprite = spriteRenClickeado;
            Color color = ren.color;
            color.a = alphaAlClickear;
            ren.color = color;
            audioClick.PlayOneShot(sonidoAlClickear);
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.visible = true;
            audioClick.PlayOneShot(sonidoAlClickear);
            ren.sprite = spriteRenNormal;
            ren.color = mouseSobreRen ? colorAlPasarCursor : colorOriginal;
        }
    }

public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PasarCiudad"))

        {
            Entro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PasarCiudad"))
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
        else
        {
            rect.position = posicionOriginal;
        }
    }
}
