using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private float segundos;

    // Update is called once per frame
    private void Update()
    {
        if(segundos<=-1) return;

        if (segundos == 10)
        {
            segundos += Time.deltaTime*10;
        }

        segundos +=Time.deltaTime;
        int minuto = (int)segundos / 60;
        int segundo=(int)segundos % 60;

        string format = "{0:00}:{1:00}";

        textUI.SetText(format, minuto, segundo);
    }
}
