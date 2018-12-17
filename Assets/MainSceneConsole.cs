using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneConsole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < enemies.Length; i++) {
				enemies [i].transform.GetChild (2).GetComponent<EnemyAIHealth>().Die();
			
			}
		}
	}
}
