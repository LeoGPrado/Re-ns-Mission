using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MedidorArteEspecial : MonoBehaviour
{
    [SerializeField] PlayerEnergyController playerMana;

    [Header ("Config Maná")]
    //[SerializeField] private float displayedMana = 0f;
    //[SerializeField] private float smoothSp = 4f;
    [SerializeField] public bool canUseUltimate = false;

    [Header("Cooldown")]

    [SerializeField] private float cdTime = 10f;
    [SerializeField] private bool isOnCooldown = false;
    [SerializeField] private float cdTimer = 0f;

    [Header("Interfaz")]

    [SerializeField] private Image UltimateC;                               //relleno
    [SerializeField] private Image ultCooldownOverlay;                              //enfriamiento
    [SerializeField] private TextMeshProUGUI cdText;
    [SerializeField] private TextMeshProUGUI ultReady;

    [Header("VFX")]

    [SerializeField] [Range(0f, 1f)] private float notChargedUlt = 0.3f;                                     // Opacidad cuando no está cargada la ulti
    [SerializeField] [Range(0f, 1f)] private float chargedUlt = 1f;                                          // Opacidad cuando está cargada la ulti
    [SerializeField] private float fadeSp = 5f;                                     //Vel. transición visual

    [SerializeField] private float targetAlpha;                                     //A que alpha debe llegar


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //UltimateC.anchorMin = new Vector2(0f, 0f);
        //UltimateC.anchorMax = new Vector2(1f, 0f);
        //UltimateC.pivot = new Vector2(0.5f, 0f);

        targetAlpha = notChargedUlt;
        SetAlpha(notChargedUlt);

        if (ultCooldownOverlay)
        {
            ultCooldownOverlay.type = Image.Type.Filled;
            ultCooldownOverlay.fillMethod = Image.FillMethod.Vertical;
            ultCooldownOverlay.fillOrigin = (int)Image.OriginVertical.Top; //La transparencia sea de arriba hacia abajo, contraria al llenado
            ultCooldownOverlay.fillAmount = 0;
        }

        if (cdText)
        {
            cdText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMana) return;

        UpdateVisuals();
        UltCooldown();
        AlphaVfx();

        if (playerMana.energycharged && !isOnCooldown)
        {
            CanUseWeaponArt();
            ControlDeAnimacionesArmas.ControlEspecial.usarEspecial();
            ultReady.gameObject.SetActive(true);
        }
        else
            ultReady.gameObject.SetActive(false);

        if (playerMana.usedUltimate == true)
        {
            StartCD();
        }
    }

    void UpdateVisuals()
    {
        
        float fillProgress = Mathf.Clamp01(playerMana.currentMana / playerMana.maxMana);
        UltimateC.fillAmount = fillProgress;
    }

    void UltCooldown()
    {
        if (isOnCooldown)
        {
            cdTime -= Time.deltaTime;
            canUseUltimate = false;

            if (ultCooldownOverlay) ultCooldownOverlay.fillAmount = Mathf.Clamp01(cdTimer / cdTime);

            if (cdText)
            {
                cdText.gameObject.SetActive(true);
                int cooldownLeft = Mathf.CeilToInt(cdTimer);
                cdText.text = cooldownLeft.ToString();
            }

            if(cdTimer <= 0)
            {
                playerMana.usedUltimate = false;
                isOnCooldown = false;
                if (ultCooldownOverlay) ultCooldownOverlay.fillAmount = 0;
                if (cdText) cdText.gameObject.SetActive(false);
            }
        }
    }

    void AlphaVfx()
    {
        if (playerMana.currentMana >= playerMana.maxMana && !isOnCooldown)
        {
            targetAlpha = chargedUlt;
        }
        else targetAlpha = notChargedUlt;

        Color c = UltimateC.color;
        float newA = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * fadeSp);
        SetAlpha(newA);
    }

    void SetAlpha(float alpha)
    {
        Color c = UltimateC.color;
        c.a = alpha;
        UltimateC.color = c;
    }

    //Método para el uso de la ulti
    public void CanUseWeaponArt()
    {


        //Debug.Log("Lanzar ulti");
        //playerMana.currentMana = 0;
        //StartCD();
        canUseUltimate = true;
            



        
    }

    public void StartCD()
    {

        //isOnCooldown = true;
        //cdTimer = cdTime;

       
        
           isOnCooldown = true;
           cdTimer = cdTime;
        
        
    }

}
