using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public Transform droneTransform;
	public AudioSource tpSource;
	public Animator animatorCanvas;
	//public ParticleSystem tpParticles;
	public GameObject tpParticlePf;
	public Transform particleSpawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump") && Grid.gameMan.tpReady) {
			this.transform.position = droneTransform.position;
			tpSource.Play();
			//tpParticles.Clear();
			//tpParticles.Play();
			Instantiate(tpParticlePf, particleSpawnPoint.position, transform.rotation);
			//Debug.Log ("tp particles " + tpParticles.isPlaying);
			animatorCanvas.SetTrigger("fade");
			Grid.gameMan.AddJumps();
			droneTransform.gameObject.SetActive(false);
		}

		if (Input.GetButtonDown ("Restart")) {
			Grid.gameMan.Restart();
		}
	}


}
