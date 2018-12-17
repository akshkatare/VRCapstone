using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Yes");
		if (other.gameObject.layer == 12) {
			Invoke ("LoadSceneMain", 1f);
		}
	}

	void LoadSceneMain()
	{
		this.GetComponent<SteamVR_LoadLevel> ().Trigger ();
	}
}
