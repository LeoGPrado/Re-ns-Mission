using UnityEngine;

public class TUtorialEnemigo : MonoBehaviour
{
    public GameObject goblinTutorial;
  
    public void ApareceGoblin()
    {
        goblinTutorial.SetActive(true);
    }
}
