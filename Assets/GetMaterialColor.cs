using UnityEngine;
using System.Collections;

public class GetMaterialColor : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		MeshRenderer myRenderer;
		myRenderer = GetComponent<MeshRenderer> ();
		myRenderer.material.color = Grid.colorMgr.colors[Random.Range(0, Grid.colorMgr.colors.Length)];
	}
	

}
