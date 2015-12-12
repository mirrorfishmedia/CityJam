using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class HeightToCutoff : MonoBehaviour {

	public float heightMax = 1200f;
	public float heightMind = 1f;
	public AudioMixer musicMixer;
	public float freqMinimum = 150;
	public float freqMaximum = 12000;

	private float cutoff;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		cutoff = (transform.position.y / heightMax) * freqMaximum + freqMinimum;
			musicMixer.SetFloat("ChordLowpassCutoff", cutoff);
	}
}
