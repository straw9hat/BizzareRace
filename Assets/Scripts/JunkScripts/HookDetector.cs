using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Hookable" || other.tag == "Player") 
		{
			player.GetComponent<GrapplingHook> ().hooked = true;
			player.GetComponent<GrapplingHook> ().hookedObj = other.gameObject;
		}
	}
}
