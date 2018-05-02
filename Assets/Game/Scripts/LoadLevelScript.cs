using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

    int P1;
    int P2;
    public GameObject P1Char;
    public GameObject P2Char;
    public GameObject[] characters;

    // Use this for initialization
    void Start () {

        if (GameObject.Find("Selected").GetComponent<CharSelected>().P1 != -1 && GameObject.Find("Selected").GetComponent<CharSelected>().P2 != -1)
        {
            P1 = GameObject.Find("Selected").GetComponent<CharSelected>().P1;
            P2 = GameObject.Find("Selected").GetComponent<CharSelected>().P2;
        }
        else
        {
            P1 = 0;
            P2 = 1;
        }
        LoadChar(P1, P1Char);
        LoadChar(P2, P2Char);
        Debug.Log(P1Char + ": " + P1);
        Debug.Log(P2Char + ": " + P2);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("P1 N : " + P1);
        //Debug.Log("P2 N : " + P2);
    }


    void LoadChar(int charInt, GameObject charSelected)
    {
        Instantiate(characters[charInt], charSelected.transform);
        if (charSelected.name == "P2")
            charSelected.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        //charSelected.transform.parent = characters[charInt].transform;
        
        /*
        switch(charString)
        {
            case 0:
                 
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            default:

                break;
        }
        */
       
    }
}
