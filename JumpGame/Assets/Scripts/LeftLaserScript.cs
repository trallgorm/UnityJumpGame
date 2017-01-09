using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLaserScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += transform.right * -3f * Time.deltaTime;
        if (transform.localPosition.z > 20)
        {
            Destroy(this.gameObject);
        }
    }
}
