﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	void Awake()
	{
		Instance.gameProc = new GameProc();
	}

	void Start ()
	{
		Instance.gameProc.enable();
	}
	
	void Update ()
	{	
	}
}
