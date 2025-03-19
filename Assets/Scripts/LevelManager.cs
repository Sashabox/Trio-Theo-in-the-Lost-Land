using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] lvlButtons;
    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    int unlockedLevels;
    int oldUnlockedLevels;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(numberOfLevelsUnlocked))
        {
            PlayerPrefs.SetInt(numberOfLevelsUnlocked, 1);
        }

        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);
        oldUnlockedLevels = unlockedLevels;

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i < unlockedLevels)
            {
                lvlButtons[i].interactable = true;
            }
            else
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    private void Update()
    {
        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);
        if (oldUnlockedLevels != unlockedLevels)
        {
            for (int i = 0; i < lvlButtons.Length; i++)
            {
                if (i < unlockedLevels)
                {
                    lvlButtons[i].interactable = true;
                }
                else
                {
                    lvlButtons[i].interactable = false;
                }
            }
            oldUnlockedLevels = unlockedLevels;
        }
    }
}
