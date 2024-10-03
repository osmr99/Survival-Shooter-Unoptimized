using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    int currentHP;
    NavMeshAgent agent;

    [SerializeField] PlayerStats stats; // Scriptable Object

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        currentHP = GetComponent<EnemyHealth>().currentHealth;
        agent = GetComponent<NavMeshAgent>();
    }

    /*private void Update ()
    {
        // Transform player = FindObjectOfType<PlayerMovement>().transform;
        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination (player.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }*/

    /*private void FixedUpdate()
    {
        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
            GetComponent<NavMeshAgent>().SetDestination(player.position);
        else
            GetComponent<NavMeshAgent>().enabled = false;
    }*/

    private void FixedUpdate()
    {
        if (currentHP > 0 && stats.currentHealth > 0 && agent.enabled)
            agent.SetDestination(player.position);
        else
            agent.enabled = false;
    }
}
