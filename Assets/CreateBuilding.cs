using UnityEngine;
using System.Collections;

public class CreateBuilding : MonoBehaviour {

	public GameObject[] slices;
	public int columns = 1;
	public int rows = 10;
	public int spacing = 1;

	public int minRows = 15;
	public int maxRows = 55;
	public float positionNoiseMaxRange = 30f;
	public float verticalPosNoiseRange = .1f;
	public int bridgeChance = 90;
	public GameObject bridgeLayer;


	private MeshCombiner meshCombiner;
	private MeshRenderer myRenderer;
	private float positionNoiseMax;
	private Vector3 scaleVector;
	private float randScale;
	private float verticalPosition;
	private MakeBridge makeBridge;

	//private Vector3 startPosition;


	void Awake()
	{
		makeBridge = GetComponent<MakeBridge> ();
		positionNoiseMax = Random.Range (0f, positionNoiseMaxRange);
		myRenderer = GetComponent<MeshRenderer> ();
		meshCombiner = GetComponent<MeshCombiner> ();
	}

	// Use this for initialization
	void Start () 
	{
		randScale = Random.Range (1, 5);
		scaleVector = new Vector3 (randScale, randScale, 1);
		rows = Random.Range (minRows, maxRows);
		GridLoop ();
	}

	
	void GridLoop()
	{
		
		for(int x = 0; x < columns; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = 0; y < rows; y++)
			{
				float positionNoise = Random.Range (0f,positionNoiseMax);
				//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
				GameObject toInstantiate = slices[Random.Range (0,slices.Length)];
				
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.

				verticalPosition = y * (spacing * toInstantiate.transform.localScale.y) + transform.position.y + Random.Range (0, verticalPosNoiseRange);
				Vector3 bridgeSpawnPosition = new Vector3 (transform.position.x, verticalPosition, transform.position.z + 7f);
				if (Random.Range (0,100) > bridgeChance)
				Instantiate(bridgeLayer, bridgeSpawnPosition, transform.rotation);
				GameObject instance = Instantiate (toInstantiate, new Vector3 (transform.position.x + positionNoise, verticalPosition, transform.position.z + positionNoise), Quaternion.identity) as GameObject;



				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				//instance.transform.localScale =  scaleVector + instance.transform.localScale;
				instance.transform.SetParent (this.transform);
			}
		}

		meshCombiner.Combine ();
		Color randomColor = new Color(0,0,0);
		randomColor.r = Random.Range (0f, 1f);
		randomColor.g = Random.Range (0.0f, 0f);
		randomColor.b = Random.Range (0.0f,0.1f);
		Debug.Log ("Color: " + randomColor.r + randomColor.g + randomColor.b);
		myRenderer.material.color = randomColor;
		
	}
}

