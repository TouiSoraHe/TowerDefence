using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTurnTo : MonoBehaviour {
    private Weapon _weapon;

    private void Start()
    {
        _weapon = transform.parent.parent.GetComponent<Weapon>();
        _weapon.turnToEvent += turnTo;
    }
    private void turnTo()
    {
        transform.LookAt(_weapon.enemy[0].transform.position);
    }
}
