using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmanager : MonoBehaviour {

	public GameObject loadingIcon;
	public GameObject Recording;
	public GameObject muted;
	public GameObject mutedText;
	// Use this for initialization
	public void startLoading()
	{
		loadingIcon.SetActive (true);
		Recording.SetActive (false);
		muted.SetActive (false);
		mutedText.SetActive(false);
	}
	public void startRecording()
	{
		Recording.SetActive (true);
		loadingIcon.SetActive (false);
		muted.SetActive (false);
		mutedText.SetActive(false);
	}
	public void startMuted()
	{
		muted.SetActive (true);
		loadingIcon.SetActive (false);
		Recording.SetActive (false);
	}
}
