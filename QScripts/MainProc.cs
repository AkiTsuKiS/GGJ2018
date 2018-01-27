using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProc : MonoBehaviour {

	public GameObject ground;
	public GameObject border;
	public GameObject player;
	public Button startButton;
	private GameObject _playerObject;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		Global.playerX = 0f;
		Global.playerZ = 0f;
		Global.ratio = 0f;
		Global.gameStatu = Global.GameStatu.Idle;
		startButton.gameObject.SetActive(false);
		startButton.interactable = false;
		StartCoroutine(ContinueCheckScore());
	}

	IEnumerator ContinueCheckScore()
	{
		while (true)
		{
			List<int> scores = GameObject.Find("BallLayer").GetComponent<CountScore>().countScore();
			Debug.Log("Scores now : " + scores[0] + " " + scores[1] + " " + scores[2]);
			yield return new WaitForSeconds(1);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0) && Global.gameStatu == Global.GameStatu.Idle)
		{
			playerCreation();
			if (_playerObject)
			{
				startButton.interactable = true;
				startButton.gameObject.SetActive(true);
			}
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
				Vector3 generate = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
				if (_playerObject == null) 
				{
					_playerObject = ObjectCreator.createPrefabs("player", player, "player");
				}

				_playerObject.transform.position = new Vector3(generate.x, 100f, generate.z);
			}
		}
	}

	public void onClickStart()
	{
		Global.playerX = _playerObject.transform.position.x;
		Global.playerZ = _playerObject.transform.position.z;

		Global.gameStatu = Global.GameStatu.Recording;
		startButton.interactable = false;
		StartCoroutine(startRecord());
	}

	IEnumerator startRecord()
	{
		yield return new WaitForSeconds(0.5f);
		MicrophoneHandler.StartRecord();
		print("start Record");
		StartCoroutine(stopRecord());
	}

	IEnumerator stopRecord()
	{
		yield return new WaitForSeconds(1.5f);
		startButton.gameObject.SetActive(false);
		MicrophoneHandler.StopRecord();
		Global.ratio =  MicrophoneHandler.GetHighestRatio();
		print("stop Record + " + Global.ratio);
		playerJump();
	}

	void playerJump()
	{
		print("playerJump");

		Global.gameStatu = Global.GameStatu.Jumping;
		_playerObject.GetComponentInChildren<PlayerControl>().makeHeJump(Global.ratio * 2f);
		MicrophoneHandler.ReplayRecord();
	}
}
