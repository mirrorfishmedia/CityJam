using UnityEngine;
using System.Collections;

public class PickupCoin : MonoBehaviour {

	private bool pickedUp;

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
			
			this.gameObject.SetActive(false);
		}
	}

	
}
