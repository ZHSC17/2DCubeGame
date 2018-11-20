using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Transform _bg;

    public Func<int , bool> onEatFood;

    private int eatNum = 0;

    private bool isDie;

    public Image _mask;

	public int foodNum;

	public int enemyNum;

    [HideInInspector]
    public int canEatEnemy;

	// Use this for initialization
	void Start () {
		_mask.DOColor (new Color (0, 0, 0, 0), 3);
        if (eatNum >= foodNum)
            return;
        FoodManager.Instance.CreateFood();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("main");
        }
    }

    public void OnTriggerEnter(Collider other)
	{;
        if(other.tag == "food")
        {
            transform.DOScale(transform.localScale * 1.05f,0.5f);
            Handheld.Vibrate();
            eatNum++;
            bool isend = false;
            if (onEatFood != null)
                isend = onEatFood(eatNum);
            Destroy(other.gameObject);
            if (isend)
            {
                return;
            }
            if (eatNum >= foodNum)
				return;
			FoodManager.Instance.DelayCreateFood(0.5f);
        }
        else if (other.tag == "bullet")
        {
            Handheld.Vibrate();
            isDie = true;
            GetComponent<Image>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            transform.Find("0").gameObject.SetActive(false);
            transform.Find("1").gameObject.SetActive(true);
            _mask.DOColor(new Color(0, 0, 0, 1), 3).OnComplete(delegate
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
		else if (other.tag == "enemy")
        {
            transform.DOScale(transform.localScale * 1.05f, 0.5f);
            Handheld.Vibrate();
            enemyNum--;
            canEatEnemy--;

            if (enemyNum <= 0) {
				string scenename = SceneManager.GetActiveScene().name;
				int i = int.Parse (scenename);
				i++;
				if (i > 8)
					i = 1;
				if (i > LevelManager.Instance.GetLevel())
					LevelManager.Instance.AddLevel ();
				SceneManager.LoadScene(i.ToString());
			}
            else
            {
                if (canEatEnemy <= 0 && enemyNum>0)
                    FoodManager.Instance.DelayCreateFood(0.5f);
            }
            Destroy(other.gameObject);
        }
    }
    public void OnMouseDrag()
    {
        if (isDie) return;
        Vector3 pos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        pos.z = transform.localPosition.z;
        transform.localPosition = pos;
    }
}
