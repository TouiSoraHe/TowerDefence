using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildWeapon : MonoBehaviour {
	public static BuildWeapon instance;

    public int weaponIndex = -1;
	public GameObject[] _weaponPrefabs;
	private SelectSubstrate _selectSubstrate;
	private Dictionary<string,GameObject> alreadyBuild;//炮塔基座的名字,炮塔游戏对象的引用
    private int[] weaponPrice;
    
    public Action<int> changeMoneyTextEvent;

    private void Awake()
	{
		instance = this;
		alreadyBuild = new Dictionary<string,GameObject>();
        weaponPrice = new int[] { 100, 150, 150, 150, 100 };
		_selectSubstrate = GameObject.Find ("substrate").GetComponent<SelectSubstrate> ();
	}

	private void Start()
	{
		InputController.instance.mouseLeftClickEvent += build;
	}

	private void build()
	{
		if (weaponIndex < 0 || weaponIndex>=_weaponPrefabs.Length || _selectSubstrate.CurrentSubstrate == null ||
            alreadyBuild.ContainsKey(_selectSubstrate.CurrentSubstrate.name)) {
			return;
		}
        if (UIManager.instance.Money - weaponPrice[weaponIndex] < 0)
        {
            return;
        }
        UIManager.instance.Money -= weaponPrice[weaponIndex];
        GameObject temp = Instantiate (_weaponPrefabs[weaponIndex], _selectSubstrate.CurrentSubstrate.transform.position, Quaternion.identity, this.transform);
		alreadyBuild.Add (_selectSubstrate.CurrentSubstrate.name,temp);
        _selectSubstrate.CurrentSubstrate.layer = 9;
    }
}
