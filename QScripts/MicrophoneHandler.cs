using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneHandler : MonoBehaviour
{
	//*****************************************************//
	//** STATIC *******************************************//
	//*****************************************************//
	private static MicrophoneHandler _instance = null;

	private static void init()
	{
		if (_instance == null) 
			_instance = GameObject.Find("MicrophoneHandler").GetComponent<MicrophoneHandler>();
	}

	public static void StartRecord()
	{
		init();
		_instance.startRec();
	}

	public static void ReplayRecord()
	{

	}

	public static void GetVolume()
	{

	}
	//*****************************************************//

	private AudioSource _audioSource;

	public void startRec()
	{
		if (Microphone.IsRecording(null))
		{
			return;
		}
		else
		{
			_audioSource.clip = Microphone.Start(null, true, 1500, 44100);
		}
	}

	public void StopRec()
	{
		if (Microphone.IsRecording(null))
		{
			Microphone.End(null);
		}
	}

	public void ReplayRec()
	{
		_audioSource.Play();
	}

	private void Start()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
	}

	private void Update()
	{
	/*	if (Microphone.IsRecording(null))
		{
			_audioSource.clip
		}
		*/
	}
}
