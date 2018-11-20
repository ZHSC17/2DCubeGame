using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Transform levelParent;

	void Start () {
        LevelManager.Instance.InitLevel();
        InitChooseLevel();
    }
	
	void Update () {

    }

    private void InitChooseLevel()
    {
        int level = LevelManager.Instance.GetLevel();
        for (int i = 1; i <= level; i++)
        {
            Transform levelObj = levelParent.Find(i.ToString());
            levelObj.Find("Image").gameObject.SetActive(false);
			int m = i;
            levelObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                SceneManager.LoadScene(m.ToString());

            });
        }
    }
}
