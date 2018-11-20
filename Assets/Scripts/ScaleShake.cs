using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleShake : MonoBehaviour {

    public float maxScale;

    public float minScale;

    private bool isAdd;

    public void Update()
    {
        if(isAdd)
        {
            transform.localScale *= 1.05f;
            if (transform.localScale.x > maxScale)
                isAdd = false;
        }
        else
        {
            transform.localScale /= 1.05f;
            if (transform.localScale.x < minScale)
                isAdd = true;
        }
    } 
}
