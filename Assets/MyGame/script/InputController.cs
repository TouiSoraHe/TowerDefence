using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {
	public static InputController instance;
	public Action<Vector3> moveCameraEvent;
	public Action<float> scaleCameraEvent;
	public Action mouseLeftClickEvent;
	private Vector3 lastPosition;

	public void Awake()
	{
		instance = this;
	}
		
	void Update () {
		
		float y = Input.GetAxis ("Mouse ScrollWheel");
		if (y != 0) {
			scaleCameraEvent (y);
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseLeftClickEvent ();
		}

		if (Input.GetMouseButtonDown (1)) {
			lastPosition = Input.mousePosition;
			StartCoroutine (mouseMove ());
		}
		if (Input.GetMouseButtonUp (1)) {
			StopAllCoroutines ();
		}
	}

	IEnumerator mouseMove()
	{
		while (true) {
			Vector3 temp = Input.mousePosition - lastPosition;
			lastPosition = Input.mousePosition;
			moveCameraEvent (new Vector3(temp.x,0,temp.y));;
			yield return 0;
		}
	}
}