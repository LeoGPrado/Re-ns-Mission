using System.Collections;
using UnityEngine;

public class PlayerEnergyController : MonoBehaviour
{

    


    public MedidorArteEspecial ultimate;
    public float maxMana = 100f;
    public float currentMana;
    public float manaPerParticle = 5f;
    public float baseMana = 0f;
    public bool usedUltimate = false;
    public bool energycharged = false;
    public bool canObtainMana = true;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
              
        currentMana = baseMana;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(currentMana >= maxMana)
        {
            energycharged = true;

        }
    }

    public void ManaCharge()
    {
        if (canObtainMana)
        {
            currentMana += manaPerParticle;
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        }
        
    }

    public void ConsumeMana()
    {
        currentMana = 0;
    }


    public void Ultimate()
    {
    
        energycharged = false;
        usedUltimate = true;
        currentMana = baseMana;


    }

    


}
