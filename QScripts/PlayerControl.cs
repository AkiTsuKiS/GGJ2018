using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public Sprite normal;
	public Sprite jumping;
	public Sprite landed;
	public float animationTime = 3.0f;
	float currentAnimationTime = 0.0f;
	float landedTime = 0.0f;
	string state = "normal";
	bool isJumping = false;
	Vector3 originalScale;
	Vector3 targetScale;

	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale;
	//	normal = Resources.Load("Image/player_normal") as Sprite;
	//	jumping = Resources.Load("Image/player_jumping") as Sprite;
	//	landed = Resources.Load("Image/player_jumped") as Sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if (isJumping)
		{
			currentAnimationTime += Time.deltaTime;
			if (currentAnimationTime >= animationTime)
			{
				currentAnimationTime = 0;
				isJumping = false;
				state = "landed";
				GetComponent<SpriteRenderer>().sprite = landed;
			}
			else
			{
				transform.localScale = originalScale +
					(targetScale - originalScale) 
					* Mathf.Sin(
						currentAnimationTime / animationTime * Mathf.PI
						);

				Debug.Log("currentScale" + transform.localScale);
			}
		}
		if (state == "landed")
		{
			landedTime += Time.deltaTime;
			if (landedTime >= 2.0f)
			{
				landedTime = 0;
				state = "normal";
				GetComponent<SpriteRenderer>().sprite = normal;
				
			}
		}
	}

	public void makeHeJump(float power)
	{
		if (!state.Equals("normal"))
		{
			return;
		}
		print("P" + power);

		GetComponent<SpriteRenderer>().sprite = jumping;
		state = "jumping";
		isJumping = true;
		targetScale = originalScale + originalScale * power;
		Debug.Log("targetScale" + targetScale);
	}
}
