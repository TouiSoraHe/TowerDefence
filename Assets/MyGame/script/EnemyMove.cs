using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;

	void Start () {
		StartCoroutine (moveNetx (0));
	}

	IEnumerator moveNetx(int index)
	{
		if (index < pathList.instance.pathPosition.Count) {
            Vector3 direction= (pathList.instance.pathPosition[index].position - transform.position).normalized;
            this.transform.LookAt(pathList.instance.pathPosition[index]);
			while (distance(pathList.instance.pathPosition[index].position, transform.position) >= speed * Time.fixedDeltaTime) {
                transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
                yield return new WaitForFixedUpdate ();
                
			}
			yield return StartCoroutine (moveNetx (index+1));
		}
        //do something
        UIManager.instance.Health -= 1;
		Destroy (this.gameObject);
	}

    private float distance(Vector3 v1, Vector3 v2)
    {
        return Vector2.Distance(new Vector2(v1.x, v1.z), new Vector2(v2.x, v2.z));
    }
}
