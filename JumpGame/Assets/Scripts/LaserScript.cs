using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += transform.right * 10f * Time.deltaTime;
        if(transform.localPosition.x>20)
        {
            Destroy(this.gameObject);
        }
    }
}
