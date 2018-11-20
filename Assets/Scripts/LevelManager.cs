using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{

    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
                instance = new LevelManager();
            return instance;
        }
    }


    private int Level = 0;

    public void InitLevel()
    {
        Level = PlayerPrefs.GetInt("level");
        if(Level == 0)
        {
            Level = 1;
            PlayerPrefs.SetInt("level", Level);
		}
    }

    public void AddLevel()
    {
        Level++;
        PlayerPrefs.SetInt("level", Level);
    }
    
    public int GetLevel()
    {
        return Level;
    }
}
