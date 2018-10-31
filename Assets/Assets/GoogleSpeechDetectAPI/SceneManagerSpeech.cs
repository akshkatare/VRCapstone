//----------------------------------------------------------------------------------
// Speech Auto Detector
// Copyright (c) 2017 Garpix Ltd.
//
// Author Homepage: https://garpix.com
// Support: support@garpix.com
// License: Asset Store Terms of Service and EULA
// License URI: See LICENSE file in the project root for full license information.
//----------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneManagerSpeech : MonoBehaviour
{
    #region variables

    public AudioRecorder recorder;
    public AudioPlayer player;
	public static SceneManagerSpeech instance;
    private AudioClip _currentClip;

    #endregion

	void Start()
	{
		instance = this;
	}

    void OnDestroy()
    {
        Unsubscribe();
    }


    private void Subscribe()
    {
        if (recorder != null)
            recorder.OnRecordingEnd.AddListener(OnRecordingEnd);
        if (player != null)
            player.OnPlaybackEnd.AddListener(OnPlayingEnd);
    }

    private void Unsubscribe()
    {
        if (recorder != null)
            recorder.OnRecordingEnd.RemoveListener(OnRecordingEnd);
        if (player != null)
            player.OnPlaybackEnd.RemoveListener(OnPlayingEnd);
    }

    public  void StartRecording()
    {
		Debug.Log ("1");
        Subscribe();
		if (recorder != null)
			recorder.StartRecording ();
		else {
		}
    }

    private void StopRecording()
    {
        Unsubscribe();
        if (recorder != null)
            recorder.StopRecording();
		
        if (player != null)
            player.StopPlaying();
    }

    private void OnRecordingEnd(AudioClip clip)
    {
        _currentClip = clip;
        if (player != null)
            player.StartPlaying(clip);
        else OnPlayingEnd(false);
    }

    private void OnPlayingEnd(bool b)
    {
        if (_currentClip != null)
            Destroy(_currentClip);
        if (b)
            if (recorder != null)
                recorder.StartRecording();
    }
}