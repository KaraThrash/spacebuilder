using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    
    public List<GameObject> guns = new List<GameObject>();
    public List<GameObject> engines = new List<GameObject>();
    public List<GameObject> shields = new List<GameObject>();
    public GameObject selectedpiece; 
   

    // Use this for initialization
    void Start() {
      

    }



   
    // Update is called once per frame
    void Update()
    {
       
    }
    public void updateshippartlist(bool addpiece,GameObject whichpiece )
    {
        if (whichpiece.GetComponent<ShipPiece>() != null)
        {
            Debug.Log(whichpiece.transform.name);
            if (selectedpiece.GetComponent<ShipPiece>().type == 0)
            {
                if (addpiece == true) { guns.Add(whichpiece); } //else { guns.Remove(whichpiece); }

            }
            else if (selectedpiece.GetComponent<ShipPiece>().type == 1)
            {
                if (addpiece == true) { engines.Add(whichpiece); } //else { engines.Remove(whichpiece); }

            }
            else if (selectedpiece.GetComponent<ShipPiece>().type == 2)
            {
                if (addpiece == true) { shields.Add(whichpiece); } //else { shields.Remove(whichpiece); }

            }
            else { }
            
        }
        if (addpiece == true) { selectedpiece = null; }
        
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