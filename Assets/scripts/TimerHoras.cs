using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerHoras : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int hour = 0;
    [SerializeField] private int minutos = 0;
    [SerializeField] private float cdTimer = 30f;
    [SerializeField] public GameObject parentSpawners;
    public Transform parentEnemy;
    private int cantidadEnemigos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTime();
        StartCoroutine(UpdateEvery30s());
    }

    // Update is called once per frame
    void Update()
    {
        cantidadEnemigos = parentEnemy.childCount;
    }

    IEnumerator UpdateEvery30s()
    {
        while (hour <= 60)
        {
            if (hour == 60)
            {
                hour = 0;
                minutos += 1;

                if (minutos >= 6)
                {
                    Destroy(parentSpawners);

                }
                UpdateTime();

            }

            yield return new WaitForSeconds(cdTimer);
            hour += 30;

            if (cantidadEnemigos <= 0)
            {
                SceneManager.LoadScene("FinDemo");
            }

            UpdateTime();
        }

    }

    void UpdateTime()
    {
        timerText.text = minutos.ToString("00") + hour.ToString(":00");
    }
}
