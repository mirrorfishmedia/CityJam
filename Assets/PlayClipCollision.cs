using UnityEngine;
using System.Collections;

public class PlayClipCollision : MonoBehaviour {

	public AudioSource source;
	public AudioSource source2;
	public AudioClip hitClip;
	public AudioClip restClip;


	private Rigidbody rb;
	private float distToGround;
	private bool clipPlayed;
	private bool atRest;


	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void OnCollisionEnter(Collision other)
	{
		Debug.Log ("other " + other.gameObject);
		atRest = false;
		source.clip = hitClip;
		source.Play ();
	}

	void Update()
	{

		if (Grounded ()) {
			source2.clip = restClip;
			if (!atRest)
			{
				source2.Play ();

				atRest = true;
			}

			Grid.gameMan.tpReady = true;
		} else {
			Grid.gameMan.tpReady = false;
		}
	}

	bool Grounded()
	{

		bool grounded = rb.IsSleeping();

		//Debug.Log ("Rb is grounded: " + grounded);
		//grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + .1f);
		return grounded;
	}


}
