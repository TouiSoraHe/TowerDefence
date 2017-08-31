using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSubstrate : MonoBehaviour {
	[SerializeField] private GameObject currentSubstrate=null;
	public GameObject CurrentSubstrate
	{
		get{ return currentSubstrate;}
	}

	private void Update()
	{
		if (currentSubstrate != null) {
            currentSubstrate.GetComponent<MeshRenderer>().enabled = false;
			currentSubstrate = null;
		}
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, 200.0f, LayerMask.GetMask("substrate")))
        {
            currentSubstrate = hitInfo.transform.gameObject;
            currentSubstrate.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (Physics.Raycast(r, out hitInfo, 200.0f, LayerMask.GetMask("alreadyBeenBuild"))) {
            currentSubstrate = hitInfo.transform.gameObject;
        }
	}
}
