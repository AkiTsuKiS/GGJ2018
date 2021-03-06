﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_getObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
		{
			Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true);
			Debug.Log(hit.transform.name);
			if (hit.transform.name == "StartBtn")
			{
				hit.transform.GetComponent<Animator>().Play("ChangeScene", -1, 0);
				AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sound/click_menu_button"), Camera.main.transform.position);
			}
		}
	}
}
