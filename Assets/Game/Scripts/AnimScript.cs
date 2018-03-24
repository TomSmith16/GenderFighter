using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour
{
    public Animation anim;

    public void Start()
    {
        // Walk backwards
        anim["GaiIdle"].speed = 1;

    }
}