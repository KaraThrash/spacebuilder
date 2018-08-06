using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMain : MonoBehaviour {
    public Transform[] shipsquares;
    public List<GameObject> squares;
    public Dictionary<Vector2, GameObject> spacesOnShip;
    public GameObject shipspaceprefab;
	// Use this for initialization
	void Start () {
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
		
	}
    

}
