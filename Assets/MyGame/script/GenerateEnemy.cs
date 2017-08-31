using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour {
	public GameObject[] _prefabs;
	public int _enemyCount = 5;
	public float _waveCoolDown = 5.0f;
	public float _generateCoolDown = 0.5f;

	void Start () {
		StartCoroutine (generateCount (1));
	}


	IEnumerator generateCount(int n)
	{
        UIManager.instance.WaveCount--;
		if (n <= UIManager.WAVE_COUNT) {
			float time = Time.time;
			for (int i = 0; i < _enemyCount; i++) {
				int index = Random.Range (0, _prefabs.Length);
				GameObject.Instantiate (_prefabs [index], this.transform.position, Quaternion.identity, this.transform).GetComponent<EnemyMove>().speed+=n;
				yield return new WaitForSeconds (_generateCoolDown);
			}
            /*////////////////////////////////
             * 按照一定的时间出现下一波怪
			yield return new WaitForSeconds ((_waveCoolDown - (Time.time-time)) > 0 ? _waveCoolDown - (Time.time-time) : 0);
			StartCoroutine (generateCount (n + 1));
            ////////////////////////////////*/
            //场上的怪物全部消失后出现下一波怪
            while (transform.childCount!=0)
            {
                yield return 0;
            }
            StartCoroutine(generateCount(n + 1));
            //////////////////////////////////////
        }
        else
        {
            UIManager.instance.gameOver();
        }
	}
}
