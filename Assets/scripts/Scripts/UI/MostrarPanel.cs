using UnityEngine;

public class MostrarPanel : MonoBehaviour
{
    public Animator panelMenuInicio;
    public bool verificar = true;

    public void mostrarPanel()
    {
        if (verificar == true)
        {
            panelMenuInicio.SetTrigger("MostrarP");
            verificar = false;
        }
        else
        {
            panelMenuInicio.SetTrigger("OcultarP");
            verificar=true;
        }
    }


}
