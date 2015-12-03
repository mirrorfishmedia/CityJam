using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {
	
	public bool randColorOnStart;

	public Color anchorColor;
	public Color opposingColor;
	public Color gCAnchor;
	public Color gCOppose;
	public Color skyColor;
	public Material skyBox;

	public Color[] colors;
	public SpawnGrid spawnGrid;
	
	
	public Camera mainCamera;
	//	public CamUnderWater waterCamScript;
	
	// Use this for initialization
	void Awake () {
		
		mainCamera = Camera.main;
		ColorChange ();
		
		
	}
	
	public void ColorChange()
	{
		if (randColorOnStart) 
		{
			anchorColor = new Color(Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f));
			anchorColor = RandomSaturated (anchorColor);
		}
		
		

		
		/*
		//generate half sat versions
		anchorColorMatHalfSat.color = Desaturate(anchorColor, .5f);
		opposingColorMatHalfSat.color = Desaturate(opposingColor,.5f);
		
		//generate quarter sat versions
		
		opposingColorMatQtrSat.color = Desaturate(opposingColor, .25f);
		anchorColorMatQtrSat.color = Desaturate(anchorColor, .25f);
		anchorColorVDarkMat.color = SetLevel(anchorColor, .25f);
		
		//generate half value versions
		anchorColorDarkMat.color = SetLevel(anchorColor, .5f);
		opposingColorDarkMat.color = SetLevel(opposingColor, .5f);
		opposingColorMatTenSat.color = Desaturate (opposingColor, .1f);
		

		gCAnchorMat.color = gCAnchor;
		gCAnchorHalfSatMat.color = Desaturate(gCAnchor, .5f);
		gCAnchorHalfSatMat.color = SetAlpha(gCAnchor, .5f);
		gCDarkHalfSatMat.color = SetLevel(gCAnchorHalfSatMat.color,.5f);
		
		gCOppose = InvertColor (gCAnchorMat.color);
		
		gCOpposeMat.color = Desaturate (gCOppose, .25f);
		*/

		opposingColor = InvertColor(anchorColor);
		gCOppose = InvertColor (gCAnchor);
		gCAnchor = GoldenRatioColor(anchorColor);
		skyColor = Desaturate (gCOppose, .25f);
		skyBox.SetColor ("_SkyTint", opposingColor);
		skyBox.SetColor ("_GroundColor", gCOppose);
		mainCamera.backgroundColor = skyColor;
		
		RenderSettings.fogColor = skyColor;
		RenderSettings.ambientSkyColor = skyColor;

		colors = new Color[15];

		colors [0] = anchorColor;
		//colors [1] = Desaturate(opposingColor, .5f);
		colors [1] = Desaturate(anchorColor, .55f);
		//colors [2] = Desaturate (gCAnchor, .25f);
		colors [2] = Desaturate (anchorColor, .85f);
		colors [3] = Desaturate (anchorColor, .35f);
		//colors [3] = Desaturate (gCOppose, .25f);
		colors [4] = Desaturate (anchorColor, .5f);
		colors [5] = Desaturate (anchorColor, .75f);
		colors [6] = Desaturate (anchorColor, .5f);
		colors [7] = Desaturate (anchorColor, .25f);
		colors [8] = Desaturate (anchorColor, .425f);
		colors [9] = Desaturate (anchorColor, .3625f);
		colors [10] = SetLevel (anchorColor, .75f);
		colors [11] = SetLevel (anchorColor, .5f);
		colors [12] = SetLevel (anchorColor, .25f);
		colors [13] = SetLevel (anchorColor, .125f);
		colors [14] = SetLevel (anchorColor, .0625f);


		spawnGrid.GridLoop ();
	}
	
	Color SetAlpha(Color col, float alpha)
	{
		col.a *= alpha;
		return col;
	}
	
	Color RandomSaturated(Color rgbColor)
	{
		float myH, myS, myV;
		ColorConvert.RGBToHSV (rgbColor, out myH, out myS, out myV);
		Color returnColor = ColorConvert.HSVToRGB (myH, Random.Range (.5f, 1f), Random.Range (.5f, 1f));
		return returnColor;
	}
	
	Color GoldenRatioColor(Color rgbColor)
	{
		float myH, myS, myV;
		ColorConvert.RGBToHSV (rgbColor, out myH, out myS, out myV);
		float goldH = myH + 0.618033988749895f;
		goldH = (goldH % 1f);
		Color returnColor = ColorConvert.HSVToRGB (goldH, myS, myV);
		return returnColor;
	}
	
	Color SetLevel (Color aColor, float level)
	{
		Color returnColor = new Color (level * aColor.r, level * aColor.g, level * aColor.b);
		return returnColor;
	}
	
	Color InvertColor (Color aColor)
	{
		Color returnColor = new Color (1.0f - aColor.r, 1.0f - aColor.g, 1.0f - aColor.b);
		return returnColor;
	}
	
	Color Desaturate(Color rgbColor, float saturation)
	{
		float myH, myS, myV;
		ColorConvert.RGBToHSV (rgbColor, out myH, out myS, out myV);
		
		Color returnColor = ColorConvert.HSVToRGB (myH, myS * saturation, myV);
		return returnColor;
	}
}
