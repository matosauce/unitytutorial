using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	public float jumpSpeed;
	public Transform groundCheck;
	public Text scoreText;
	public Text winText;
	private int score;
	public const int numCoins = 3;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		SetScore(0);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Coin"))
		{
			other.gameObject.SetActive (false);
			SetScore (++score);
		}
	}

	//use FixedUpdate instead of Update for physics
	void FixedUpdate ()
	{
		var xMovement = Input.GetAxis ("Horizontal");
		var zMovement = Input.GetAxis ("Vertical");
		var move = new Vector3 (xMovement, 0, zMovement);
		rb.AddForce (move * speed);

		var jump = Input.GetKey (KeyCode.Space);
		if (jump && Physics.Linecast(transform.position, groundCheck.position))
		{
			rb.AddForce (0, jumpSpeed, 0);
		}
	}

	void SetScore(int newScore)
	{
		score = newScore;
		scoreText.text = "Score: " + score;
		if (score == 0)
		{
			winText.text = "";
		}
		if (score >= numCoins)
		{
			winText.text = "You Win!!";
		}
	}
}
