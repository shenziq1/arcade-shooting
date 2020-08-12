using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemy;
    
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
        Instantiate(enemy, transform.position + new Vector3(Random.Range(0.0f, 20.0f), 0.5f, Random.Range(0.0f, 10.0f)), enemy.transform.rotation);    
    }
}
