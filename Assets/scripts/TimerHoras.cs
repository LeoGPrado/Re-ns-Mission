using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerHoras : MonoBehaviour
{
    [Header("Cambio de luna a sol")]
    [SerializeField] private Image lunaUI;
    [SerializeField] private Image solUI;
    [SerializeField] private float duracionTransicion = 2f;
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

        solUI.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        cantidadEnemigos = parentEnemy.childCount;

        if (cantidadEnemigos <= 0 && minutos == 6)
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

                if (minutos == 6)
                {
                    parentSpawners.SetActive(false);
                }

                UpdateTime();
            }

            yield return new WaitForSeconds(cdTimer);

            if (minutos != 6)
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

        if (minutos == 6 && !lunaASol)
        {
            lunaASol = true;
            StartCoroutine(TransicionLunaASol());
        }
    }

    IEnumerator TransicionLunaASol()
    {
        float t = 0f;

        Vector3 posicionInicialLuna = lunaUI.rectTransform.localPosition;
        Vector3 posicionInicialSol = solUI.rectTransform.localPosition;


        while (t < duracionTransicion)
        {
            t += Time.deltaTime;
            float cambio = t / duracionTransicion;

            lunaUI.rectTransform.localPosition = posicionInicialLuna + new Vector3(0, cambio * 75f, 0);
            solUI.rectTransform.localPosition = posicionInicialSol + new Vector3(0, cambio * 75f, 0);

            lunaUI.color = new Color(1, 1, 1, 1 - cambio);
            solUI.color = new Color(1, 1, 1, cambio);

            yield return null;
        }

        lunaUI.color = new Color(1, 1, 1, 0);
        solUI.color = Color.white;
    }
}