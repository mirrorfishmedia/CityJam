using UnityEngine;
using System.Collections;

public class PickupCoin : MonoBehaviour {

	private bool pickedUp;
	public ParticleSystem particles;
	public Transform particleTransform;
	public MeshExploder meshExploder;
	public AudioSource source;
	public GameObject flockPf;
	//public Vector3 flockHeightOffset = new Vector3 (0, 

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("Drone")) {

			Pickup();
		}
	}

	void Pickup()
	{
		if (!pickedUp) {
			pickedUp = true;
			Grid.gameMan.AddCoins();
			particles.Stop ();
			meshExploder.Explode();
			particleTransform.SetParent(null);
			source.Play();
			this.gameObject.SetActive(false);
			//flockPf.transform.SetParent(null);
			//flockPf.SetActive(true);
		}
	}

	
}
