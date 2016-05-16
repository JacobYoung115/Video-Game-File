using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour {

	public Color colorStart = Color.yellow;
	public Color colorEnd = Color.green;
	public float duration = 1.0F;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log ("Enter called.");

	}

	void OnCollisionStay (Collision collision)
	{
		Debug.Log ("Stay called.");
	}

	void OnCollisionExit (Collision collision)
	{
		float lerp = Mathf.PingPong (Time.time, duration) / duration;
		rend.material.color = Color.Lerp (colorStart, colorEnd, lerp);

		Debug.Log ("Exit called.");

	}
}

