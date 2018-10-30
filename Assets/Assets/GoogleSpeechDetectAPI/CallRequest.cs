using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
public class CallRequest : MonoBehaviour {

	AudioClip clip;
	public GameObject cmd;
	public string ApiUrl = "https://speech.googleapis.com/v1/speech:recognize?key=AIzaSyC35HKlPk88k16bC4oDQAyzAhNUgeOeBGQ";
	[HideInInspector]
	//public string filepath;
	string audiodata ;
	byte[] testByteArray;

	bool shouldListen=true;
	const int HEADER_SIZE = 44;
	private int minFreq;
	private int maxFreq;
	private bool micConnected = false;
	private AudioSource goAudioSource;
	struct ClipData
	{
		public int samples;
	}

	// Use this for initialization
	void Start () {
		
	}


	IEnumerator APIAction (WWW req) {


		yield return req;

		//Debug.Log (req.text);
		//wordBox.text=req.text;
		jsonParse(req.text);
	}

	void jsonParse(string text)
	{
		string[] s= text.Split ('{');
		Debug.Log (text);
		if (s.Length > 2) {
			
			string[] s2 = s [3].Split ('"');

			Debug.Log (s2 [3]);

			cmd.GetComponent<CommandControl> ().getCommand(s2[3]);
		} 

	}

	public void CheckInput( AudioClip c)
	{
		clip = c;
		string filename = "testing" ;
		if (!filename.ToLower().EndsWith(".wav")) {
			filename += ".wav";
		}
		string filePath = Path.Combine("testing/", filename);
		filePath = Path.Combine(Application.persistentDataPath, filePath);
		//Debug.Log("Created filepath string: " + filePath);
		//wordBox.text="Saving @ " + filePath;
		// Make sure directory exists if user is saving to sub dir.
		Directory.CreateDirectory(Path.GetDirectoryName(filePath));
		SavWav.Save (filePath, c); //Save a temporary Wav File
		//Debug.Log( "Saving @ " + filePath);

		/*google_speech gs = Caller.GetComponent<google_speech>();
					gs.filepath = filePath;
					gs.sendRequest ();*/
		sendRequest (filePath);


		//File.Delete(filePath); 

	}



	public bool sendRequest(string filepath)
	{
		//Debug.Log (Application.persistentDataPath);


		//audiodata = System.IO.File.ReadAllText (Application.persistentDataPath + "/myjson.txt");

		audioClass a=new audioClass();
		configClass c = new configClass ();
		RootObject r = new RootObject ();

		testByteArray = System.IO.File.ReadAllBytes (filepath);
		a.content= System.Convert.ToBase64String (testByteArray);
		c.encoding = "LINEAR16";
		c.languageCode = "en";
		c.sampleRateHertz = 16000;

		r.audio = a;
		r.config = c;

		audiodata = JsonUtility.ToJson (r);

		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");

		// convert json string to byte
		var formData = System.Text.Encoding.UTF8.GetBytes(audiodata);

		www = new WWW(ApiUrl, formData, postHeader);


		StartCoroutine (APIAction(www));

		//Debug.Log ("Done Send Request");
		return true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class audioClass
{
	public string content;
}
[System.Serializable]
public class configClass
{
	public string encoding;
	public int sampleRateHertz;
	public string languageCode;

}
[System.Serializable]
public class RootObject
{
	public audioClass audio;
	public configClass config;
}