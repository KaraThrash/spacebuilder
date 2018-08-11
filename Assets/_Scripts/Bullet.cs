using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float lifetime;
    public int damage;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime,ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
       
        if (lifetime < 0) { Destroy(this.gameObject); }
        

	}
}
