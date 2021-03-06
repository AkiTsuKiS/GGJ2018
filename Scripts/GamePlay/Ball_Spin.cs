﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spin : Ball_Base
{
	float rotateSpeed = 0f;
	float angleX, angleY;
	Sprite twister;
	bool isMove = false;
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
		if (speed > 0 && !isMove)
		{
			isMove = true;
			if (Random.Range(0, 1000) < 500)
			{
				rotateSpeed = Global.ratio * 0.3f;
			}
			else
			{
				rotateSpeed = -Global.ratio * 0.3f;
			}
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = twister;
			AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sound/wind"), Camera.main.transform.position, 1f);
			Destroy(gameObject, 5f);
		}
		if (isMove)
		{
			transform.GetChild(0).localRotation = Quaternion.Euler(transform.GetChild(0).localRotation.x, transform.GetChild(0).localRotation.y, -transform.localRotation.eulerAngles.z + 90f);
		}
		if (transform.localPosition.z > 200f)
		{
			speed = 0;
		}
	}
}
