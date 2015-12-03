using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

	public int numCoins;
	public int maxCoins;
	public int numJumps;
	public int maxJumps = 20;
	public bool tpReady;

	// Use this for initialization
	void Start () {
		Reset ();
	}

	void OnLevelWasLoaded()
	{
		Reset ();
	}

	void Reset()
	{
		numCoins = 0;
		numJumps = 0;
	}

	public void AddCoins()
	{
		numCoins++;
	}

	public void AddJumps()
	{
		numJumps++;
		if (numJumps > maxJumps && numCoins < maxCoins)
			Restart ();
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
