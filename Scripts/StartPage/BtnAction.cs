using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnAction : MonoBehaviour
{
	void ChangeScene()
	{
		SceneManager.LoadScene("Level1");
	}
}