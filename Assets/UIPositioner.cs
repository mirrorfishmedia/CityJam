using UnityEngine;
using System.Collections;

public class UIPositioner : MonoBehaviour {

	public Transform playerController;
	private Vector3 offset = new Vector3 (.55f, 0f, .4f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = playerController.position + offset;
	}
}
