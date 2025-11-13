using UnityEngine;

public class DeathScript : MonoBehaviour
{

    public int vida = 3;
    public SlieControl vidaSlime;
    public EsqueletoControl vidaEsque;
   
    [SerializeField] private GameObject manaPartícula;
    [SerializeField] private float manaParticleCount = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaSlime.VidaEnemigo < 1 || vidaEsque.VidaEnemigo < 1)
        {
            for(int i = 0; i < manaParticleCount; i++)
            {
                Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * 0.5f;
                Instantiate(manaPartícula, transform.position, Quaternion.identity);

            }


            
        }
    }
}
