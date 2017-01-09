using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLaserScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.localPosition += transform.right * -3f * Time.deltaTime;
        if (transform.localPosition.x < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
