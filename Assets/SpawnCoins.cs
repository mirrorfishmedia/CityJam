using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour {

	public GameObject prefab;
	public int spawnRadius = 1000;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn()
	{
		for (int i = 0; i < Grid.gameMan.maxCoins; i++)
		{
			Vector3 spawnPos = new Vector3 (Random.Range (-spawnRadius, spawnRadius), 500, Random.Range (-spawnRadius, spawnRadius));
			GameObject clone = Instantiate(prefab, transform.position + spawnPos, Quaternion.identity) as GameObject;
		}
	}
}
