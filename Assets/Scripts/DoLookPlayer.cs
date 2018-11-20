using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoLookPlayer : MonoBehaviour {
    public Transform player;

    private Tweener tweener;
	void Update () {
        float  angle = Vector3.Angle(transform.forward,Vector3.Normalize(player.position - transform.position));
        transform.RotateAround(transform.position, transform.right, angle / 60);
    }
}
