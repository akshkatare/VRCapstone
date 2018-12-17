using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class EnterMainZone : MonoBehaviour {
	public PlayableDirector pb;
	public AudioSource battleAudio;
	public GameObject SpawnManagerObject;
	public GameObject Target;
	public GameObject Target2;
/*	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 12) {
			Debug.Log ("Playing");
			pb.Play ();
			battleAudio.Play ();
			Invoke ("StartSpawning", 15f);
		}
	}*/
	void StartSpawning()
	{SpawnManagerObject.SetActive (true);
	}

	void Update()
	{
		if (Vector3.Distance (Target.transform.position, Target2.transform.position) < 2f) {
			Debug.Log ("Playing");
			pb.Play ();
			battleAudio.Play ();
			Invoke ("StartSpawning", 15f);
			this.GetComponent<EnterMainZone> ().enabled = false;
		}
	}

}
