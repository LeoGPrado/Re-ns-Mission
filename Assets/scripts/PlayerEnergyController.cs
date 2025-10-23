using System.Collections;
using UnityEngine;

public class PlayerEnergyController : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private bool canShoot;
    public Transform player;
    public GameObject prefabBala;
    public Vector2 direction;





    public MedidorArteEspecial ultimate;
    public GameObject enemy;
    public float maxMana = 100f;
    public float currentMana;
    public float manaPerEnemy = 20f;
    public float baseMana = 0f;
    public bool usedUltimate = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        cam = Camera.main;
        canShoot = true;
        currentMana = baseMana;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            Disparo();
        }

        if(ultimate.canUseUltimate && Input.GetKeyDown(KeyCode.R))
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

    private void Disparo()
    {
      
         Vector2 input = cam.ScreenToWorldPoint(Input.mousePosition);
         Vector2 direction = (input - (Vector2)(transform.position)).normalized;

         GameObject bala = Instantiate(prefabBala, player.position, Quaternion.identity);
         bala.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);

         canShoot = false;

         StartCoroutine(CdDisparo());
        
    }

    IEnumerator CdDisparo()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;

        

        
    }


 

    private void Ultimate()
    {
    
        Destroy(enemy);
        usedUltimate = true;
        currentMana = baseMana;
            
        
    }

    


}
