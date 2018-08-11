using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPiece : MonoBehaviour {
    public Player player;
    public int type; //0 laser 1 engine 2 shield
    public int rotations; // for attaching to the ship when it is rotated relative to the camera
    public int connections;
    public bool connector0, connector1, connector2, connector3;
    public bool destroyed;
    public bool placed;
    public bool  partactivated;//engines or shields are turned on
    public float cooldown;
    public float cooldowntimer;
    public int hp;
    public int speed; // for engine strength
    public GameObject myspace;
    public GameObject prefabtospawn,activateObject; //bullet to spawn, or shield/engine to turn on
    public GameObject gun;
    public GameObject explosion;
    // Use this for initialization
    void Start () {
        if (hp <= 0) { hp = 1; }
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldowntimer > 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
        if (partactivated == true)
        {
            if (type == 1)
            { myspace.GetComponent<ShipSpace>().mainShip.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * speed * Time.deltaTime,transform.position ); }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        { rotatepiece(); }



	}
    public void activate()
    {
        if (cooldowntimer <= 0)
        {
            cooldowntimer = cooldown;
            //TODO: change to switch case
            if (type == 0)
            {
                firelasers();
            }
            else if (type == 1)
            {
                useengines();
            }
            else if (type == 2)
            {
                turnonshields();
            }
            else { }
        }
    }
    public void OnMouseDown()
    {
        if (placed == false && destroyed == false)
        {
            if (player.selectedpiece == this.gameObject)
            { rotatepiece(); }
            else
            { player.PieceSelected(this.gameObject); }
           
        }
    }
    public void rotatepiece()
    {
        if (placed == false)
        {
            bool tempconnector = connector3;
            connector3 = connector2;
            connector2 = connector1;
            connector1 = connector0;
            connector0 = tempconnector;
            transform.Rotate(0, 90, 0);
            rotations++;
            if (rotations > 3) { rotations = 0; }
        }
    }
    public void firelasers() { Instantiate(prefabtospawn, gun.transform.position, gun.transform.rotation); }
    public void useengines() {
        if (partactivated == true) { activateObject.active = false; partactivated = false; } else { partactivated = true; activateObject.active = true; }
       // Instantiate(prefabtospawn, gun.transform.position, gun.transform.rotation);

    }
    public void turnonshields() { if (partactivated == true) { activateObject.active = false; partactivated = false; } else { partactivated = true; activateObject.active = true; } }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            destroyed = true;
            Instantiate(explosion, transform.position, transform.rotation);
            if (myspace != null) { myspace.GetComponent<ShipSpace>().mypiecedestroyed(); }
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && destroyed == false)
        {
            if (type == 2 && partactivated == true) {
                activateObject.active = false;
                partactivated = false;

            }
            else
            {
                TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
                
            }
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && type == 2)
        {
                activateObject.active = false;
                partactivated = false;
                Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Engine")
        {
            TakeDamage(hp);
        }

    }
}
