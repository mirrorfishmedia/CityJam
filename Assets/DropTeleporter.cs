using UnityEngine;
using System.Collections;

public class DropTeleporter : MonoBehaviour {

	public GameObject teleportCube;
	public Transform cubeSpawnPoint;
	public AudioSource source;
	public AudioClip pickUpDroneClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("DropCube")) {
			teleportCube.SetActive(true);
			teleportCube.transform.position = cubeSpawnPoint.position;
			teleportCube.transform.rotation = Quaternion.identity;
			source.clip = pickUpDroneClip;
			source.Play();
		}
	}
}
