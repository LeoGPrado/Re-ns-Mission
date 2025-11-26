using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerHoras : MonoBehaviour
{

    [Header("Cambio de luna a sol")]
    [SerializeField] private Image iconoUI;
    [SerializeField] private Sprite solSprite;
    [SerializeField] private float duracionDelFade = 0.5f;
    private bool lunaASol = false;
    [Space(10)]


    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public int hour = 0;
    [SerializeField] public int minutos = 0;
    [SerializeField] private float cdTimer = 30f;
    [SerializeField] public string SiguienteEscena;

   
   
  

    [SerializeField] public GameObject parentSpawners;
    public Transform parentEnemy;
    private int cantidadEnemigos;

    void Start()
    {
        UpdateTime();
        StartCoroutine(UpdateEvery30s());
    }

    void Update()
    {
        cantidadEnemigos = parentEnemy.childCount;

        if (cantidadEnemigos <= 0 && minutos==4)
        {
            SceneManager.LoadScene(SiguienteEscena);
        }
    }

    IEnumerator UpdateEvery30s()
    {
        while (hour <= 60)
        {
            if (hour == 60)
            {
                hour = 0;
                minutos += 1;

                if (minutos == 4)
                {

                    parentSpawners.SetActive(false);

                }
                Debug.Log(cantidadEnemigos);
                UpdateTime();

            }


            yield return new WaitForSeconds(cdTimer);

            if (minutos != 4)
            {
                hour += 30;          

                UpdateTime();
            }
            else
            {
                break;
            }

          
        }

    }

    void UpdateTime()
    {
        timerText.text = minutos.ToString("00") + hour.ToString(":00") + " AM";

        if (minutos == 1 && !lunaASol)
        {
            StartCoroutine(CambiarASol(solSprite));
        }

    }


    IEnumerator CambiarASol(Sprite solSprite)
    {
        for (float t = 0; t < duracionDelFade; t += Time.deltaTime)
        {
            float alpha = 1 - (t / duracionDelFade);
            iconoUI.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        iconoUI.color = new Color(1, 1, 1, 0);
        iconoUI.sprite = solSprite;
        
        for (float t = 0; t < duracionDelFade; t += Time.deltaTime)
        {
            float alpha = t / duracionDelFade;
            iconoUI.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        iconoUI.color = Color.white;
    }



}
