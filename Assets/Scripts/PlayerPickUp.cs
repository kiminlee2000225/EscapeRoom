using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
	public Transform player;
	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			hasPlayer = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			hasPlayer = false;
		}
	}

	void Update()
	{
		if (beingCarried)
		{
			if (Input.GetMouseButtonDown(0))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody>().AddForce(player.forward * throwForce);
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0) && hasPlayer)
			{
				transform.parent = player;
				beingCarried = true;
			}
		}
	}
}