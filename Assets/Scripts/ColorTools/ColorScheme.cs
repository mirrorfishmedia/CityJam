using UnityEngine;
using System.Collections;

public class ColorScheme : MonoBehaviour {

	public bool randomizeColors;

	public Color anchorColor;

	public Color opposingColor;

	public Color gCAnchor;
	public Color gCOppose;

	public Material anchorColorMatFullSat;
	public Material anchorColorMatHalfSat;
	public Material anchorColorMatQtrSat;
	public Material anchorColorDarkMat;
	public Material anchorColorVDarkMat;

	public Material opposingColorMatFullSat;
	public Material opposingColorMatHalfSat;
	public Material opposingColorMatQtrSat;
	public Material opposingColorMatTenSat;
	public Material opposingColorDarkMat;

	public Material gCAnchorMat;
	public Material gCAnchorHalfSatMat;
	public Material gCDarkHalfSatMat;

	public Material gCOpposeMat;

	public Material particleColorMat;
	public Material waterColorMat;
	public Material skyBox;
	public Material parasolMat;
	public Material beachChairMat;

	public Color skyColor;


	public Camera mainCamera;
//	public CamUnderWater waterCamScript;


	public Color anchorColorHalfSat;
	public Color opposingColorHalfSat;

	// Use this for initialization
	void Start () {

		mainCamera = Camera.main;
		ColorChange ();

	
	}

	public void ColorChange()
	{
		if (randomizeColors) 
		{
			anchorColor = new Color(Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f));
			anchorColor = RandomSaturated (anchorColor);
		}
			
		
		opposingColor = InvertColor(anchorColor);
		anchorColorMatFullSat.color = anchorColor;
		opposingColorMatFullSat.color = opposingColor;
		
		
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
		
		gCAnchor = GoldenRatioColor(anchorColor);
		gCAnchorMat.color = gCAnchor;
		gCAnchorHalfSatMat.color = Desaturate(gCAnchor, .5f);
		gCAnchorHalfSatMat.color = SetAlpha(gCAnchor, .5f);
		gCDarkHalfSatMat.color = SetLevel(gCAnchorHalfSatMat.color,.5f);
		
		gCOppose = InvertColor (gCAnchorMat.color);

		gCOpposeMat.color = Desaturate (gCOppose, .25f);

		
		//gCOppose = GoldenRatioColor(opposingColor); 
		
		//opposingColorHalfSat = SetSaturation(opposingColor);
		
		skyColor = Desaturate (gCOppose, .25f);
		skyBox.SetColor ("_SkyTint", anchorColor);
		skyBox.SetColor ("_GroundColor", gCOppose);
		mainCamera.backgroundColor = skyColor;
		particleColorMat.color = InvertColor (skyColor);
		beachChairMat.color = gCAnchorHalfSatMat.color;
		parasolMat.color = gCAnchorHalfSatMat.color;
		
		RenderSettings.fogColor = skyColor;
		waterColorMat.color = SetAlpha (gCOppose, .5f);
		RenderSettings.ambientSkyColor = skyColor;
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
		//return returnColor;
	}
}
