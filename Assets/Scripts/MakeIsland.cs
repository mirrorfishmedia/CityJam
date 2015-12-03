using UnityEngine;
using System.Collections;

public class MakeIsland : MonoBehaviour {

	public int slicesPerIsland = 3;

	public GameObject[] cylinders;
	public float sliceCircleRadius = 50;
	public int cylPerSlice = 5;
	public Material[] materials;

	public GameObject sliceHolder;
	public GameObject colorCube;

	private Vector3 
		OffsetPos = new Vector3 (0, 50,0);

	// Use this for initialization
	void Start () {
	
		OneLayer ();
	}



	void OneLayer()
	{
		GameObject thisSlice = Instantiate(sliceHolder, transform.position, Quaternion.identity) as GameObject;

	

		float thisCylinderScale = 0;
		for (int c = 0; c < cylPerSlice; c++)
		{	
			Vector2 spawnPosition = Random.insideUnitCircle * sliceCircleRadius;
			GameObject thisCylinder = Instantiate(cylinders[Random.Range (0,cylinders.Length)], transform.position, Quaternion.identity) as GameObject;
			thisCylinder.transform.position = new Vector3 (spawnPosition.x + this.transform.position.x, transform.position.y + Random.Range (-.1f,.1f), spawnPosition.y + this.transform.position.z) ;
			thisCylinderScale = thisCylinder.transform.localScale.y;
			MeshRenderer cylRenderer = thisCylinder.GetComponent<MeshRenderer>();
			cylRenderer.material = materials[Random.Range (0,materials.Length)];

			thisCylinder.transform.SetParent(thisSlice.transform);
		}

		StackAndScale (thisSlice, thisCylinderScale);


	}

	void StackAndScale(GameObject obj, float cylinderScale)
	{
		float scaledown = Random.Range (.9f,.97f);	
		float heightNoise = Random.Range (1.1f,1.9f);	
		for (int i = 0; i <= slicesPerIsland; i++) 
		{

			scaledown *= scaledown;
			//heightNoise += i * scaledown;
			Vector3 offsetPos = new Vector3 (transform.position.x, transform.position.y + i * cylinderScale, transform.position.z);
			GameObject thisCyl = Instantiate(obj, offsetPos, Quaternion.identity) as GameObject;
			thisCyl.transform.localScale = new Vector3(thisCyl.transform.localScale.x * scaledown, thisCyl.transform.localScale.y + heightNoise * scaledown, thisCyl.transform.localScale.z * scaledown);
			float maxCubeChance = thisCyl.transform.position.y * .2f;
			int rollForCube = Random.Range (0,100);
			if (i == slicesPerIsland && rollForCube < maxCubeChance)
			{
				//GameObject newCube = Instantiate (colorCube, thisCyl.transform.position + colorCubeOffsetPos, Quaternion.identity) as GameObject;
			}
		}
	}
}
