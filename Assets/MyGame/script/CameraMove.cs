using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	private float speed = 0.05f;
	private float Yspeed = -8.0f;

	private void Start()
	{
		InputController.instance.moveCameraEvent += move;
		InputController.instance.scaleCameraEvent += scale;
	}

	private void scale(float y)
	{
		this.transform.Translate(new Vector3(0,y * Yspeed,0),Space.World);
	}

	private void move(Vector3 p)
	{
		this.transform.Translate (p * speed, Space.World);
	}
}
