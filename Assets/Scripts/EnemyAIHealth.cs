using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class EnemyAIHealth : MonoBehaviour {

    public int health;
    private EnemyAIAnimation animationScript;
	public SkinnedMeshRenderer thisBody;
	public Material GhostMaterial;
	public bool isDead;
	//public Mater
	// Use this for initialization
	void Start () {
		isDead = false;
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
	{isDead = true;
        animationScript.Die();
		this.transform.parent.transform.GetChild (1).GetComponent<PuppetMaster> ().state = PuppetMaster.State.Dead;
		this.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Invoke ("TurnToGhost", 1.5f);
		Invoke ("Fade", 6f);
		Invoke ("CallToDestroy",7f);
    }



	void CallToDestroy()
	{
		Destroy (this.transform.parent.gameObject);
	}

	void TurnToGhost()
	{
		thisBody.material = GhostMaterial;
	}

	void Fade()
	{
		StartCoroutine(FadeTo(0.0f,1f));
	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = thisBody.material.GetFloat("_Transparency");
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			float newColor =Mathf.Lerp(alpha,aValue,t);
			thisBody.material.SetFloat ("_Transparency", newColor);
			yield return null;
		}
	}
}
