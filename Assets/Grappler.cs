using UnityEngine;
using System.Collections;

public class Grappler : MonoBehaviour {
	
	public Transform targetDir;
	public Transform spawnPoint;
	public GameObject hookEnd;
	public float shootForce = 500;
	public Vector3 pointToMoveTo;
	public bool hitSomething;
	public float moveForce = 200; 
	
	
	private LineRenderer lr;
	private bool hooking;
	GameObject hookClone;
	Rigidbody rb;
	
	// Use this for initialization
	void Awake () {
		
		
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update()
	{
		if (Input.GetButtonUp ("Fire1")) 
		{
			StopShot ();
		}
		
		if (Input.GetButtonDown ("Fire1")) {
			
			if (!hooking) {
				Shoot ();
			}
			
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if (hitSomething) 
		{
			Vector3 moveDir = pointToMoveTo - transform.position;
			rb.AddForce(moveDir.normalized * moveForce, ForceMode.Force);
		}	
		
	}
	
	void Shoot()
	{
		hooking = true;
		Vector3 shootDir = targetDir.position - spawnPoint.position;
		hookClone = Instantiate (hookEnd, spawnPoint.position, transform.rotation) as GameObject;
		DrawLine drawLine = hookClone.GetComponent<DrawLine>();
		drawLine.spawnPoint = spawnPoint;
		drawLine.grapple = this;
		Rigidbody hookCloneRb = hookClone.GetComponent<Rigidbody> ();
		hookCloneRb.AddForce (shootDir * shootForce);
	}
	
	void StopShot()
	{
		hooking = false;
		Destroy(hookClone);
		hitSomething = false;
	}
	
	
	
	
	
}
