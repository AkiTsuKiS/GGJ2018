using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Explosion : MonoBehaviour {
	bool explosion = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag != "Ground" && !explosion)
		{
			GetComponent<Animator>().Play("Explosion", -1, 0);
			explosion = true;
		}
	}

	void DestroyObj()
	{
		Destroy(gameObject);
	}
}
