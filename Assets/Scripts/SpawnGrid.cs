using UnityEngine;
using System.Collections;

public class SpawnGrid : MonoBehaviour {

	public int numSpawns;
	public int columns;
	public int rows;
	public int spacingMax;
	private int spacing = 50;
	public GameObject[] buildings;	
	public GameObject[] outerBuildings;



	// Use this for initialization
	void Start () {
		GridLoop ();
	
	}

	void GridLoop()
	{
	
		for(int x = 0; x < columns; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = 0; y < rows; y++)
			{
				spacing = Random.Range (1,spacingMax);
				//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
				GameObject toInstantiate = buildings[Random.Range (0,buildings.Length)];
				
				//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
				//if(x == -1 || x == columns || y == -1 || y == rows)
				//	toInstantiate = outerBuildings [Random.Range (0, outerBuildings.Length)];
				
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x * spacing, 0, y * spacing), Quaternion.identity) as GameObject;
				
				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				instance.transform.SetParent (this.transform);
			}
		}

	}
	
}
