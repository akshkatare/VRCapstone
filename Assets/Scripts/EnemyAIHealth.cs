using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHealth : MonoBehaviour {

    public int health;
    private EnemyAIAnimation animationScript;


	// Use this for initialization
	void Start () {
        animationScript = this.GetComponent<EnemyAIAnimation>();
	}

    public void Hit(int value)
    {
        health = health - value;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animationScript.Die();
		Invoke ("CallToDestroy",5f);
    }



	void CallToDestroy()
	{
		Destroy (this.gameObject);
	}
}
