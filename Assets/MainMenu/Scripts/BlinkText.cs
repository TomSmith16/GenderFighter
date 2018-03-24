using UnityEngine;
using System;
using System.Collections;

public class BlinkText : MonoBehaviour
{
    bool blink = true;
    void Start()
    {
        StartCoroutine(Blink(0.3f, 0.3f));
    }

    IEnumerator Blink(float timeOn, float timeOff)
    {
        while (blink)
        {
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(timeOn);
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(timeOff);
        }

        //Include change for when player has selected. Turn off flashing while waiting for other player.
        
    }
}