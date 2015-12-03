using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {
	
	public Light sun;
	//public Light moon;
	public float secondsInFullDay = 120f;
	[Range(0,1)]
	public float currentTimeOfDay = 0;
	[HideInInspector]
	public float timeMultiplier = 1f;
	public Color fogColorDay;
	
	float sunInitialIntensity;
	float moonInitialIntensity;
	
	
	void Start() {
		sunInitialIntensity = sun.intensity;
		//moonInitialIntensity = moon.intensity;
	}
	
	void Update() {
		UpdateSun();
		
		currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
		
		if (currentTimeOfDay >= 1) {
			currentTimeOfDay = 0;
		}
	}
	
	void UpdateSun() {
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
		//moon.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 270f) - 90, 170, 0);
		
		float intensityMultiplier = 1;
		float moonIntensityMultiplier = 0;
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
			intensityMultiplier = 0F;
			moonIntensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.1f) * (1 / 0.02f));
			
			//RenderSettings.fogColor = Color.black;
			
		}
		else if (currentTimeOfDay <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
			moonIntensityMultiplier = 1f - intensityMultiplier;
			//RenderSettings.fogColor = fogColorDay;
		}
		else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
			moonIntensityMultiplier = 1f - intensityMultiplier;
		}
		
		//moon.intensity = moonInitialIntensity * moonIntensityMultiplier;

		sun.intensity = sunInitialIntensity * intensityMultiplier;
		RenderSettings.ambientIntensity = intensityMultiplier;
		RenderSettings.fogColor = fogColorDay * intensityMultiplier;
		
	}
}