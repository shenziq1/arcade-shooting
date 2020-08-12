using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public float enemySpeed = 2.0f;
    private float initialXDirection;
    private float initialZDirection;

    // Start is called before the first frame update
    void Start()
    {
        initialXDirection = Random.Range(-0.5f, 0.5f);
        initialZDirection = Random.Range(-0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(initialXDirection, 0.5f, initialZDirection) * enemySpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            SpawnController spawn = GameObject.Find("SpawnPoint").GetComponent<SpawnController>();
            spawn.enemyCount--;
            Destroy(gameObject);

        }
        else if (collision.gameObject.name == "Player") 
        {
            Destroy(collision.gameObject);
        }

    }

}
