using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpace : MonoBehaviour {
    public Player player;
    public GameObject mainShip;
    public GameObject shippart;
    public GameObject newpiece;
    public GameObject temppiece;
    public Vector2 shiplocation; //distance from main node, then distance around the circle starting from 12oclock
    public ShipSpace topneighbor, botneighbor, leftneighbor, rightneighbor;
    public int connections; // this connection's type, hasconnection,to main node or not // {-1 || 0 || 1,-1 ||0 || 1}
    //0 space 1 above, 1 right, 2 down, 3 left

    public bool connectedtomainship;
    public int activeconnections;
    public int adjacentpossibleconnections;
    public bool adjacenttosetpiece;
    public bool haspiece;
    public Material disabled;
    public Material setable;
 

    // Use this for initialization
    void Start () {
       // temppiece = GameObject.Find("temppiece");

       // shiplocation = new Vector2(transform.localPosition.x, transform.localPosition.y);
       // this.transform.name = (shiplocation.x + "" + shiplocation.y);
       // Debug.Log(transform.name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   

    public void SetPiece(GameObject newpiece)
    {
        //GetComponent<Renderer>().material = setable;
        //// List<Vector3> connections = newpiece.GetComponent<ShipPiece>().connections;
        //switch (newpiece.GetComponent<ShipPiece>().connections)
        //{
        //    case 1: connections[0] = -1; break;
        //    case 2: connections[0] = -1; connections[1] = -1; break;
        //    case 3: connections[0] = -1; connections[1] = -1; connections[2] = -1; break;
        //    case 4: connections[0] = -1; connections[1] = -1; connections[2] = -1; connections[3] = -1; break;
        //    case 5: connections[0] = -1; connections[2] = -1; break;
        //    case 6: connections[1] = -1; connections[3] = -1; break;
        //    default: break;

        //}
        //if (connections[0] != -1)
        //    { makenewconnection(new Vector2(0,1),0); }
        //if (connections[1] != -1)
        //{ makenewconnection(new Vector2(-1, 0),1); }
        //if (connections[2] != -1)
        //{ makenewconnection(new Vector2(0, -1),2); }

        //if (connections[3] != -1)
        //{ makenewconnection(new Vector2(1, 0),3); }
        ////mainShip.GetComponent<ShipMain>().ConnectingPieces(shiplocation);

    }
    public void OnMouseDown()
    {
        if (shippart != null) { shippart.GetComponent<ShipPiece>().activate(); }

       
        if (connections > 0)
        {
            if (shippart == null && player.selectedpiece != null)
            {
                shippart = player.selectedpiece;
                shippart.transform.position = this.transform.position;
                shippart.GetComponent<ShipPiece>().placed = true;
                shippart.GetComponent<ShipPiece>().myspace = this.gameObject;
                GetComponent<Renderer>().enabled = false;
                //shippart.transform.rotation = this.transform.rotation;
                player.Addpiece(shippart);

                if (topneighbor != null && shippart.GetComponent<ShipPiece>().connector0 == true) { topneighbor.UpdateConnections(1); }
                if (botneighbor != null && shippart.GetComponent<ShipPiece>().connector2 == true) { botneighbor.UpdateConnections(1); }
                if (leftneighbor != null && shippart.GetComponent<ShipPiece>().connector3 == true) { leftneighbor.UpdateConnections(1); }
                if (rightneighbor != null && shippart.GetComponent<ShipPiece>().connector1 == true) { rightneighbor.UpdateConnections(1); }
                shippart.transform.parent = this.transform;
                shippart.transform.rotation = this.transform.rotation;
                shippart.transform.Rotate(0, 90 * shippart.GetComponent<ShipPiece>().rotations, 0);
            }
        }

        //SetPiece(temppiece);


    }
    public void UpdateConnections(int upordown)
    {
        connections += upordown;//-1 if connection destroyed 1 if adding
        if (connections <= 0) {
            connections = 0;
            GetComponent<Renderer>().enabled = false;
            if (shippart != null)
            {
                if (topneighbor != null && shippart.GetComponent<ShipPiece>().connector0 == true) { topneighbor.UpdateConnections(-1); }
                if (botneighbor != null && shippart.GetComponent<ShipPiece>().connector2 == true) { botneighbor.UpdateConnections(-1); }
                if (leftneighbor != null && shippart.GetComponent<ShipPiece>().connector3 == true) { leftneighbor.UpdateConnections(-1); }
                if (rightneighbor != null && shippart.GetComponent<ShipPiece>().connector1 == true) { rightneighbor.UpdateConnections(-1); }
                player.Removepiece(shippart.GetComponent<ShipPiece>().type, shippart.GetComponent<ShipPiece>().speed);
                shippart.transform.parent = null;
                shippart.GetComponent<ShipPiece>().placed = false;
                shippart.GetComponent<Rigidbody>().isKinematic = false;
                shippart.GetComponent<Rigidbody>().AddForce((transform.position - mainShip.transform.position) * 300.0f * Time.deltaTime);
            }
        }//float away into space ??can it still activate?
        else
        {
            if (shippart == null && upordown == 0) { GetComponent<Renderer>().enabled = true; }
        }

        //if (connections > 4) { connections = 4; } //?leave open ended for special pieces later?

    }
    public void mypiecedestroyed()
    {
        if (shippart != null)
        {
            if (topneighbor != null && shippart.GetComponent<ShipPiece>().connector0 == true) { topneighbor.UpdateConnections(-1); }
        if (botneighbor != null && shippart.GetComponent<ShipPiece>().connector2 == true) { botneighbor.UpdateConnections(-1); }
        if (leftneighbor != null && shippart.GetComponent<ShipPiece>().connector3 == true) { leftneighbor.UpdateConnections(-1); }
        if (rightneighbor != null && shippart.GetComponent<ShipPiece>().connector1 == true) { rightneighbor.UpdateConnections(-1); }

            player.Removepiece(shippart.GetComponent<ShipPiece>().type, shippart.GetComponent<ShipPiece>().speed);
            Destroy(shippart);
            shippart = null;
        }
      
    }

}
