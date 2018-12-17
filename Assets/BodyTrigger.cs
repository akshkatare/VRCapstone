using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrigger : MonoBehaviour {

	public Light light;
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name);
		if (other.gameObject.layer == 10) {
			this.transform.parent.GetComponent<PlayerHealth> ().Damage (10);		
			//light.intensity = light.intensity - 0.1f;
		}
		if (other.gameObject.layer == 9) {
			this.transform.parent.GetComponent<PlayerHealth> ().Damage (7);		
			//light.range = light.range - 0.2f;
		}
		if (other.gameObject.layer == 11) {
			this.transform.parent.GetComponent<PlayerHealth> ().Damage (15);		
			//light.range = light.range - 0.4f;
		}
		}
}
