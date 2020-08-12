using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() 
    {
        Vector3 playerPosition = GameObject.Find("Player").GetComponent<PlayerController>().playerPosition;
        Vector3 temperPoint = transform.position + new Vector3(Random.Range(0.0f, 20.0f), 0.5f, Random.Range(0.0f, 10.0f));
        while (Vector3.Distance(temperPoint, playerPosition) < 3) 
        { 
            temperPoint = transform.position + new Vector3(Random.Range(0.0f, 20.0f), 0.5f, Random.Range(0.0f, 10.0f));
        }

        if (enemyCount < 50)
        {
            Instantiate(enemy, temperPoint, enemy.transform.rotation);
            enemyCount++;
        }

    }
}
