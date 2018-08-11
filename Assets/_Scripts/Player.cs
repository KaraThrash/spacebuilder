using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    
    public List<GameObject> guns = new List<GameObject>();
    public List<GameObject> engines = new List<GameObject>();
    public List<GameObject> shields = new List<GameObject>();
    public List<GameObject> batteries = new List<GameObject>();
    public GameObject selectedpiece;
    public GameObject holdpiecespot; //takes the selected piece off the map
    public Transform shipspaces;
    public ShipMain mainShipNode;
    // Use this for initialization
    void Start() {
      

    }



   
    // Update is called once per frame
    void Update()
    {
       
    }
    public void Addpiece(GameObject whichpiece )
    {
        if (whichpiece.GetComponent<ShipPiece>() != null)
        {
          
            Debug.Log(whichpiece.transform.name);
            if (selectedpiece.GetComponent<ShipPiece>().type == 0)
            {
              guns.Add(whichpiece);  //else { guns.Remove(whichpiece); }

            }
            else if (selectedpiece.GetComponent<ShipPiece>().type == 1)
            {
                engines.Add(whichpiece);  //else { engines.Remove(whichpiece); }

            }
            else if (selectedpiece.GetComponent<ShipPiece>().type == 2)
            {
               shields.Add(whichpiece); //else { shields.Remove(whichpiece); }

            }
            else if (selectedpiece.GetComponent<ShipPiece>().type == 3)
            {
                
                    batteries.Add(whichpiece);  //else { shields.Remove(whichpiece); }
                    mainShipNode.ChangeBatteries(selectedpiece.GetComponent<ShipPiece>().speed);
              // mainShipNode.ChangeBatteries(selectedpiece.GetComponent<ShipPiece>().speed * -1); 
            }
            else { }
            
        }
      
            selectedpiece = null;
            foreach (Transform child in shipspaces)
            {
                child.gameObject.GetComponent<Renderer>().enabled = false;
            }

        
            for (int i = guns.Count - 1; i > -1; i--)
            {
                if (guns[i] == null)
                    guns.RemoveAt(i);
            }
            for (int i = engines.Count - 1; i > -1; i--)
            {
                if (engines[i] == null)
                    engines.RemoveAt(i);
            }
            for (int i = shields.Count - 1; i > -1; i--)
            {
                if (shields[i] == null)
                    shields.RemoveAt(i);
            }
        for (int i = batteries.Count - 1; i > -1; i--)
        {
            if (batteries[i] == null)
                batteries.RemoveAt(i);
        }

    }
    public void Removepiece(int piecetype,int piecevalue)
    {
            if (piecetype == 0)
            {
             

            }
            else if (piecetype == 1)
            {
               

            }
            else if (piecetype == 2)
            {
                

            }
            else if (piecetype == 3)
            {
                
                 mainShipNode.ChangeBatteries(piecevalue * -1); 
            }
            else { }
        for (int i = guns.Count - 1; i > -1; i--)
        {
            if (guns[i] == null)
                guns.RemoveAt(i);
        }
        for (int i = engines.Count - 1; i > -1; i--)
        {
            if (engines[i] == null)
                engines.RemoveAt(i);
        }
        for (int i = shields.Count - 1; i > -1; i--)
        {
            if (shields[i] == null)
                shields.RemoveAt(i);
        }
        for (int i = batteries.Count - 1; i > -1; i--)
        {
            if (batteries[i] == null)
                batteries.RemoveAt(i);
        }


    }
    public void PieceSelected(GameObject newPiece)
    {
        if (selectedpiece != null)
        {
            GameObject temppiece = selectedpiece;
            selectedpiece = newPiece;
            temppiece.transform.position = selectedpiece.transform.position;
            
        }
        selectedpiece = newPiece;
        selectedpiece.transform.position = holdpiecespot.transform.position;
        selectedpiece.transform.rotation = holdpiecespot.transform.rotation;
        foreach (Transform child in shipspaces)
        {
            child.gameObject.GetComponent<ShipSpace>().UpdateConnections(0);
        }
    }
    public void UseAllTypeOfShipPart(int type)
    {
        // activated by canvas button
        // uses the action of all of one type of ship part
        for (int i = guns.Count - 1; i > -1; i--)
        {
            if (guns[i] == null)
                guns.RemoveAt(i);
        }
        for (int i = engines.Count - 1; i > -1; i--)
        {
            if (engines[i] == null)
                engines.RemoveAt(i);
        }
        for (int i = shields.Count - 1; i > -1; i--)
        {
            if (shields[i] == null)
                shields.RemoveAt(i);
        }
        switch (type)
        {
            case 0:
                for (int i = guns.Count - 1; i > -1; i--)
                {
                    if (guns[i] == null)
                    { guns.RemoveAt(i); }
                    else { guns[i].GetComponent<ShipPiece>().activate(); }
                       
                }
               
                break;
            case 1:
                for (int i = engines.Count - 1; i > -1; i--)
                {
                    if (engines[i] == null)
                    { engines.RemoveAt(i); }
                    else { engines[i].GetComponent<ShipPiece>().activate(); }

                }
                break;
            default:
                for (int i = shields.Count - 1; i > -1; i--)
                {
                    if (shields[i] == null)
                    { shields.RemoveAt(i); }
                    else { shields[i].GetComponent<ShipPiece>().activate(); }

                }
                break;
        }


    }


    }