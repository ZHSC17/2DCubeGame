using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet2 : MonoBehaviour {
    public Transform lastBullet;

    public void Start()
    {
        transform.DOLocalMove(transform.localPosition + transform.forward * 250, 0.5f).OnComplete(delegate
       {
           GameObject line = (GameObject)Instantiate(Resources.Load("line"), transform.parent);
           Vector3 dir = Vector3.zero;
           if (lastBullet == transform.parent)
           {
               dir = transform.localPosition.normalized;
               line.transform.localPosition = transform.localPosition / 2;
           }
           else
           {
               dir = (transform.localPosition - lastBullet.localPosition).normalized;
               line.transform.localPosition = (transform.localPosition + lastBullet.localPosition) / 2;
           }
           line.transform.right = dir;
           line.transform.parent = transform;
       });

    }
}
