using UnityEngine;
using System.Collections;

public class CastBridge : MonoBehaviour {



	// Use this for initialization
	void Start () {

		transform.SetParent (null);
		CastRayForBridge ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	
	}

	void CastRayForBridge()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.forward, out hit, 1000.0F)) 
		{
			float distanceToHit = Vector3.Distance (transform.position,hit.point);
			Debug.Log ("dist: " + distanceToHit);


			this.transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z + distanceToHit);
			Vector3 tempPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - distanceToHit * .5f);
			transform.position = tempPos;
		}
	}
}
