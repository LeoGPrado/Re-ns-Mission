using UnityEngine;

public class SelecconDeArmas : MonoBehaviour
{
    [SerializeField] private Transform Manos;
    [SerializeField] private GameObject[] armas;
  
    public void seleccionarArma(int index)
    {
        if (Manos.childCount > 0)
        {
            Destroy(Manos.GetChild(0).gameObject);
        }

        Transform weapon= Instantiate(armas[index] ,Manos).transform;
        weapon.localPosition = Vector3.zero;
    }
}
