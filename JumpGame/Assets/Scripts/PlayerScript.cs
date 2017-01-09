using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    public GameObject laser;
    public float spawnTime = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("SpawnLaser", spawnTime, spawnTime);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (rb.position.y < 1)
            {
                rb.AddForce(Vector3.up * 400f);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(Vector3.down * 800f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
        }
    }
    void SpawnLaser()
    {
        var position = new Vector3(-20.58f, 0.5f, 0);
        var newLaser = GameObject.Instantiate(laser, position, Quaternion.identity);
        newLaser.SetActive(true);
    }
}

//references
// http://answers.unity3d.com/questions/398607/spawn-after-every-5-seconds.html
//https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/moving-camera?playlist=17141