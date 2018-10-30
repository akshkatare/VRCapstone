using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
[RequireComponent (typeof (AudioSource))]

public class LoopSpeech: MonoBehaviour {


	public string ApiUrl = "https://speech.googleapis.com/v1/speech:recognize?key=AIzaSyDL6PZCQbA8qrQ9DQ1lvbfKaqbbzt3E_E0";
	[HideInInspector]
	//public string filepath;
	string audiodata ;
	byte[] testByteArray;
    public Text TextBox;

    public Text wordBox;
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

    void Start () {
				
				if(Microphone.devices.Length <= 0)
				{
						Debug.LogWarning("Microphone not connected!");
				}
				else
				{
						micConnected = true;
						Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
						if(minFreq == 0 && maxFreq == 0)
						{
								maxFreq = 16000;
						}
						goAudioSource = this.GetComponent<AudioSource>();
				}
	} 



	IEnumerator CounterCheck(float WaitSec)
	{
		shouldListen = false;

		if (micConnected) {
			if (!Microphone.IsRecording (null)) {
				shouldListen = false;
				goAudioSource.clip = Microphone.Start (Microphone.devices[0], false, 2, maxFreq);
				//Debug.Log (goAudioSource.clip.frequency);
			}
		} else {
			Debug.Log ("No Microphone Connected");
		}
			yield return new WaitForSeconds (WaitSec);
		CheckInput ();shouldListen = true;
	}



    void CheckInput()
    {
        
					float filenameRand = UnityEngine.Random.Range (0.0f, 10.0f);

					string filename = "testing" ;

					Microphone.End(null); //Stop the audio recording

					//Debug.Log( "Recording Stopped");
	
					if (!filename.ToLower().EndsWith(".wav")) {
						filename += ".wav";
					}

					var filePath = Path.Combine("testing/", filename);
					filePath = Path.Combine(Application.persistentDataPath, filePath);
					//Debug.Log("Created filepath string: " + filePath);
		//wordBox.text="Saving @ " + filePath;
					// Make sure directory exists if user is saving to sub dir.
					Directory.CreateDirectory(Path.GetDirectoryName(filePath));
					SavWav.Save (filePath, goAudioSource.clip); //Save a temporary Wav File
					//Debug.Log( "Saving @ " + filePath);

					/*google_speech gs = Caller.GetComponent<google_speech>();
					gs.filepath = filePath;
					gs.sendRequest ();*/
					sendRequest (filePath);
					

					//File.Delete(filePath); 

    }


	public bool sendRequest(String filepath)
	{
		//Debug.Log (Application.persistentDataPath);


		//audiodata = System.IO.File.ReadAllText (Application.persistentDataPath + "/myjson.txt");

		audioClass a=new audioClass();
		configClass c = new configClass ();
		RootObject r = new RootObject ();

		testByteArray = System.IO.File.ReadAllBytes (filepath);
		a.content= System.Convert.ToBase64String (testByteArray);
		c.encoding = "LINEAR16";
		c.languageCode = "hi";
		c.sampleRateHertz = 44100;

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
	IEnumerator APIAction (WWW req) {


		yield return req;

		//Debug.Log (req.text);
		//wordBox.text=req.text;
		jsonParse(req.text);
	}

	void jsonParse(string text)
	{
		string[] s = text.Split ('{');


		/*	for (int i = 0; i < s.Length; i++) {
			Debug.Log (s[i]);
		}*/
		//Debug.Log (s.Length);
		if (s.Length > 2) {
			string[] s2 = s [3].Split ('"');
			/*for (int i = 0; i < s2.Length; i++) {
			Debug.Log (s2[i]);
		}*/
			//Debug.Log(text.Split('{'));
			Debug.Log (s2 [3]);
			TextBox.text = s2 [3];
            //Debug.Log (s2 [3] .Contains("हेलो"));

		//	wordBox.text += s2 [3];
            wordBox.text += " : "+s2[3];
			Debug.Log (s2[3]);
			if (s2 [3] .Contains("ऊपर") ){
				wordBox.text = "UP";
			}
			if (s2 [3] .Contains("नीचे") ){
				wordBox.text = "DOWN";
			}
			if (s2 [3] .Contains("आगे") ){
				wordBox.text = "RIGHT";	
			}
			if (s2 [3] .Contains("पीछे") ){
				wordBox.text = "LEFT";
			}


		}




	}


	void Update()
	{
		//CheckInput ();
		if (shouldListen == true) {
			StartCoroutine (CounterCheck (2));
			Debug.Log ("Listening");
		} else {

			//Debug.Log ("Not Listening");
		}
	}




































	/*	void OnGUI() 
		{
				//If there is a microphone
				if(micConnected)
				{
						//If the audio from any microphone isn't being recorded
						if(!Microphone.IsRecording(null))
						{
								//Case the 'Record' button gets pressed
								if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Record"))
								{
										//Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource
										goAudioSource.clip = Microphone.Start( null, true, 5, maxFreq); //Currently set for a 7 second clip
								}
						}
						else //Recording is in progress
						{
								
								//Case the 'Stop and Play' button gets pressed
								if(GUI.Button(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Stop and Play!"))
								{
										float filenameRand = UnityEngine.Random.Range (0.0f, 10.0f);

										string filename = "testing" ;

										Microphone.End(null); //Stop the audio recording

										Debug.Log( "Recording Stopped");

										if (!filename.ToLower().EndsWith(".wav")) {
												filename += ".wav";
										}

										var filePath = Path.Combine("testing/", filename);
										filePath = Path.Combine(Application.persistentDataPath, filePath);
										Debug.Log("Created filepath string: " + filePath);

										// Make sure directory exists if user is saving to sub dir.
										Directory.CreateDirectory(Path.GetDirectoryName(filePath));
										SavWav.Save (filePath, goAudioSource.clip); //Save a temporary Wav File
										Debug.Log( "Saving @ " + filePath);
                    Caller.SetActive(true);
                    google_speech gs = Caller.GetComponent<google_speech>();
                    gs.filepath = filePath;

                                        //File.Delete(filePath); //Delete the Temporary Wav file
									
								}

								GUI.Label(new Rect(Screen.width/2-100, Screen.height/2+25, 200, 50), "Recording in progress...");
						}
				}
				else // No microphone
				{
						//Print a red "Microphone not connected!" message at the center of the screen
						GUI.contentColor = Color.red;
						GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Microphone not connected!");
				}
		}
*/
		
	

}
		