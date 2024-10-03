using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    Rigidbody rb;
    NavMeshAgent agent;

    [SerializeField] EnemyCurrentAndMaxCounts enemiesCounts; // Scriptable Object
    [SerializeField] ScoreCounter currentScore; // Scriptable Object

    int id_dead = Animator.StringToHash("Dead");

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        rb = GetComponent <Rigidbody> ();
        agent = GetComponent <NavMeshAgent> ();
        currentHealth = startingHealth;

    }


    void Update ()
    {
        if(isSinking)
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
            Death ();
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        //anim.SetTrigger ("Dead");
        anim.SetTrigger(id_dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();

        enemiesCounts.currentCount--;
    }

    /*public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.updateScore(scoreValue);
        Destroy (gameObject, 2f);
    }*/

    public void StartSinking ()
    {
        agent.enabled = false;
        rb.isKinematic = true;
        isSinking = true;
        currentScore.score += scoreValue;
        FindObjectOfType<ScoreManager>().updateScore();
        Destroy (gameObject, 2f);
    }
}
