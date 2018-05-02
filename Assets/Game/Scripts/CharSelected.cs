using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelected : MonoBehaviour {
    public int P1;
    public int P2;
    Scene currentScene;
    CharacterSelect P2game;
    SinglePlayerScript P1game;

    // Use this for initialization
    void Start () {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "1Player")
            P1game = GameObject.Find("Canvas/P1/CharacterSelector").GetComponent<SinglePlayerScript>();
        
            
        DontDestroyOnLoad(gameObject);

    }


    //Still writing over when it loads into a new scene. Not sure how to fix.

    // Update is called once per frame
    void Update () {
        /*
        if (currentScene.name != "Level")
        {
            if (currentScene.name == "1Player")
            {
                P1 = P1game.P1Character;
                P2 = P1game.AICharacter;
            }
            else
            {
                P1 = P2game.P1Character;
                P2 = P2game.P2Character;
            }
        }
        */
        //if(P1 != null && P2 != null)
            //DontDestroyOnLoad(gameObject.GetComponent<CharSelected>());


    }
}
