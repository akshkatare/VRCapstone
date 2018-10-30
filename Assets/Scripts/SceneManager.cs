using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneManager : MonoBehaviour {

	public static SceneManager instance;
	LightmapData[] lightmap_data;
    public GameObject SceneLight;
	public PlayableDirector SoulTimeline;

	private void Start()
	{
		instance = this;
		lightmap_data = LightmapSettings.lightmaps;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.W))
			{
			enableLightmaps ();
            SceneLight.SetActive(true);
			}
		if(Input.GetKeyDown(KeyCode.A))
				{
			disableLightmaps ();
            SceneLight.SetActive(false);
        }
	}

	public void ActivateSoulScene()
	{
		SoulTimeline.Play ();
	}

	public void disableLightmaps()
	{
		// Disable lightmaps in scene by removing the lightmap data references
		LightmapSettings.lightmaps = new LightmapData[]{};
	}

	public void enableLightmaps()
	{
		LightmapSettings.lightmaps = lightmap_data;
	}






}
