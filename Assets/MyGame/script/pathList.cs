using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathList : MonoBehaviour {
	public List<Transform> pathPosition;
	public static pathList instance;

	void Awake()
	{
		instance = this;

		pathPosition = new List<Transform> ();
		foreach (Transform item in transform) {
			pathPosition.Add (item);
		}
	}
}
