using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Rigidbody rb;
	private int count;
	public Text CountText;
	public float speed;
	public float jumpSpeed;
	public Text WinText;
	
	// Store the bool value from Collision check
	private bool isGrounded;
	
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		WinText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isGrounded == true)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				MakeMeJump();
			}
		}
	}
	
	void MakeMeJump()
	{
		rb.AddForce(Vector3.up * (jumpSpeed * 100), ForceMode.Force);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontalMovement = Input.GetAxis("Horizontal")*-1;  // Add –1 to reverse input direction
		float verticalMovement = Input.GetAxis("Vertical")*-1;
		Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	
	void OnCollisionStay(Collision coll)
	{
		isGrounded = true;
	}
	
	void OnCollisionExit(Collision coll)
	{
		isGrounded = false;  
	}
	void SetCountText ()
	{
		CountText.text = "Count: " + count.ToString ();
		if (count >= 20) 
		{
			WinText.text = "You Win!";
		}
	}
}