using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHealth : MonoBehaviour {

    public int health;
    private EnemyAIAnimation animationScript;

	// Use this for initialization
	void Start () {
        health = 100;
	}

    public void Hit(int value)
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animationScript.Die();
    }

}
