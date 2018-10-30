using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterRecordingCollider : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.gameObject.layer==8) {
			Debug.Log ("SwordEnter");
		}
	}


}
