using UnityEngine;

public class TutoriaSeleccionArmas : MonoBehaviour
{
    public GameObject ArmaDistacia;
    public GameObject ArmaCuerpoACuerpo;

    public GameObject selectorArmas;

    public void ActivarArmaDistacia()
    {
        ArmaDistacia.SetActive(true);
        selectorArmas.SetActive(false);
        TutorialDialogos.ActivarTutorialDialogosScript.ActivarScriptAtacque();
    }
    public void activarArasCuerpoACuerpo()
    {
        ArmaCuerpoACuerpo.SetActive(true);
        selectorArmas.SetActive(false);
        TutorialDialogos.ActivarTutorialDialogosScript.ActivarScriptAtacque();
    }
}
