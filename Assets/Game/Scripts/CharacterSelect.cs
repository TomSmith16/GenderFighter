using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    int index = 0;
    int indexP2 = 0;
    int sIndex = 0;
    public int totalLevels = 8;
    public float xOffset = 1.5f;
    private GameObject[] MenuItemsArray;
    private GameObject[] MenuItemsArray2P;
    private GameObject MenuItems;
    private GameObject MenuItems2P;
    private GameObject[] CharactersDisplayArray;
    private GameObject[] CharactersDisplayArray2P;
    private GameObject CharacterDisplay;
    private GameObject CharacterDisplay2P;
    private List<GameObject> characters;
    private List<GameObject> characters2P;
    Scene currentScene;
    GameObject P1Select;
    GameObject P2Select;
    public GameObject P1Character;
    public GameObject P2Character;
    CharSelected selected;
    bool movement = false;


    //INIT
    public void Start()
    {
        currentScene = SceneManager.GetActiveScene();

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
        position.x = MenuItemsArray[0].transform.position.x-xOffset;
        P1Select.transform.position = position;

        characters = new List<GameObject>();
        selected = GameObject.Find("Selected").GetComponent<CharSelected>();
        //Display currently selected character
        //When sprites done, idle animation of character in here
        foreach(Transform t in GameObject.Find("CharacterDisplay").transform)
        {
           // Debug.Log(t.gameObject);
            characters.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        characters[index].SetActive(true);








        if (currentScene.name == "2Player")
        {
            ///2 PLAYER MODE/////////////////////////////////////////////////////////////////////
            MenuItems2P = GameObject.Find("Canvas/P2/MenuItems2P");
            MenuItemsArray2P = new GameObject[MenuItems2P.transform.childCount];
            for (int i = 0; i < MenuItems2P.transform.childCount; i++)
            {
                MenuItemsArray2P[i] = MenuItems2P.transform.GetChild(i).gameObject;
                //Debug.Log(MenuItemsArray[i]);
            }

            P2Select = GameObject.Find("CharacterSelector2P");

            Vector2 position2P = P2Select.transform.position;
            position2P.y = MenuItemsArray2P[0].transform.position.y;
            position2P.x = MenuItemsArray2P[0].transform.position.x + xOffset;
            P2Select.transform.position = position2P;

            characters2P = new List<GameObject>();

            //Display currently selected character
            //When sprites done, idle animation of character in here
            foreach (Transform t in GameObject.Find("CharacterDisplay2P").transform)
            {
                // Debug.Log(t.gameObject);
                characters2P.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
            characters2P[index].SetActive(true);
        }
    }





    public void Update()
    {
        //PLAYER 1 
        //Input from arcade machine.
        Debug.Log(Input.GetAxis("Vertical"));


        //Move Down
        if (Input.GetAxis("Vertical") == -1 && movement == false || Input.GetKeyDown(KeyCode.S))
        {
            characters[index].SetActive(false);
            index++;
            if (index <= totalLevels)
            {

                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                characters[index].SetActive(true);

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

                characters[index].SetActive(true);
                Vector2 position = P1Select.transform.position;
                position.y = MenuItemsArray[index].transform.position.y;
                P1Select.transform.position = position;

                characters[index].SetActive(true);

                movement = true;
            }
            
        }

        //Move Up
        if (Input.GetAxis("Vertical") == 1 && movement == false || Input.GetKeyDown(KeyCode.W))
        {
            characters[index].SetActive(false);
            index--;
            if (index >= 0)
            {
                
                characters[index].SetActive(true);

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

                characters[index].SetActive(true);

                movement = true;
            }

        }

        //Selection
        if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.G))
        {
            P1Character = characters[index];
            Destroy(P1Select.GetComponent<BlinkText>());
            P1Select.GetComponent<MeshRenderer>().enabled = true;
            selected.P1 = index;
            Debug.Log("P1: " + P1Character);
            //Load character selected into next scene.



        }






        if (currentScene.name == "2Player")
        {
            //PLAYER 2 Second Joystick
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                characters2P[indexP2].SetActive(false);
                indexP2++;

                if (indexP2 <= totalLevels)
                {

                    characters2P[indexP2].SetActive(true);

                    Vector2 position2P = P2Select.transform.position;
                    position2P.y = MenuItemsArray2P[indexP2].transform.position.y;
                    P2Select.transform.position = position2P;

                    /*
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
                */
                }

                if (indexP2 > totalLevels)
                {
                    indexP2 = 0;

                    Vector2 position2P = P2Select.transform.position;
                    position2P.y = MenuItemsArray2P[indexP2].transform.position.y;
                    P2Select.transform.position = position2P;

                    characters2P[indexP2].SetActive(true);

                }
            }



            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                characters2P[indexP2].SetActive(false);
                indexP2--;

                if (indexP2 >= 0)
                {

                    characters2P[indexP2].SetActive(true);

                    Vector2 position2P = P2Select.transform.position;
                    position2P.y = MenuItemsArray2P[indexP2].transform.position.y;
                    P2Select.transform.position = position2P;

                    /*
                    Vector2 position = transform.position;
                    position.y += yOffset;
                    transform.position = position;
                    */
                }
                if (indexP2 < 0)
                {
                    indexP2 = totalLevels;

                    Vector2 position2P = P2Select.transform.position;
                    position2P.y = MenuItemsArray2P[indexP2].transform.position.y;
                    P2Select.transform.position = position2P;

                    characters2P[indexP2].SetActive(true);
                }
            }

            //Selection
            if (Input.GetKeyDown(KeyCode.Return))
            {


                //Load character selected into next scene.
                P2Character = characters2P[indexP2];
                Destroy(P2Select.GetComponent<BlinkText>());
                P2Select.GetComponent<MeshRenderer>().enabled = true;
                selected.P2 = indexP2;
                Debug.Log("P2: " + P2Character);



            }

            if (P1Character != null && P2Character != null)
            {
                
                SceneManager.LoadScene(3);
            }
        }
    }

}


