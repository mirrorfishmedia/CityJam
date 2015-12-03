using UnityEngine;
using System.Collections;

public class DropTeleporter : MonoBehaviour {

	public GameObject teleportCube;
	public Transform cubeSpawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("DropCube")) {
			teleportCube.transform.position = cubeSpawnPoint.position;
		}
	}
}
