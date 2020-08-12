using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public GameObject bullet;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 playerDirection;
    public Vector3 bulletDirection;
    public Vector3 playerPosition;
    public Rigidbody rb;
    private int readyToShootCount = 0;

    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("Shoot", 0.0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerPosition = transform.position;
        playerDirection = Vector3.right * horizontalInput + Vector3.forward * verticalInput;
        GetBulletDirection();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            readyToShootCount += 1;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = playerDirection * playerSpeed;
    }

    bool ReadyToShoot()
    {
        if (readyToShootCount % 2 == 1) {
            return true;
        }
        return false;
    }
    
    void Shoot() 
    {
        if (ReadyToShoot())
        {
            if (playerDirection.magnitude != 0 && bulletDirection.magnitude != 0)
            {
                Instantiate(bullet, transform.position + bulletDirection * 0.75f, bullet.transform.rotation);
            }
        }
    }

    void GetBulletDirection() 
    {
        bulletDirection = playerDirection.normalized;
    }
}
