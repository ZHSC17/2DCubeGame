using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestory : MonoBehaviour {
    public float destoryTime = 10;

    private float _time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _time += Time.deltaTime;
        if(_time > destoryTime)
        {
            Destroy(gameObject);
        }

    }
}
