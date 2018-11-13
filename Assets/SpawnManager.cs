using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


                    
    public float spawnTime = 5f;            
    public Transform[] spawnPoints;
    float timer;
    float temp;

    public GameObject[] Enemies;
    public GameObject[] SpawnPoint;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer =timer + Time.deltaTime;
        if (!PlayerHealth.instance.isDead)
        {
            if (timer > spawnTime)
            {
                Spawn();
            }

        }
    }

    void Spawn()
    {
       temp= Random.Range(0f, 100f);
        if (temp > 30)
        {
            
        }
    }
}
