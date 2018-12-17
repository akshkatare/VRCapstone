using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth instance;
    public int Health;
    public bool isDead;
	public Light lght;
	// Use this for initialization
	void Start () {
        instance = this;
        isDead = false;
	}

    public void Damage(int value)
    {


		Debug.Log (lght.intensity);
		Health = Health - (int)(value/2);
		lght.range = (Health * 4) / 100;
        if (Health <= 0)
        {
            isDead = true;
			Die ();
        }
    }

    public void Regenrate(int value)
    {
        Health = Health + value;
        if (Health > 100)
        {
            Health = 100;
        }
    }
	public void Die()
	{
		this.GetComponent<SteamVR_LoadLevel> ().Trigger ();
	}
}
