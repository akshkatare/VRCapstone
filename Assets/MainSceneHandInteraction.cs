using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class MainSceneHandInteraction : MonoBehaviour {

    float tempTime;
    bool isusing;
    public PlayableDirector pb;
    private void Start()
    {
        isusing = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        tempTime = Time.time;    
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isusing)
        {
            if (other.gameObject.layer == 13)
            {
                other.GetComponent<SetColors>().SetSelected();
            }

            if (Time.time - tempTime > 1f)
            {
                isusing = true;
                other.GetComponent<SetColors>().SetUse();
                pb.Play();
                other.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            other.GetComponent<SetColors>().SetOriginal();
        }
    }
   
}
