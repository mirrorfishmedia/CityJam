using UnityEngine;
using System.Collections;

public class DroneMoveRelative : MonoBehaviour {

	private Rigidbody rb;
	private float horizontalSpeed = 5;
	void Awake()
	{
		rb = GetComponent<Rigidbody> (); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.rotation = Camera.main.transform.rotation;
		Vector3 horizontalMovement = Camera.main.transform.forward * (Input.GetAxis ("Vertical") * horizontalSpeed);
		Vector3 verticalMovement = Camera.main.transform.right * (Input.GetAxis ("Horizontal") * horizontalSpeed);
		rb.AddForce (horizontalMovement);
		rb.AddForce (verticalMovement);
	}

	public void Move(Vector3 move)
	{

	}
}
