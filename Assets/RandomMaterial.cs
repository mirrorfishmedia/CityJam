using UnityEngine;
using System.Collections;

public class RandomMaterial : MonoBehaviour {

	public Material[] materials;

	// Use this for initialization
	void Start () 
	{	
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		renderer.material = materials[Random.Range (0, materials.Length)];
	}

}
