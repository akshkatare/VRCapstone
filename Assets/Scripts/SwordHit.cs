using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.transform.root.name);
		collision.transform.root.transform.GetChild(2).GetComponent<EnemyAIHealth>().Hit((int)(collision.relativeVelocity.magnitude*5f));


    }
}
