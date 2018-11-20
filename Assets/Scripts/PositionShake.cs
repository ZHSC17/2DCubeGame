using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PositionShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOShakePosition(3600, 10, 10, 90, true, false);
	}
	
}
