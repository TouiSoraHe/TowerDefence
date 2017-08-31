using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private float speed=2.0f;
	private GameObject enemy;
	public float atk;

	public void initialize(GameObject enemy,float atk)
	{
		this.enemy = enemy;
		this.atk = atk;
	}

	private void Update()
	{
		Vector3 direction;
		if (enemy != null) {
			direction = (enemy.transform.position - this.transform.position).normalized;
		} else {
			direction = this.transform.position.normalized;
		}
		this.transform.Translate (direction * speed, Space.World);
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "enemy") {
			Destroy (this.gameObject);
		}
	}

}
