using UnityEngine;
using UnityEngine.UI;

public class ArastrarREn : MonoBehaviour
{

    [Header("Sprites de Ren")]
    [SerializeField] private Sprite spriteRenNormal;
    [SerializeField] private Sprite spriteRenClickeado;
    [Space (10)]

    [Header("Cursor del nivel")]
    [SerializeField] private Texture2D cursorNuevo;
    [SerializeField] private Vector2 posicionMouse = Vector2.zero;
    [SerializeField] private Color colorAlPasarCursor;
    [SerializeField] private float alphaAlClickear = 0.5f;
    [Space(10)]

    [Header("Aca pon tus cosos Hernando pa tener orden")]
    [Space(10)]



    [Header("Audios")]
    [SerializeField] private AudioClip sonidoAlClickear;
    [Space(10)]

    private Image ren;
    private RectTransform rect;
    [Space(10)]

    private bool mouseSobreRen = false;
    private Color colorOriginal;
   

    void Start()
    {
        Cursor.SetCursor(cursorNuevo, posicionMouse, CursorMode.Auto);

        ren = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        colorOriginal = ren.color;     
    }

    void Update()
    {
        Vector2 mouse = Input.mousePosition;
        bool ahoraSobreRen = RectTransformUtility.RectangleContainsScreenPoint(rect, mouse);
       
        if (ahoraSobreRen && !mouseSobreRen)
        {
            mouseSobreRen = true;
            ren.color = colorAlPasarCursor;
        }
        else if (!ahoraSobreRen && mouseSobreRen)
        {
            mouseSobreRen = false;
            ren.color = colorOriginal;
        }

        if (Input.GetMouseButtonDown(0) && ahoraSobreRen)
        {
            ren.sprite = spriteRenClickeado;

            Color color = ren.color;
            color.a = alphaAlClickear;
            ren.color = color;

            GetComponent<AudioSource>().PlayOneShot(sonidoAlClickear);

            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.visible = true;
            GetComponent<AudioSource>().PlayOneShot(sonidoAlClickear);
            ren.sprite = spriteRenNormal;
            ren.color = mouseSobreRen ? colorAlPasarCursor : colorOriginal;
        }
    }
}