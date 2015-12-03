using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public Transform droneTransform;
	public AudioSource tpSource;
	public Animator animatorCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump") && Grid.gameMan.tpReady) {
			this.transform.position = droneTransform.position;
			tpSource.Play();
			animatorCanvas.SetTrigger("fade");
			Grid.gameMan.AddJumps();
		}

		if (Input.GetButtonDown ("Restart")) {
			Grid.gameMan.Restart();
		}
	}


}
