﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel,isLocked;
    public string levelToLoad, levelToCheck,levelName;
    // Start is called before the first frame update
    void Start()
    {
        if(isLevel && levelToLoad != null)
        {
            isLocked = true;
            // check if a level should be unlocked
            if(levelToCheck != null)
            {
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }
            if(levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
