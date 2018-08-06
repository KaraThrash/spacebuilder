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
        temppiece = GameObject.Find("temppiece");

       // shiplocation = new Vector2(transform.localPosition.x, transform.localPosition.y);
       // this.transform.name = (shiplocation.x + "" + shiplocation.y);
       // Debug.Log(transform.name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectTo()
    {//when a square adjacent enables this piece to be used
        adjacentpossibleconnections++;
        adjacenttosetpiece = true;
        GetComponent<Renderer>().material = setable;

    }
    public void Disconnectfrom()
    {//when a square adjacent enables this piece to be used
        adjacentpossibleconnections--;
        if (adjacentpossibleconnections <= 0)
        {
            adjacentpossibleconnections = 0;
               adjacenttosetpiece = false;
            GetComponent<Renderer>().material = disabled;
        }
    }
    public void makenewconnection(Vector2 newloc,int whichconnection)
    {
       
        GameObject clone = Instantiate(newpiece, transform.position + new Vector3(newloc.x,newloc.y,0), transform.rotation) as GameObject;
        clone.transform.parent = this.transform;
       // clone.GetComponent<ShipSpace>().connections[whichconnection] = -1;
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
                GetComponent<Renderer>().enabled = false;
                //shippart.transform.rotation = this.transform.rotation;
                player.updateshippartlist() ;

                if (topneighbor != null) { topneighbor.UpdateConnections(1); }
                if (botneighbor != null) { botneighbor.UpdateConnections(1); }
                if (leftneighbor != null) { leftneighbor.UpdateConnections(1); }
                if (rightneighbor != null) { rightneighbor.UpdateConnections(1); }
              
            }
        }

        //SetPiece(temppiece);


    }
    public void UpdateConnections(int upordown)
    {
        connections += upordown;//-1 if connection destroyed 1 if adding
        if (connections < 0) { connections = 0; }//float away into space ??can it still activate?
        else
        {
            if (shippart == null) { GetComponent<Renderer>().enabled = true; }
        }

        //if (connections > 4) { connections = 4; } //?leave open ended for special pieces later?

    }
    public void mypiecedestroyed()
    {
        Destroy(shippart);
        shippart = null;
        if (topneighbor != null) { topneighbor.UpdateConnections(-1); }
        if (botneighbor != null) { botneighbor.UpdateConnections(-1); }
        if (leftneighbor != null) { leftneighbor.UpdateConnections(-1); }
        if (rightneighbor != null) { rightneighbor.UpdateConnections(-1); }
    }

}
