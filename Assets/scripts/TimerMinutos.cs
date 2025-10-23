using UnityEngine;
using TMPro;
using System.Collections;

public class TimerMinutos : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI minutesText;
    [SerializeField] private float elpTime = 0f;
    [SerializeField] private bool timeIsRunning = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            elpTime += Time.deltaTime; //Aumentar el contador en tiempo real
            UpdateTimer();

            if(elpTime >= 180f)
            {
                timeIsRunning = false; //Detener el contador al llegar a 3 mins
                elpTime = 180f;
                UpdateTimer(); //Mostrar el tiempo exacto (3min)
            }
        }
    }

    void UpdateTimer()
    {
        //FloorToInt sirve para retornar el entero más grande menor o igual
        int min = Mathf.FloorToInt(elpTime / 60);           
        int sec = Mathf.FloorToInt(elpTime % 60);
        minutesText.text = $"{min:0}:{sec:00}";
    }








}
