using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Image tpReadyLight;
	public Text coins;
	public Text jumps;
	public Color readyColor;
	public Color notReadyColor;

	// Use this for initialization
	void Start () {
	
	}

	public void UpdateUI()
	{
		coins.text = "Coins: " + Grid.gameMan.numCoins + "/" + Grid.gameMan.maxCoins;
		jumps.text = "Jumps: " + Grid.gameMan.numJumps + "/" + Grid.gameMan.maxJumps;;
		if (Grid.gameMan.tpReady)
			tpReadyLight.color = readyColor;
		else
			tpReadyLight.color = notReadyColor;

	}

	public void Update()
	{
		UpdateUI ();
	}

}
