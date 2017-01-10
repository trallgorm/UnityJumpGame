using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    public GameObject laser;
    public GameObject bottomlaser;
    public GameObject leftlaser;
    public GameObject rightlaser;
    public float spawnTime = 1f;
    public float spawnTime1 = 1f;
    public float spawnTime2 = 1f;
    public float spawnTime3 = 1f;
    public Text HPText;
    private int HP=10;
    private float maxTime = 6f;
    private float minTime = 4f;
    private float time=0;
    private float time1 = 0;
    private float time2 = 0;
    private float time3 = 0;
    private int totaltime = 0;

    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);
        spawnTime1 = Random.Range(minTime, maxTime);
        spawnTime2 = Random.Range(minTime, maxTime);
        spawnTime3 = Random.Range(minTime, maxTime);
        rb = GetComponent<Rigidbody>();
        HPText.text = "HP: " + HP.ToString() +" Score: " + (totaltime / 100).ToString();
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
            if (rb.position.y < 1 && rb.position.y > -1)
            {
                rb.AddForce(Vector3.up * 400f);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(Vector3.down * 800f);
        }
        if (Input.GetKey("escape"))
            Application.Quit();

        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            SpawnLaser();
            spawnTime = Random.Range(minTime, maxTime);
        }

        time1 += Time.deltaTime;
        if (time1 >= spawnTime1)
        {
            SpawnBottomLaser();
            spawnTime1 = Random.Range(minTime, maxTime);
        }

        time2 += Time.deltaTime;
        if (time2 >= spawnTime2)
        {
            SpawnLeftLaser();
            spawnTime2 = Random.Range(minTime, maxTime);
        }

        time3 += Time.deltaTime;
        if (time3 >= spawnTime3)
        {
            SpawnRightLaser();
            spawnTime3 = Random.Range(minTime, maxTime);
        }
        totaltime += 1;
        HPText.text = "HP: " + HP.ToString() + " Score: " + (totaltime/100).ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            HP -= 1;
            if (HP < 1)
            {
                Application.Quit();
            }
            HPText.text = "HP: " + HP.ToString() + " Score: " + (totaltime / 100).ToString();
            Destroy(other.gameObject);
        }
    }
    void SpawnLaser()
    {
        time = 0;
        var position = new Vector3(-20.58f, 0.5f, 0);
        var newLaser = GameObject.Instantiate(laser, position, Quaternion.identity);
        newLaser.SetActive(true);
    }
    void SpawnBottomLaser()
    {
        time1 = 0;
        var position = new Vector3(20.58f, 0.5f, 0);
        var newLaser = GameObject.Instantiate(bottomlaser, position, Quaternion.identity);
        newLaser.SetActive(true);
    }
    void SpawnLeftLaser()
    {
        time2 = 0;
        var position = new Vector3(0, 0.5f, -20.5f);
        var newLaser = GameObject.Instantiate(leftlaser, position, Quaternion.Euler(0, 90, 0));
        newLaser.SetActive(true);
    }
    void SpawnRightLaser()
    {
        time3 = 0;
        var position = new Vector3(0, 0.5f, 20.5f);
        var newLaser = GameObject.Instantiate(rightlaser, position, Quaternion.Euler(0, 90, 0));
        newLaser.SetActive(true);
    }
}

//references
// http://answers.unity3d.com/questions/398607/spawn-after-every-5-seconds.html
//https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/moving-camera?playlist=17141
//http://answers.unity3d.com/questions/898380/spawning-an-object-at-a-random-time-c.html