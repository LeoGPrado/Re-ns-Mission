using UnityEngine;

public class ManáParticlePc : MonoBehaviour
{

    //[SerializeField] private Transform target;
    //[SerializeField] private float speed = 4f;
    //[SerializeField] private float acceleration = 8f;
    //[SerializeField] private float collectDistance = 0.5f;
    //[SerializeField] private bool isMoving = false;

    [SerializeField] private float particleSpeed = 8f;
    [SerializeField] private float particleAcce = 12f;
    [SerializeField] private float Delay = 0.3f;

    //vfx
    //[SerializeField] private AudioClip PickUpsfx;
    [SerializeField] private float lifeTime = 5f;

    //Fuerza Inicial
    [SerializeField] private float initialForce = 2f;


    [SerializeField] private Transform player;
    [SerializeField] private bool isMoving;
    [SerializeField] private float delayTimer = 0f;
    [SerializeField] private Vector2 currentParticleVel;
    [SerializeField] private PlayerEnergyController pEnergy;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("protagonista").transform;
        pEnergy = GameObject.FindAnyObjectByType<PlayerEnergyController>();
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 randomDir = Random.insideUnitCircle.normalized * Random.Range(0.5f, 1f);
            rb.AddForce(randomDir * initialForce, ForceMode2D.Impulse);
        }
        

        Destroy(gameObject, lifeTime);

    }

    void Update()
    {
        if (player == null) return;
        
        delayTimer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);

        if(!isMoving && delayTimer >= Delay && distance < 8f)
        {
           isMoving = true;
        }

        if (isMoving)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            currentParticleVel = Vector2.Lerp(currentParticleVel, direction * particleSpeed, Time.deltaTime * particleAcce);
            transform.Translate(currentParticleVel * Time.deltaTime);


        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ManaCollider"))
        {
            pEnergy.ManaCharge();

            //if (PickUpsfx)
            //{
            //    AudioSource.PlayClipAtPoint(PickUpsfx, transform.position);
            //}

            Destroy(gameObject);

        
        }
    }
}
