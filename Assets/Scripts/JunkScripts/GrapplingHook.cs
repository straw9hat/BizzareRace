
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GrapplingHook : MonoBehaviour {


	//public Joystick MoveJoystick;
	//public ShootButton ShootButton;
	//public TouchField TouchField;

	public GameObject hook;
	public GameObject hookHolder;

	public float hookTravelSpeed;
	public float playerTravelSpeed;

	public bool fired;
	public bool hooked;
	public GameObject hookedObj;

	public float maxDistance;
	private float currentDistance;

	public Vector3 sizeOfHook;

	public bool fly;



	void Update()
	{

		fly = Input.GetMouseButton(0);


		if (fly && fired == false)
			fired = true;

		if (fired) 
		{
			LineRenderer rope = hook.GetComponent<LineRenderer> ();
			rope.SetVertexCount (2);
			rope.SetPosition (0, hookHolder.transform.position);
			rope.SetPosition (1, hook.transform.position);
		}

		if (fired == true && hooked == false) 
		{
			hook.transform.Translate (Vector3.forward * Time.deltaTime * hookTravelSpeed);
			currentDistance = Vector3.Distance (transform.position, hook.transform.position);

			if (currentDistance >= maxDistance)
				ReturnHook ();
		}

		if (hooked == true) 
		{
			hook.transform.parent = hookedObj.transform;

			Vector3 tempPos = hook.transform.position;
			tempPos.y += 8;


			transform.position = Vector3.MoveTowards (transform.position, tempPos, Time.deltaTime * playerTravelSpeed);
			float distanceToHook = Vector3.Distance (transform.position, tempPos);

			this.GetComponent<Rigidbody>().useGravity = false;

			if (distanceToHook < 2)
				ReturnHook ();
		} 
		else 
		{
			hook.transform.parent = hookHolder.transform; 
			this.GetComponent<Rigidbody> ().useGravity = true;
		}

		sizeOfHook = hook.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

	}

	public void ReturnHook()
	{
		hook.transform.rotation = hookHolder.transform.rotation;
		hook.transform.position = hookHolder.transform.position ;
		fired = false;
		hooked = false;

		LineRenderer rope = hook.GetComponent<LineRenderer> ();
		rope.SetVertexCount (0);
	}

	public void SpawnerUse()
	{
		hook.transform.parent = hookHolder.transform;
	}
}
