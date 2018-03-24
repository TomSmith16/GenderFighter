using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    int index = 0;
    public int totalLevels = 8;
    public float xOffset = 2.0f;
    private GameObject[] gameObjectsArray;
    private GameObject MenuItems;
    bool movement = false;

    public void Start()
    {

        MenuItems = GameObject.Find("MenuItems");
        gameObjectsArray = new GameObject[MenuItems.transform.childCount];
        for (int i = 0; i < MenuItems.transform.childCount; i++)
        {
            gameObjectsArray[i] = MenuItems.transform.GetChild(i).gameObject;
            //Debug.Log(gameObjectsArray[i]);
        }

        Vector2 position = transform.position;
        position.y = gameObjectsArray[0].transform.position.y;
        position.x = gameObjectsArray[0].transform.position.x-xOffset;
        transform.position = position;


      

    }

    public void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Vertical"));

        if (Input.GetAxis("Vertical") >= -0.02 && Input.GetAxis("Vertical") <= 0.02 && movement == true)
        {
            //Debug.Log("Resting position found");
            movement = false;
        }


        //Move Down
        if (Input.GetAxis("Vertical") == -1 && movement == false)
        {
            
            index++;
            if (index <= totalLevels)
            {

                Vector2 position = transform.position;
                position.y = gameObjectsArray[index].transform.position.y;
                transform.position = position;

                movement = true;

               // Debug.Log("Down + " + index);
            }

            if(index > totalLevels)
            {
                    index = 0;

                    Vector2 positionreset = transform.position;
                    positionreset.y = gameObjectsArray[index].transform.position.y;
                    transform.position = positionreset;

                    movement = true;
            }
                /*
            

            Vector2 position = transform.position;
            position.y -= yOffset;
            transform.position = position;
            */
            

        }

        //Move up
        if (Input.GetAxis("Vertical") == 1 && movement == false)
        {
            index--;
            if (index >= 0)
            {
                
                Vector2 position = transform.position;
                position.y = gameObjectsArray[index].transform.position.y;
                transform.position = position;
                /*
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
                */

                movement = true;

                //Debug.Log("Up + " + index);
            }

            if (index < 0)
            {
                index = totalLevels;

                Vector2 positionreset = transform.position;
                positionreset.y = gameObjectsArray[index].transform.position.y;
                transform.position = positionreset;

                movement = true;
            }


        }

        if (Input.GetButtonDown("Fire1"))
        {

            if (index == 2)
            {
                Application.Quit();
                Debug.Log("Game quit!");
            }
            else if (index == 0)
            {
                SceneManager.LoadScene(index+1);
            }
            else if (index == 1)
            {
                SceneManager.LoadScene(index+1);
            }
        }
    }

}
