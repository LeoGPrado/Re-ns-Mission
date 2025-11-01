using System.Collections;
using UnityEngine;

public class PlayerEnergyController : MonoBehaviour
{

    


    public MedidorArteEspecial ultimate;
    public float maxMana = 100f;
    public float currentMana;
    public float manaPerEnemy = 20f;
    public float baseMana = 0f;
    public bool usedUltimate = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
              
        currentMana = baseMana;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ultimate.canUseUltimate && Input.GetMouseButtonDown(1))
        {
            Ultimate();
        }
    }

    public void ManaCharge()
    {
        currentMana += manaPerEnemy;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
    }

    public void ConsumeMana()
    {
        currentMana = 0;
    }


    private void Ultimate()
    {
    
        
        usedUltimate = true;
        currentMana = baseMana;
            
        
    }

    


}
