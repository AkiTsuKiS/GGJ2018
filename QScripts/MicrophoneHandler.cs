﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneHandler
{
	//*****************************************************//
	//** STATIC *******************************************//
	//*****************************************************//
	private static AudioSource _instance = null;

	private static void init()
	{
		if (_instance == null) 
			_instance = GameObject.Find("MicrophoneHandler").GetComponent<AudioSource>();
	}

	public static void StartRecord()
	{
		init();

		if (Microphone.IsRecording(null))
		{
			return;
		}
		else
		{
			_instance.clip = Microphone.Start(null, true, 10, 44100);
		}
	}

	public static void StopRecord()
	{
		if (Microphone.IsRecording(null))
		{
			Microphone.End(null);
		}
	}

	public static void ReplayRecord()
	{
		_instance.Play();
	}

	public static float[] GetSampleData()
	{
		float[] data = new float[_instance.clip.samples];
		_instance.clip.GetData(data, 0);

		return data;
	}

	//*****************************************************//
}
