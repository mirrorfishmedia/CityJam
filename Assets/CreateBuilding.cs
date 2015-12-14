using UnityEngine;
using System.Collections;

public class CreateBuilding : MonoBehaviour {

	public GameObject[] slices;
	private int numSlices = 10;
	public int spacing = 1;

	public int minRows = 15;
	public int maxRows = 55;
	public float horizontalPosNoiseMax = 30f;
	public float verticalPosNoiseRange = .1f;
	public int bridgeChance = 90;
	public GameObject bridgeLayer;
	public Material[] materials;
	public bool randomizeScale = true;

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
		positionNoiseMax = Random.Range (0f, horizontalPosNoiseMax);
		myRenderer = GetComponent<MeshRenderer> ();
		meshCombiner = GetComponent<MeshCombiner> ();
	}

	// Use this for initialization
	void Start () 
	{
		if (randomizeScale) 
		{
			randScale = Random.Range (1, 5);
			scaleVector = new Vector3 (randScale, randScale, 1);

		}

		numSlices = Random.Range (minRows, maxRows);
		GridLoop ();
	}

	
	void GridLoop()
	{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = 0; y < numSlices; y++)
			{
				float positionNoise = Random.Range (0f,positionNoiseMax);
				//Choose a random tile from our array of prefabs and prepare to instantiate it.
				GameObject toInstantiate = slices[Random.Range (0,slices.Length)];
				
				verticalPosition = y * (spacing * toInstantiate.transform.localScale.y) + transform.position.y + Random.Range (0, verticalPosNoiseRange);
				GameObject instance = Instantiate (toInstantiate, new Vector3 (transform.position.x + positionNoise, verticalPosition, transform.position.z + positionNoise), Quaternion.identity) as GameObject;
				//DeparentDecoration deparenter = instance.GetComponent<DeparentDecoration>();
				//deparenter.DeparentChild();
				instance.transform.SetParent (this.transform);
			}

		meshCombiner.Combine ();
		//Color randomColor = new Color(0,0,0);
		//randomColor.r = Random.Range (0f, 0f);
		//randomColor.g = Random.Range (0.0f, .7f);
		//randomColor.b = Random.Range (0.0f,0.3f);
		//Debug.Log ("Color: " + randomColor.r + randomColor.g + randomColor.b);
		myRenderer.material = materials[Random.Range(0, materials.Length)];
		myRenderer.material.color = Grid.colorMgr.colors[Random.Range(0, Grid.colorMgr.colors.Length)];
		
	}
}

