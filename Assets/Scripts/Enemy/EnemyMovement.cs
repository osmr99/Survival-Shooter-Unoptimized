using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
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

    private void FixedUpdate()
    {
        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
            GetComponent<NavMeshAgent>().SetDestination(player.position);
        else
            GetComponent<NavMeshAgent>().enabled = false;
    }
}
