﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spin : Ball_Base
{
	float rotateSpeed = 1f;
	float angleX, angleY;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.forward * rotateSpeed);
		transform.Translate(Vector3.right * speed);
		if (speed > 1f)
		{
			speed = speed - (speed * Time.deltaTime * 0.1f);
		}
		else if (speed > 0)
		{
			speed = speed - 0.1f;
		}
		else
		{
			speed = 0;
		}
	}
}
