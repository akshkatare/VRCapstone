using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterRecordingCollider : MonoBehaviour {

	void Start()
	{
		SceneManagerSpeech.instance.StartRecording ();
		Debug.Log ("1");
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.gameObject.layer==8) {
			Debug.Log ("SwordEnter");
			SceneManagerSpeech.instance.StartRecording ();
		}
	}


}
