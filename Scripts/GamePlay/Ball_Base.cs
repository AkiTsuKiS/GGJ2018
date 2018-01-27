using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Base : MonoBehaviour {
	public float speed = 0f;
	public float colSpeed;

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
			else if (transform.eulerAngles.y > 0f && transform.eulerAngles.y < 90f || transform.eulerAngles.y > 180f && transform.eulerAngles.y < 270f || transform.eulerAngles.y > 90f && transform.eulerAngles.y < 180f)
			{
				transform.rotation = Quaternion.Euler(new Vector3(90f, 0, (transform.eulerAngles.y - 180f)));
			}
			else
			{
				transform.rotation = Quaternion.Euler(new Vector3(90f, 0, (180f - transform.eulerAngles.y)));
			}
		}
		else if (collision.transform.tag == "Ball")
		{
			if (collision.transform.GetComponent<Ball_Base>().speed < 0.1f)
			{
				collision.transform.GetComponent<Ball_Base>().speed = speed;
				speed = speed / 10f;
				collision.transform.rotation = transform.rotation;
			}
			else
			{
				Vector3 targetDir = collision.transform.position - transform.position;
				float angle = Vector3.Angle(targetDir, transform.up);
				if (angle > 85f && angle < 95f)
				{
					transform.rotation = Quaternion.Euler(new Vector3(90f, 0, transform.eulerAngles.y + 180f));
				}
				else if (angle > 85f && angle < 130f)
				{
					transform.rotation = Quaternion.Euler(new Vector3(90f, 0, -(180f - transform.eulerAngles.y) + 180f));
				}
				else if (angle < 85f)
				{
					transform.rotation = Quaternion.Euler(new Vector3(90f, 0, transform.eulerAngles.y - angle));
				}
				else
				{
					transform.rotation = Quaternion.Euler(new Vector3(90f, 0, (transform.eulerAngles.y - angle) - 180));
				}
				colSpeed = collision.transform.GetComponent<Ball_Base>().speed * 0.8f;
				Invoke("ChangeSpeed", 0.1f);
			}
		}
		speed = speed - 0.5f;
	}
	void ChangeSpeed()
	{
		speed = colSpeed;
	}
}
