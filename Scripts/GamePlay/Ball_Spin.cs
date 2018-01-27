using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spin : MonoBehaviour
{
	float rotateSpeed = 1f;
	float speed = 10f;
	float angleX, angleY;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.forward * rotateSpeed);
		transform.Translate(Vector3.right * speed);
		if (speed > 1f)
		{
			speed = speed - (speed * Time.deltaTime * 0.1f);
		}
		else if (speed > 0)
		{
			speed = speed - 0.1f;
		}
		else
		{
			speed = 0;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "BorderRow")
		{
				transform.rotation = Quaternion.Euler(new Vector3(90f, 0, -(180f - transform.eulerAngles.y) + 180f));
		}
		else if (collision.transform.tag == "BorderCol")
		{
			if (transform.eulerAngles.y > 270f && transform.eulerAngles.y < 360f)
			{
				transform.rotation = Quaternion.Euler(new Vector3(90f, 0, -(180f - transform.eulerAngles.y)));
			}
			else if(transform.eulerAngles.y > 0f && transform.eulerAngles.y < 90f || transform.eulerAngles.y > 180f && transform.eulerAngles.y < 270f || transform.eulerAngles.y > 90f && transform.eulerAngles.y < 180f)
			{
				transform.rotation = Quaternion.Euler(new Vector3(90f, 0, (transform.eulerAngles.y - 180f)));
			}
		}
		speed = speed - 0.5f;
	}
}
