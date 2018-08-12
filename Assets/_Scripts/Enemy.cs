using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject itemdrop;
    public GameObject bullet,gun1,gun2;
    public int hp;
    public GameObject target;
    public int speed;
    public float rotspeed;
    private Rigidbody rb;
    public float guncooldown;
    public float timer;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            FaceTarget();
            if (Vector3.Distance(transform.position, target.transform.position) > 5)
            {
                rb.AddForce(transform.forward * speed * Time.deltaTime);
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                { FireGuns(); timer = guncooldown; }

            }

        }
	}
    public void FireGuns()
    {
        Instantiate(bullet, gun1.transform.position, gun1.transform.rotation);
        //Instantiate(bullet, gun2.transform.position, gun2.transform.rotation);
    }
    public void FaceTarget()
    {
        Vector3 targetDir = target.transform.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotspeed * Time.deltaTime, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
           
            Instantiate(itemdrop, gun1.transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
                TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);

            
            Destroy(collision.gameObject);
        }
    }
}
