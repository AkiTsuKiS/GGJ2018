using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProc : MonoBehaviour {

	public GameObject ground;
	public GameObject border;
	public GameObject player;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		Global.playerX = 0f;
		Global.playerY = 0f;
		Global.radio = 0f;
		Global.gameStatu = Global.GameStatu.Idle;
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Input.GetKey(KeyCode.Return) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			player.GetComponent<PlayerControl>().makeHeJump(2f);
		}
	}
}
