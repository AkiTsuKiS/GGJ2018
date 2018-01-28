using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour {
	public GameObject goodZone;
	public GameObject greatZone;
	public GameObject groundUpper;

	// Use this for initialization
	void Start () {
		goodZone = GameObject.Find("GoodZone");
		greatZone = GameObject.Find("GreatZone");
		groundUpper = GameObject.Find("Ground_upper");
		goodZone.SetActive(false);
		greatZone.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// return count of [Good, Great, Excellent]
	public List<int> startCountScore()
	{
		goodZone.SetActive(true);
		greatZone.SetActive(true);

		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		BoxCollider groundBox = groundUpper.GetComponent<BoxCollider>();
		CapsuleCollider greatZoneBox = greatZone.GetComponent<CapsuleCollider>();
		CapsuleCollider goodZoneBox = goodZone.GetComponent<CapsuleCollider>();
		List<int> ret = new List<int>() { 0, 0, 0};
		foreach (GameObject ball in balls)
		{
			SphereCollider ballSphere = ball.GetComponent<SphereCollider>();
			// Check if not table, continue
			if (!ballSphere.bounds.Intersects(groundBox.bounds))
			{
				Debug.Log(ball + " is not on table");
				continue;
			}
			// Check if not in great zone => excellent
			if (!ballSphere.bounds.Intersects(greatZoneBox.bounds))
			{
				ret[2]++;
				continue;
			}
			// Check if not in good zone => great zone
			if (!ballSphere.bounds.Intersects(goodZoneBox.bounds))
			{
				ret[1]++;
				continue;
			}
			// else => good
			ret[0]++;
		}
		return ret;
	}
}
