using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProc : MonoBehaviour {

	public GameObject ground;
	public GameObject border;
	public GameObject player;

	private GameObject _playerObject;

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
		if(Input.GetMouseButtonDown(0) && Global.gameStatu == Global.GameStatu.Idle)
		{
			playerCreation();
		}

		if (Input.GetKey(KeyCode.Return) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			player.GetComponent<PlayerControl>().makeHeJump(2f);
		}
	}

	void playerCreation()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit))
		{
			if (hit.transform.IsChildOf(ground.transform))
			{
				if (_playerObject == null) 
				{
					_playerObject = ObjectCreator.createPrefabs("player", player, "player");
				}

				_playerObject.transform.position = hit.transform.position;
			}
		}
	}
}
