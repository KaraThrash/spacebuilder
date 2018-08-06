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
    public void updateshippartlist()
    {

        if (selectedpiece.GetComponent<ShipPiece>().type == 0)
        {
            guns.Add(selectedpiece);
        }
        else if (selectedpiece.GetComponent<ShipPiece>().type == 1)
        {
            engines.Add(selectedpiece);
        }
        else
        {
            shields.Add(selectedpiece);
        }

        selectedpiece = null;
    }
    

    }