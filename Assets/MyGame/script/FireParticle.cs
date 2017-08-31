using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour {
    private bool isFire=false;
    private Weapon w;
    private ParticleSystem p;

    private bool IsFire
    {
        set {
            if (value != isFire)
            {
                isFire = value;
                if (isFire)
                {
                    p.Play();
                }
                else
                {
                    p.Stop();
                }
            }
        }
    }

    private void Start()
    {
        p=GetComponent<ParticleSystem>();
        p.Stop();
        w = this.transform.parent.parent.parent.GetComponent<Weapon>();
    }

    private void Update()
    {
        if (w.enemy.Count > 0)
        {
            IsFire = true;
        }
        else
        {
            IsFire = false;
        }
    }
}
