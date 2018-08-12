using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject playership;
    public GameObject enemyprefab;
    public float timer;
    public float cooldown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = cooldown;
            Spawn();
        }
	}

    public void Spawn()
    {
        if (Random.Range(0, 3) == 1)
        {
            GameObject clone = Instantiate(enemyprefab, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<Enemy>().target = playership;
        }
    }
}
