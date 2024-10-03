using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public GameObject enemyPrefab; // bunny, bear, elephant
    public float spawnTime;
    public Transform[] spawnPoints;

    [SerializeField] PlayerStats stats; // Scriptable Object
    [SerializeField] EnemyCurrentAndMaxCounts enemyCap; // Scriptable Object, Overall enemy cap
    [SerializeField] int enemyAmount; // Max quantity of each enemy prefab that can spawn

    Queue<GameObject> enemyPrefabPool = new Queue<GameObject>();
    bool canSpawn = true;
    [SerializeField] int enemyID;

    /*void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }*/

    void Start()
    {
        enemyCap.currentCount = 0;
        enemyCap.nextEnemyID = 1;
        for(int i = 0; i < enemyAmount; i++)
        {
            var e = Instantiate(enemyPrefab);
            enemyPrefabPool.Enqueue(e);
            e.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Spawn();
    }


    /*void Spawn ()
    {
        if(stats.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        if(enemyCap.currentCount < enemyCap.maxCount)
        {
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCap.currentCount++;
        }
    }*/

    void Spawn()
    {
        if (enemyCap.currentCount < enemyCap.maxCount && canSpawn && enemyPrefabPool.Count > 0)
        {
            if(enemyCap.nextEnemyID == enemyID)
            {
                canSpawn = false;
                StartCoroutine(SpawnDelay());
                //int spawnPointIndex = Random.Range(0, spawnPoints.Length); // Every enemy only has 1 spawn location
                var current = enemyPrefabPool.Dequeue();
                current.gameObject.SetActive(true);
                current.GetComponent<EnemyHealth>().Spawn(spawnPoints, 0);
                enemyCap.currentCount++;
                enemyCap.nextEnemyID = Random.Range(1, 4);
            }
            else
            {
                enemyCap.nextEnemyID = Random.Range(1, 4);
            }

        }
    }

    public void AddAgainToQueue(GameObject e)
    {
        enemyPrefabPool.Enqueue(e);
        e.SetActive(false);
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
