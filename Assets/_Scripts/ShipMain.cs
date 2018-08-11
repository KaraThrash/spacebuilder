using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipMain : MonoBehaviour {
    public int hp, batterypower,batterypowermax;
   
    public Player player;
    public Text hptext,batterytext, maxhptext, maxbatterytext;
    public Transform[] shipsquares;
    public List<GameObject> squares;
    public Dictionary<Vector2, GameObject> spacesOnShip;
    public GameObject shipspaceprefab;
    public GameObject spaceparent;
    public GameObject cam,pieceholder;
    public float cooldowntimer;
    // Use this for initialization
    void Start () {

        string tempstring = "I";
        while (tempstring.Length < hp) { tempstring += "I"; }
        hptext.text = tempstring;
        tempstring = "I";
        while (tempstring.Length < batterypower) { tempstring += "I"; }
        batterytext.text = tempstring;
         tempstring = "I";
        while (tempstring.Length < batterypowermax) { tempstring += "I"; }
        maxbatterytext.text = tempstring;
        // List<GameObject> squares = new List<GameObject>();
        // Dictionary<Vector2, GameObject> spacesOnShip = new Dictionary<Vector2, GameObject>();
        // string tempstring = "";
        //foreach (Transform child in transform)
        // {
        //     child.GetComponent<ShipSpace>().shiplocation = new Vector2(child.localPosition.x, child.localPosition.y);
        //      tempstring = child.GetComponent<ShipSpace>().shiplocation.x + "" + child.GetComponent<ShipSpace>().shiplocation.y;
        //     child.name = child.GetComponent<ShipSpace>().shiplocation.x + "" + child.GetComponent<ShipSpace>().shiplocation.y;
        //     spacesOnShip.Add(child.GetComponent<ShipSpace>().shiplocation, child.gameObject);
        // }
        //Debug.Log(spacesOnShip[new Vector2(1,1)] + "stuff");

    }

    // Update is called once per frame
    void Update () {
        spaceparent.transform.position = this.transform.position;
        spaceparent.transform.rotation = this.transform.rotation;
        cam.transform.position = transform.position;

        if (batterypower < batterypowermax)
        {
            cooldowntimer += Time.deltaTime;
            if (cooldowntimer >= 2)
            {
                batterypower++; cooldowntimer = 0;
                string tempstring = "I";
                while (tempstring.Length < batterypower) { tempstring += "I"; }
                batterytext.text = tempstring;
            }
        }

       // cam.transform.rotation = transform.rotation;
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hptext.text = "DEAD";
        }
        else
        {
            string tempstring = "I";
            while (tempstring.Length < hp) { tempstring += "I"; }
            hptext.text = tempstring;
        }
    }
    public void ChangeBatteries(int newbatterypower)
    {
        batterypowermax += newbatterypower;
        if (batterypowermax <= 0) { batterypowermax = 0; }
        string tempstring = "I";
        while (tempstring.Length < batterypowermax) { tempstring += "I"; }
        maxbatterytext.text = tempstring;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" )
        {
           
                TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);

            
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Engine")
        {
            TakeDamage(1);
        }

    }
}
