using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class HoldTimeline : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (this.GetComponent<PlayableDirector> ().time >= 16.5f) {
			this.GetComponent<PlayableDirector> ().Pause ();
		}
	}
}
