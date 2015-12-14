using UnityEngine;
using System.Collections;

public class DeparentDecoration : MonoBehaviour {

	public Transform[] children;

	public void DeparentChild()
	{
		for (int i = 0; i < children.Length; i++) {
			children[i].SetParent(null);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
