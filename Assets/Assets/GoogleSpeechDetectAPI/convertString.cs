using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class convertString : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<UnityEngine.UI.Text> ().text = GameObject.Find ("GlyphSub").GetComponent<glyphsubScript> ().retSubString (this.GetComponent<UnityEngine.UI.Text> ().text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
