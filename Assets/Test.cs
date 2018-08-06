using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
    public bool playerOneTurn;
    public bool playerTwoTurn;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerOneTurn == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerOneTurn = false;
                playerTwoTurn = true;
                print("flip");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                print("slap");
            }
        }
        if (playerTwoTurn == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                playerTwoTurn = false;
                playerOneTurn = true;
                print("flip2");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                print("slap2");
            }
        }
    }
}
