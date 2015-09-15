using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	
	public Transform spawnPoint;
	public Grappler grapple;
	
	private Rigidbody rb;
	private LineRenderer lr;
	private Vector3 hitPos;
	// Use this for initialization
	void Awake () {
		
		rb = GetComponent<Rigidbody> ();
		lr = GetComponent<LineRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		lr.SetPosition (0, spawnPoint.position);
		lr.SetPosition (1, transform.position);
		
	}
	
	void OnCollisionEnter(Collision other)
	{
		rb.isKinematic = true;
		ContactPoint contact = other.contacts[0];
		//hitPos = ;
		Debug.Log ("grapple " + grapple);

		Debug.Log ("grapple.pointToMoveTo " + grapple.pointToMoveTo);
		Debug.Log ("contact.point " + contact.point);
		grapple.pointToMoveTo = contact.point;
		grapple.hitSomething = true;
		//		Debug.Log (other.gameObject);
		
	}
}
