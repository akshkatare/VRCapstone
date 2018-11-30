using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


                    
    public float spawnTime = 5f;            
    public Transform[] spawnPoints;
    float timer;
    float tempObject;
	float tempPosition;

    public GameObject[] Enemies;
    
    
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timer =timer + Time.deltaTime;
        //if (!PlayerHealth.instance.isDead)
       // {
            if (timer > spawnTime)
            {
                Spawn();
			timer = 0f;
            }

       // }
    	 }

    void Spawn()
    {
       tempObject= Random.Range(0f, 100f);
		tempPosition = Random.Range (0f, spawnPoints.Length - 1);

		if (tempObject < 40f && tempObject>0f) 
		{
			Instantiate (Enemies [0], spawnPoints [(int)tempPosition].transform.position, spawnPoints[(int)tempPosition].transform.rotation,null);   
		} 

		else if (tempObject >= 40f && tempObject < 80f) 
		{
			Instantiate (Enemies [1], spawnPoints[(int)tempPosition].transform.position, spawnPoints[(int)tempPosition].transform.rotation, null);
        }

		else 
		{
			Instantiate (Enemies [2], spawnPoints[(int)tempPosition].transform.position, spawnPoints[(int)tempPosition].transform.rotation, null);
        }
    }
}
