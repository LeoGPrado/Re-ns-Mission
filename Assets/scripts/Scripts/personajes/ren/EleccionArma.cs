using UnityEngine;

public class EleccionArma : MonoBehaviour
{
    [SerializeField] private SelecconDeArmas ren;

    public void SetWeapon(int index)
    {
        ren.seleccionarArma(index);
    }
}
