using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelB;
    public Sprite locked;

    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelreached", 1);

        for (int i = 0; i < levelB.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelB[i].interactable = false;
                levelB[i].image.sprite = locked;
            }
        }
    }
    // Start is called before the first frame update
    public void Select(string levelName)
    {
       fader.FadeTo(levelName);
    }
}
