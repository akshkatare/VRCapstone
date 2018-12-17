using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleMusic : MonoBehaviour {

	public AudioSource audio;
	public AudioSource ambientAudio;

	// Use this for initializ
	void Start()
	{
		ambientAudio.Play ();
		audio.Stop ();
	}
	void OnEnable()
	{
		ambientAudio.Stop ();
		audio.Play ();
	}
	void OnDisable()
	{audio.Stop ();
		ambientAudio.Play ();
	}
}
