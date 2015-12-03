using UnityEngine;
using System.Collections;

public class DroneFlier : MonoBehaviour {

	public float riseForce = 100f;
	public float horizontalSpeed = 100f;
	public Transform playerTransform;


	private Vector3 respawnOffset = new Vector3 (0,2,2);

	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Fire1")) {
		
			rb.AddForce(new Vector3(0,riseForce,0)); 	
		}

		if (Input.GetButton ("Fire2")) {
			
			transform.position = (playerTransform.position);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		Vector3 horizontalMovement = new Vector3 (Input.GetAxis ("Horizontal") * horizontalSpeed, 0, Input.GetAxis ("Vertical") * horizontalSpeed);
		rb.AddForce (horizontalMovement);
	}
}
