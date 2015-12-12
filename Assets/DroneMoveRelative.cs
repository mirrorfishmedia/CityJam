using UnityEngine;
using System.Collections;

public class DroneMoveRelative : MonoBehaviour {

	private Rigidbody rb;
	private float horizontalSpeed = 5;
	void Awake()
	{
		rb = GetComponent<Rigidbody> (); 
	}

	
	// Update is called once per frame
	void FixedUpdate () {
	
		Debug.Log ("input get axis horizontal " + Input.GetAxis ("Horizontal"));
		transform.rotation = Camera.main.transform.rotation;
		Vector3 horizontalMovement = Camera.main.transform.forward * (Input.GetAxis ("VerticalDrone") * horizontalSpeed);
		Vector3 verticalMovement = Camera.main.transform.right * (Input.GetAxis ("HorizontalDrone") * horizontalSpeed);
		rb.AddForce (horizontalMovement);
		rb.AddForce (verticalMovement);
	}
		
}
