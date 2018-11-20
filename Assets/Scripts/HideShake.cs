using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShake : MonoBehaviour {
 
    void Start()
    {
        StartCoroutine("WaitShake");
    }

	IEnumerator WaitShake()
    {
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("WaitShake");
    }
}
