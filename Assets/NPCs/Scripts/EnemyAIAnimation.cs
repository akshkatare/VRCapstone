using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAnimation : MonoBehaviour {

    public string[] HitAnims;
    public string WalkAnimName;
    public string RunAnimName;
    public string DieAnimName;
    public string IdleAnimName;
    private Animator anim;
    int temp;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Attack()
    {
        temp = Random.Range(0, HitAnims.Length - 1);
        //anim.Play(HitAnims[temp]);
        anim.SetTrigger(HitAnims[temp]);
    }

    public void Walk()
    {
        //anim.Play(WalkAnimName);
        anim.SetTrigger("Walk");
    }

    public void Run()
    {
        anim.Play(RunAnimName);
    }

   public void Die()
    {
      //  anim.Play(DieAnimName);
    }

    public void Idle()
    {
        anim.SetTrigger(IdleAnimName);
    }
}
