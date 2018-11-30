using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIController : MonoBehaviour {

    private NavMeshAgent navAgent;
    public string currentState;
    public GameObject Player;
    public float timeBetweenAttacks;
    private EnemyAIAnimation aiAnimationScript;

    float timer;
	// Use this for initialization
	void Start () {
        navAgent = this.GetComponent<NavMeshAgent>();
        aiAnimationScript = this.GetComponent<EnemyAIAnimation>();
        currentState = "Born";
		Player = GameObject.FindGameObjectWithTag ("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;


        if (currentState == "Born")
        {
            currentState = "ChaseRun";
            aiAnimationScript.Run();
            navAgent.SetDestination(Player.transform.position);
        }

        if (currentState == "ChaseRun")
        {
            navAgent.SetDestination(Player.transform.position);
            if (Vector3.Distance(this.transform.position, Player.transform.position) < 2f)
              {
                  //Debug.Log("Attack");
                  navAgent.isStopped = true;
                  currentState = "Attack";
                aiAnimationScript.Idle();
            }
            
            
        }


        if (currentState == "Attack")
        {
            
            if (timer > timeBetweenAttacks)
            {
                timer = 0f;
                aiAnimationScript.Attack();
            }

            if (Vector3.Distance(this.transform.position, Player.transform.position) > 2f)
            {
                currentState = "Walk";
              //  Debug.Log("GotoWalk");
                navAgent.isStopped = false;
                // Debug.Log(currentState);
                aiAnimationScript.Walk();
            }
        }
      
        
         

        if (currentState == "Walk")
        {
           // Debug.Log("Walking");
            navAgent.SetDestination(Player.transform.position);
           // Debug.Log(navAgent.destination);
            if (Vector3.Distance(this.transform.position, Player.transform.position) < 2f)
            {
                //Debug.Log("GotoAttack");
                currentState = "Attack";
            }
            
        }
       
       

       

        
        

	}





}
