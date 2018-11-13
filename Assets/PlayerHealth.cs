using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth instance;
    public int Health;
    public bool isDead;
	// Use this for initialization
	void Start () {
        instance = this;
        isDead = false;
	}

    public void Damage(int value)
    {
        Health = Health - value;
        if (Health <= 0)
        {
            isDead = true;
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
}
