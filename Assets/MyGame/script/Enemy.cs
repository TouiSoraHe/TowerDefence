using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour {
	[SerializeField] private float Hp;
	[SerializeField] private float currentHp;
	private Transform bloodReservoir;
	public Action<GameObject> dieEvent;
    private float hpScaleX;
    private float hpScaleY;
    private float hpScaleZ;

	private void Awake()
	{
		currentHp = Hp;
	}

    private void Start()
    {
        bloodReservoir = transform.Find("hp");
        hpScaleX = bloodReservoir.localScale.x;
        hpScaleY = bloodReservoir.localScale.y;
        hpScaleZ = bloodReservoir.localScale.z;
    }

    public void beAttcked(float atk)
	{
		if (currentHp > 0) {
			currentHp -= atk;
			if (currentHp < 0)
				currentHp = 0;
            bloodReservoir.localScale = new Vector3(currentHp / Hp * hpScaleX,hpScaleY ,hpScaleZ );
            if (currentHp == 0)
            {
                isDie();
            }
        }
	}

	private void isDie()
	{
        dieEvent (this.gameObject);
        UIManager.instance.Money += 50;
        UIManager.instance.Score += 1;
        Destroy(this.gameObject);
    }

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "bullet") {
			beAttcked (c.GetComponent<Bullet> ().atk);
			
		}
	}

}
