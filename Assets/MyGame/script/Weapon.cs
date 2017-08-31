using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public List<GameObject> enemy;
    [SerializeField] private float fireCoolDown = 0.1f;
    [SerializeField] private float ATK;
    [SerializeField] private float attackRange = 6.0f;

    public GameObject bulletPrefabs;

    public Action turnToEvent;
	private Transform muzzle;
	private GameObject _bullet;
	private float time=0.0f;
	private float lastTime=0.0f;
	

	private void Awake()
	{
        enemy = new List<GameObject> ();
	}

    private void Start()
    {
        GetComponent<SphereCollider>().radius = attackRange;
        muzzle = transform.Find("muzzle");
        _bullet = GameObject.Find("Terrain/Bullet");
    }

    void OnTriggerEnter(Collider c)
	{
		if (c.tag == "enemy") {
			enemy.Add (c.gameObject);
			c.gameObject.GetComponent<Enemy> ().dieEvent += removeOnEnemyList;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.tag == "enemy") {
			enemy.Remove (c.gameObject);
		}
		if (c.tag == "bullet") {
			Destroy (c.gameObject);
		}
	}

	private void Update()
	{
		time += Time.deltaTime;
        if (enemy.Count > 0 && time > lastTime)
        {
            lastTime = time + fireCoolDown;
            while (enemy.Count > 0 && enemy[0] == null)
            {
                enemy.Remove(enemy[0]);
            }
            if (enemy.Count == 0)
                return;
            turnToEvent();
            GameObject temp = GameObject.Instantiate(bulletPrefabs,muzzle.position,Quaternion.identity,_bullet.transform);
            temp.GetComponent<Bullet> ().initialize (enemy[0],ATK);
        }
	}

	void removeOnEnemyList(GameObject _gameobject)
	{
		enemy.Remove (_gameobject);
    }
}
