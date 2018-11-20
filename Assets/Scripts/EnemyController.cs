using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    public int destoryNum;

    public float createTime;

    public int createNum;

    public Transform player;

    public string bulletName = "bullet";
    
    public bool addBulletToChild = true;

    private List<GameObject> line1 = new List<GameObject>();
    private List<GameObject> line2 = new List<GameObject>();

    void Start () {
        player.GetComponent<PlayerController>().onEatFood += OnEatFood;
    }
	
	void Update () {
		
	}

    private void CreateEnemy()
    {
        for(int i =0;i< createNum;i++)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load(bulletName), transform); 
            if (obj.GetComponent<DoLookPlayer>() != null)
            {
                obj.GetComponent<DoLookPlayer>().player = player;
            }

            if(bulletName == "bullet2")
            {
                if (line1.Count > 6)
                {
                    if (line2.Count == 0)
                    {
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.GetComponent<Bullet2>().lastBullet = transform;
                    }
                    else
                    {
                        obj.GetComponent<Bullet2>().lastBullet = line2[line2.Count - 1].transform;
                        obj.transform.localPosition = line2[line2.Count - 1].transform.localPosition;
                    }
                    line2.Add(obj);
                    if (line2.Count > 3)
                    {
                        for (int j = line1.Count - 1; j >= 0; j--)
                        {
                            Destroy(line1[j]);
                        }
                        line1.Clear();
                        line1.InsertRange(0, line2);
                        line2.Clear();
                    }
                }
                else
                {
                    if (line1.Count == 0)
                    {
                        obj.transform.localPosition = new Vector3(0, 0, 0);
                        obj.GetComponent<Bullet2>().lastBullet = transform;
                    }
                    else
                    {
                        obj.GetComponent<Bullet2>().lastBullet = line1[line1.Count - 1].transform;
                        obj.transform.localPosition = line1[line1.Count - 1].transform.localPosition;
                    }
                    line1.Add(obj);
                }
            }
            else
            {
                obj.transform.localPosition = new Vector3(0, 0, 0);
            }
            obj.transform.LookAt(player.position);
            if (!addBulletToChild)
                obj.transform.parent = GameObject.Find("Canvas").transform;
        }
    }

    private bool OnEatFood(int count)
    {
        if (count == 1)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            InvokeRepeating("CreateEnemy", 0, createTime);
        }
        if (count >= destoryNum)
        {
            gameObject.tag = "enemy";
            player.GetComponent<PlayerController>().canEatEnemy++;
            GetComponent<Image>().color = Color.green;
            return true;
        }
        return false;
    }
    public void OnDestroy()
    {
        player.GetComponent<PlayerController>().onEatFood -= OnEatFood;
    }
}
