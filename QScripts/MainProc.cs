using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainProc : MonoBehaviour {

	public GameObject ground;
	public GameObject border;
	public GameObject player;
	public GameObject wave;
	public GameObject ball;
	public GameObject banner;
	public Button startButton;
	public Button restartButton;
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
		banner.SetActive(false);
		restartButton.gameObject.SetActive(false);
	}
	
	void Update()
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

		if(Global.gameStatu == Global.GameStatu.Explosion)
		{
			foreach(Ball_Straight bs in ball.GetComponentsInChildren<Ball_Straight>())
			{
				if (wave.transform.childCount > 0) return;
				if (bs.speed > 0) return;
			}

			showScore();
		}
	}

	void playerCreation()
	{
		if (EventSystem.current.currentSelectedGameObject) return;

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
		yield return new WaitForSeconds(2f);
		startButton.gameObject.SetActive(false);
		MicrophoneHandler.StopRecord();
		Global.ratio = MicrophoneHandler.GetHighestRatio() * 1.4f;
		print("stop Record + " + Global.ratio);
		playerJump();
	}

	void playerJump()
	{
		print("playerJump");

		Global.gameStatu = Global.GameStatu.Jumping;
		_playerObject.GetComponentInChildren<PlayerControl>().makeHeJump(Global.ratio * 2f);
		MicrophoneHandler.ReplayRecord();
		StartCoroutine(Explosion());
	}

	IEnumerator Explosion()
	{
		print("Explosion");
		yield return new WaitForSeconds(2.5f);
		GameObject _wave = ObjectCreator.createPrefabs("wave",wave,"wave");
		_wave.transform.position = new Vector3(Global.playerX, _wave.transform.position.y, Global.playerZ);
		Global.gameStatu = Global.GameStatu.Explosion;
	}

	void showScore()
	{
		Global.gameStatu = Global.GameStatu.Reward;
		List<int> scores = GameObject.Find("BallLayer").GetComponent<CountScore>().startCountScore();
		Global.Excellent = scores[2];
		Global.Great = scores[1];
		Global.Good = scores[0];
		Global.Fail = scores[3];
		banner.SetActive(true);
		GameObject.Find("excellentText").GetComponent<TextMesh>().text = Global.Excellent.ToString();
		GameObject.Find("greatText").GetComponent<TextMesh>().text = Global.Great.ToString();
		GameObject.Find("goodText").GetComponent<TextMesh>().text = Global.Good.ToString();
		GameObject.Find("failText").GetComponent<TextMesh>().text = Global.Fail.ToString();
		restartButton.gameObject.SetActive(true);
	}

	public void restart()
	{
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}
}
