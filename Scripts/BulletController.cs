using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    private Vector3 bulletDirection;
    private int collitionCount = 0;
    public Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        PlayerController player = GameObject.Find("Player").GetComponentInParent<PlayerController>();
        bulletDirection = player.bulletDirection;
        gameObject.name = "bullet";
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        rb.velocity = bulletDirection * bulletSpeed;
        if (collitionCount >= 4) 
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        bulletDirection = bulletDirection.magnitude * Vector3.Reflect(bulletDirection.normalized, collision.contacts[0].normal);
        collitionCount += 1;
    }
}

