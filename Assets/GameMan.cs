using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

	public int numCoins;
	public int maxCoins;
	public int numJumps;
	public int maxJumps = 20;
	public bool tpReady;
	public UIController uiController;

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
		uiController.UpdateUI ();
		CheckSuccess ();
	}

	public void AddJumps()
	{
		numJumps++;
		uiController.UpdateUI ();
		//if (numJumps > maxJumps && numCoins < maxCoins)
			//Restart ();
	}

	private void CheckSuccess()
	{
		if (numCoins == maxCoins) 
		{
			uiController.SuccessMessage();
		}
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
