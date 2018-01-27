using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldWave : MonoBehaviour {
	float waveSize;
	// Use this for initialization
	void Start () {
		GetComponent<Animator>().Play("GoldWave", -1, 0);
		waveSize = Global.ratio * Time.deltaTime * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(waveSize < Global.ratio)
		{
			waveSize += Global.ratio * Time.deltaTime * 2f;
			transform.localScale = Vector3.one * waveSize;
			GetComponent<SphereCollider>().radius = (250f * Global.ratio) * waveSize;
		}
	}

	void DestroyObj()
	{
		Destroy(gameObject);
	}
}
