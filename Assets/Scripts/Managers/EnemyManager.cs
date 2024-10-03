using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField] EnemyCurrentAndMaxCounts enemiesCounts; // Scriptable Object
    [SerializeField] PlayerStats stats; // Scriptable Object


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
        enemiesCounts.currentCount = 0;
    }

    /*void Update()
    {

    }*/


    void Spawn ()
    {
        if(stats.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        if(enemiesCounts.currentCount < enemiesCounts.maxCount)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemiesCounts.currentCount++;
        }
    }
}
