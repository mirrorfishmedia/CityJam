using UnityEngine;
using System.Collections;

public class SpawnCaster : MonoBehaviour {

	public GameObject caster;

	private Vector3 offset = new Vector3 (0,0,2);

	// Use this for initialization
	void Start () 
	{
		Spawn ();	
	}
	
	void Spawn()
	{
		Instantiate (caster, transform.position + offset, transform.rotation);
	}
}
