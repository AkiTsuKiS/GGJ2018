using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spin : Ball_Base
{
	float rotateSpeed = 1f;
	float angleX, angleY;
	Sprite twister;
	// Use this for initialization
	void Start()
	{
		twister = Resources.Load<Sprite>("Image/twister");
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.forward * rotateSpeed);
		transform.Translate(Vector3.right * speed * 0.2f);
		if (speed > 10f)
		{
			
		}
		else if (speed > 0)
		{
			speed = speed + 0.1f;
		}
		if (speed > 0)
		{
			rotateSpeed = Global.ratio * 0.3f;
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = twister;
			Destroy(gameObject, 5f);
		}
	}
}
