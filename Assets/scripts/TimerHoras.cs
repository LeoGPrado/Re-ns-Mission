using UnityEngine;
using TMPro;
using System.Collections;

public class TimerHoras : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int hour = 0;
    [SerializeField] private float cdTimer = 30f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTime();
        StartCoroutine(UpdateEvery30s());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateEvery30s()
    {
        while (hour < 6)
        {
            yield return new WaitForSeconds(cdTimer);
            hour++;

            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timerText.text = hour.ToString("00") + ":00";
    }
}
