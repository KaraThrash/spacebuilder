using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPiece : MonoBehaviour {
    public Player player;
    public int type; //0laser 1 engine 2 shield
    public int connections;
    public bool destroyed;
    public bool placed;
    public float cooldown;
    public float cooldowntimer;
    public int hp;
    public GameObject myspace;
    public GameObject prefabtospawn;
    public GameObject gun;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldowntimer > 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
	}
    public void activate()
    {
        if (cooldowntimer <= 0)
        {
            cooldowntimer = cooldown;
            if (type == 0)
            {
                firelasers();
            }
            else if (type == 1)
            {
                useengines();
            }
            else
            {
                turnonshields();
            }
        }
    }
    public void OnMouseDown()
    {
        if (placed == false)
        {
            player.selectedpiece = this.gameObject;
        }
    }

    public void firelasers() { Instantiate(prefabtospawn, transform.position, transform.rotation); }
    public void useengines() { Instantiate(prefabtospawn, transform.position, transform.rotation); }
    public void turnonshields() { Instantiate(prefabtospawn, transform.position, transform.rotation); }
    public void takedmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            if (myspace != null) { myspace.GetComponent<ShipSpace>().mypiecedestroyed(); }
        }
    }

}
