using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RedPoint
{
	public Transform point1;
	public float radius;
}

public class FoodManager : MonoBehaviour {
	public RedPoint[] rectPoint; 


	public static FoodManager Instance;

	void Awake()
	{
		Instance = this;
	}

	public void DelayCreateFood(float time)
	{
		Invoke ("CreateFood", time);
	}

	public void CreateFood()
	{
		GameObject obj =(GameObject)Instantiate (Resources.Load ("food"), GameObject.Find ("Canvas").transform);
		obj.transform.localPosition = GetPoint (obj.transform.localPosition.z);
	}

	public Vector3 GetPoint(float z)
	{
		float width = Screen.width/2;
		float heigh = Screen.height/2;
		RANGEPOIT:
		float  x = Random.Range (-width, width);
		float  y = Random.Range (-heigh, heigh);
		if (rectPoint != null) {
			for (int i = 0; i < rectPoint.Length; i++) {
                if (rectPoint[i].point1 == null) continue;
				Vector3 center = rectPoint [i].point1.localPosition;
				Rect rect = new Rect (center.x - rectPoint [i].radius / 2, center.y - rectPoint [i].radius / 2, rectPoint [i].radius * 2, rectPoint [i].radius * 2);
             
				if (rect.Contains (new Vector2 (x,y))) {
					goto RANGEPOIT;
				}
			}
		}
		return new Vector3(x,y,z);
	}
}
