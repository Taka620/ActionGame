using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Mark : MonoBehaviour
{
    private Transform mark;
    private Transform sprite;
    private Vector3 spPos;
    private void Start() 
    {
        sprite = transform.GetChild(0);
        mark = transform.GetChild(1);
    }

    private void Update()
    {
        spPos = sprite.position;
        mark.position = new Vector3(spPos.x, 0.01f, spPos.z);
    }

}
