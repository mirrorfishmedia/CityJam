using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGrid : MonoBehaviour {

	public int numSpawns;
	public int columns;
	public int rows;
	public int spacingMax;
	private int spacing = 50;
	public GameObject[] buildings;	
	public GameObject[] outerBuildings;
	public bool offSetFromGround;
	public bool randomizeVerticalScale;
	public bool randomizeHorizontalScale;
	public bool combineMeshes;
	public bool useVerticalOffsetRange;
	public float verticalOffsetRange = 0;
	public Material combinedMaterial;
	public GameObject coinPf;
	public int coinsToSpawn = 6;
	private List<Transform> bldgSpawns = new List<Transform>();




	// Use this for initialization
	void Start () {
		//GridLoop ();
	
	}

	public void GridLoop()
	{

	
		for(int x = 0; x < columns; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = 0; y < rows; y++)
			{

				spacing = spacingMax + Random.Range (-5,5);
				//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
				GameObject toInstantiate = buildings[Random.Range (0,buildings.Length)];
				
				//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
				//if(x == -1 || x == columns || y == -1 || y == rows)
				//	toInstantiate = outerBuildings [Random.Range (0, outerBuildings.Length)];
				
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x * spacing, 0, y * spacing), Quaternion.identity) as GameObject;

				if (offSetFromGround)
				{
					Vector3 offset = new Vector3 (instance.transform.position.x, instance.transform.position.y + instance.transform.localScale.y * .5f, instance.transform.position.z);
					instance.transform.position = offset;
				}

				if (randomizeVerticalScale)
				{
					Vector3 randVerticalScale = 
						new Vector3 (instance.transform.localScale.x, instance.transform.localScale.y * Random.Range (0.1f, 2f), instance.transform.localScale.z);
					instance.transform.localScale = randVerticalScale;
				}
					
				if (randomizeHorizontalScale)
				{
					Vector3 randHorizontalScale = 
						new Vector3 (instance.transform.localScale.x * Random.Range (0.1f, 2f), instance.transform.localScale.y, instance.transform.localScale.z * Random.Range (0.1f, 2f));
					instance.transform.localScale = randHorizontalScale;
				}
				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.

				if (combineMeshes)
				{
					MeshCombiner meshCombineScript;
					meshCombineScript = GetComponent<MeshCombiner>();
					meshCombineScript.Combine();
				}

				if (useVerticalOffsetRange)
				{
					instance.transform.position = new Vector3 (instance.transform.position.x, instance.transform.position.y + Random.Range(-verticalOffsetRange, verticalOffsetRange), instance.transform.position.z);
				}

				bldgSpawns.Add(instance.transform);
				instance.transform.SetParent (this.transform);
				//Vector3 offsetCoin = new Vector3 (0, 500, 0);
				//Instantiate(coinPf, instance.transform.position + offsetCoin, Quaternion.identity);

			}

			if (combineMeshes)
			{
				MeshCombiner meshCombineScript;
				meshCombineScript = GetComponent<MeshCombiner>();
				meshCombineScript.Combine();
				MeshRenderer renderer;
				renderer = GetComponent<MeshRenderer>();
				renderer.material = combinedMaterial;
				combinedMaterial.color = Grid.colorMgr.anchorColor;
			}
		}

		StaticBatchingUtility.Combine (this.gameObject);
		SpawnCoins ();
	}

//	private void StaticBatchBuildings()
//	{
//		foreach (Transform bldgTransform in bldgSpawns)
//		{
//			bldgTransform.SetParent(this.transform);
//		}
//
//	}

	private void SpawnCoins()
	{
		for (int i = 0; i < Grid.gameMan.maxCoins; i++) 
		{
			int randPick = Random.Range (0, bldgSpawns.Count);
			Vector3 randBldgPos = bldgSpawns[randPick].position;
			Vector3 offset = new Vector3 (0, 500, 0);

			Instantiate(coinPf, randBldgPos + offset, Quaternion.identity);
//			Debug.Log ("Spawn coin" + i + " at:  " + randBldgPos + offset);
		
		}
	}
	
}
