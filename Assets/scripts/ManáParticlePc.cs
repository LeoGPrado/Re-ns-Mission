using UnityEngine;

public class ManáParticlePc : MonoBehaviour
{

    //[SerializeField] private Transform target;
    //[SerializeField] private float speed = 4f;
    //[SerializeField] private float acceleration = 8f;
    //[SerializeField] private float collectDistance = 0.5f;
    //[SerializeField] private bool isMoving = false;

    [SerializeField] private float particleSp = 5f;
    [SerializeField] private float particleAcce = 8f;
    [SerializeField] private float Delay = 0.3f;

    //vfx
    //[SerializeField] private AudioClip PickUpsfx;
    [SerializeField] private float lifeTime = 5f;

    [SerializeField] private Transform player;
    [SerializeField] private bool isMoving;
    [SerializeField] private float delayTimer = 0f;
    [SerializeField] private Vector2 currentParticleVel;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(gameObject, lifeTime);

    }

    void Update()
    {
        if (player == null) return;
        
        delayTimer += Time.deltaTime;

        if(!isMoving && delayTimer >= Delay)
        {
           isMoving = true;
        }

        if (isMoving)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            currentParticleVel = Vector2.Lerp(currentParticleVel, direction * particleSp, Time.deltaTime * particleAcce);
            transform.Translate(currentParticleVel * Time.deltaTime);


        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerEnergyController>().ManaCharge();

            //if (PickUpsfx)
            //{
            //    AudioSource.PlayClipAtPoint(PickUpsfx, transform.position);
            //}

            Destroy(gameObject);

        
        }
    }
}
