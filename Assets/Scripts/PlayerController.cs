using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);
		}
	}

	//use FixedUpdate instead of Update for physics
	void FixedUpdate ()
	{
		var xMovement = Input.GetAxis ("Horizontal");
		var zMovement = Input.GetAxis ("Vertical");
		var move = new Vector3 (xMovement, 0, zMovement);
		rb.AddForce (move * speed);
	}
}
