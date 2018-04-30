using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

    GameObject P1;
    GameObject P2;
    
    // Use this for initialization
    void Start () {

        P1 = GameObject.Find("Selected").GetComponent<CharSelected>().P1;
        P2 = GameObject.Find("Selected").GetComponent<CharSelected>().P2;

        Debug.Log("P1 N : " + P1);
        Debug.Log("P2 N : " + P2);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("P1 N : " + P1);
        Debug.Log("P2 N : " + P2);
    }
}
