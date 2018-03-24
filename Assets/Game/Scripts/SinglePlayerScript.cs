using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerScript : MonoBehaviour
{

    int index = 0;
    int indexAI = 0;
    int sIndex = 0;
    public int totalLevels = 8;
    public float xOffset = 1.5f;
    private GameObject[] MenuItemsArray;
    private GameObject[] MenuItemsArrayAI;
    private GameObject MenuItems;
    private GameObject MenuItemsAI;
    private GameObject[] CharactersDisplayArray;
    private GameObject[] CharactersDisplayArrayAI;
    private GameObject CharacterDisplay;
    private GameObject CharacterDisplayAI;
    private List<GameObject> characters;
    private List<GameObject> charactersAI;

    GameObject P1Select;
    bool movement = false;
    bool PlayerSelect = true;


    //INIT
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        MenuItems = GameObject.Find("MenuItems");
        MenuItemsArray = new GameObject[MenuItems.transform.childCount];
        for (int i = 0; i < MenuItems.transform.childCount; i++)
        {
            MenuItemsArray[i] = MenuItems.transform.GetChild(i).gameObject;
            //Debug.Log(MenuItemsArray[i]);
        }

        P1Select = GameObject.Find("CharacterSelector");

        Vector2 position = P1Select.transform.position;
        position.y = MenuItemsArray[0].transform.position.y;
        position.x = MenuItemsArray[0].transform.position.x - xOffset;
        P1Select.transform.position = position;

        characters = new List<GameObject>();
        charactersAI = new List<GameObject>();

        //Display currently selected character
        //When sprites done, idle animation of character in here
        foreach (Transform t in GameObject.Find("CharacterDisplay").transform)
        {
            Debug.Log(t.gameObject);
            characters.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        characters[index].SetActive(true);

        foreach (Transform t in GameObject.Find("CharacterDisplayAI").transform)
        {
            Debug.Log(t.gameObject);
            charactersAI.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        charactersAI[index].SetActive(true);

    }





    public void FixedUpdate()
    {
        //PLAYER 1 
        //Input from arcade machine.
        Debug.Log(Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") >= -0.02 && Input.GetAxis("Vertical") <= 0.02 && movement == true)
        {
            Debug.Log("Resting position found");
            movement = false;
        }


        //Move Down
        if (Input.GetAxis("Vertical") == -1 && movement == false||Input.GetKeyDown(KeyCode.S))
        {
            if (PlayerSelect)
                characters[index].SetActive(false);
            else
                charactersAI[index].SetActive(false);

            index++;
            if (index <= totalLevels)
            {

                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                if (PlayerSelect)
                    characters[index].SetActive(true);
                else
                    charactersAI[index].SetActive(true);


                movement = true;
                /*
            Vector2 position = transform.position;
            position.y -= yOffset;
            transform.position = position;
            */
            }

            if (index > totalLevels)
            {
                index = 0;

 
                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                if(PlayerSelect)
                    characters[index].SetActive(true);
                else
                    charactersAI[index].SetActive(true);


                movement = true;
            }

        }

        //Move Up
        if (Input.GetAxis("Vertical") == 1 && movement == false ||Input.GetKeyDown(KeyCode.W))
        {
            if (PlayerSelect)
                characters[index].SetActive(false);
            else
                charactersAI[index].SetActive(false);

            index--;
            if (index >= 0)
            {

                if (PlayerSelect)
                    characters[index].SetActive(true);
                else
                    charactersAI[index].SetActive(true);
                

                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                movement = true;
                /*
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
                */
            }

            if (index < 0)
            {
                index = totalLevels;

                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                if (PlayerSelect)
                    characters[index].SetActive(true);
                else
                    charactersAI[index].SetActive(true);

                movement = true;
            }

        }

        //Selection
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.G))
        {
            if (PlayerSelect)
            {
                //Store Players character
                //Move selector to other side
                //Select AI character
                PlayerSelect = false;
                //Load character selected into next scene.
                //SceneManager.LoadScene(0);
                index = 0;
                MenuItems = GameObject.Find("MenuItemsAI");
                MenuItemsArray = new GameObject[MenuItems.transform.childCount];
                for (int i = 0; i < MenuItems.transform.childCount; i++)
                {
                    MenuItemsArray[i] = MenuItems.transform.GetChild(i).gameObject;
                    //Debug.Log(MenuItemsArray[i]);
                }

                P1Select.GetComponent<TextMesh>().text = "AI";
                P1Select.GetComponent<TextMesh>().color = new Vector4(0, 0, 1, 1);


                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[0].transform.position.y;
                position.x = MenuItemsArray[0].transform.position.x + xOffset;
                P1Select.transform.position = position;
            }
            else
            {
                SceneManager.LoadScene(0);
            }

        }

    }
}
