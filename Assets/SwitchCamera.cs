using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public Camera droneCamera;
	public Camera playerCamera;
	private AudioListener droneListener;
	private AudioListener playerListener;
	private Rigidbody rb;
	private bool droneView;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		droneCamera.enabled = false;
		droneListener = droneCamera.gameObject.GetComponent<AudioListener> ();
		droneListener.enabled = false;
		Debug.Log ("dronelistener " + droneListener.enabled);
		playerListener = playerCamera.gameObject.GetComponent < AudioListener> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("SwitchCamera")) 
		{
			if (!droneView)
			{
				rb.isKinematic = true;
				droneView = true;
				droneCamera.enabled = true;
				droneListener.enabled = true;
				playerCamera.enabled = false;
				playerListener.enabled = true;
			}
			else
			{
				rb.isKinematic = false;
				droneView = false;
				droneCamera.enabled = false;
				droneListener.enabled = false;
				playerCamera.enabled = true;
				playerListener.enabled = false;
			}

		}


	}
}
