using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Image tpReadyLight;
	public Text coins;
	public Text jumps;
	public Color readyColor;
	public Color notReadyColor;
	public GameObject successPanel;
	private AudioSource source;


	private bool showingUI;
	private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		canvasGroup = GetComponent<CanvasGroup> ();
		showingUI = false;
		HideUI ();
	}

	public void UpdateUI()
	{
		coins.text = "Jewels: " + Grid.gameMan.numCoins + "/" + Grid.gameMan.maxCoins;
		jumps.text = "Jumps: " + Grid.gameMan.numJumps + "/" + Grid.gameMan.maxJumps;;
		if (Grid.gameMan.tpReady)
			tpReadyLight.color = readyColor;
		else
			tpReadyLight.color = notReadyColor;

	}

	public void Update()
	{
		//UpdateUI ();

		if (Input.GetButtonUp ("ToggleUI")) 
		{
			source.Play();
			if (!showingUI)
				ShowUI ();
			else
				HideUI();
		}
	}

	public void HideUI()
	{
		showingUI = false;
		canvasGroup.alpha = 0;
	}

	public void ShowUI()
	{
		showingUI = true;
		canvasGroup.alpha = 100;
	}

	public void SuccessMessage()
	{
		successPanel.SetActive (true);
	}

}
