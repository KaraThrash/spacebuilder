using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPlayback : MonoBehaviour {
    public Text scroll0;
    public Text scroll1;
    public Text scroll2;
    public Text scroll3;
    public Text scroll4;
    public string playText0;
    public string playText1;
    public string playText2;
    public string playText3;
    public string playText4;
    public Text allTextObj;
    public string allText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //0 is black
    //1 is red
    //2 is yellow
    //3 is green
    //4 is blue
    public void ScrollText(string lastAction,int newColor)
    {
        
        playText0 = playText1;
        playText1 = playText2;
        playText2 = playText3;
        playText3 = playText4;
        playText4 = lastAction;
        scroll0.color = scroll1.color;
        scroll0.text = playText0;
        scroll1.color = scroll2.color;
        scroll1.text = playText1;
        scroll2.color = scroll3.color;
        scroll2.text = playText2;
        scroll3.color = scroll4.color;
        scroll3.text = playText3;
        if (newColor == 1)
        {
            scroll4.color = Color.red;
        }
        if (newColor == 2)
        {
            scroll4.color = Color.yellow;
        }
        if (newColor == 3)
        {
            scroll4.color = Color.green;
        }
        if (newColor == 0)
        {
            scroll4.color = Color.black;
        }

        scroll4.text = playText4;
        allText = allText + "  <>  " + lastAction;
        allTextObj.text = allText;
    }

}
