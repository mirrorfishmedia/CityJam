using UnityEngine;
using System.Collections;

public class MakeBridge : MonoBehaviour {

	public GameObject bridgePiece;
	public GameObject bridgeCombined;
	public int bridgeMax = 20;

	private bool wayClear = true;
	private Transform bridgeObject;
	private Transform bridgeHolder;



	void Start()
	{
		LayBridge ();
	}


	public void LayBridge()
	{

		//MeshCombiner bridgeCombiner = new GameObject ("Bridge").AddComponent<MeshCombiner>();
		//bridgeHolder = bridgeCombiner.gameObject.transform;
		//bridgeCombiner.gameObject.AddComponent<MeshCollider> ();
		//bridgeCombiner.gameObject.AddComponent<MeshRenderer> ();
		GameObject newBridge = Instantiate (bridgeCombined, transform.position, transform.rotation) as GameObject;
		MeshCombiner bridgeCombiner = newBridge.GetComponent<MeshCombiner> ();
		bridgeHolder = newBridge.transform;



		for (int z = 0; z < bridgeMax; z++) {
			GameObject instance = Instantiate(bridgePiece, transform.position, transform.rotation) as GameObject;
			transform.Translate(0, 0, instance.transform.localScale.z);
			instance.transform.SetParent(bridgeHolder);

		}
		bridgeCombiner.Combine ();
		if (Random.Range (0, 2) == 1)
		bridgeHolder.transform.Rotate(Vector3.up, 90); 
	}

	void OnTriggerEnter()
	{
		//wayClear = false;
		//gameObject.SetActive (false);
	}
}
