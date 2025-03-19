using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    int unlockedLevels;
    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    bool isFirstTime;
    int offset = 2;
    public int nextLevel;

    void Start()
    {
        isFirstTime = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isFirstTime)
        {
            UnlockLevel();
            NextLevel();
        }
    }

    void UnlockLevel()
    {
        int checkIndex = SceneManager.GetActiveScene().buildIndex;

        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);

        if (unlockedLevels <= (checkIndex - offset) + 1)
        {
            unlockedLevels += 1;
            PlayerPrefs.SetInt(numberOfLevelsUnlocked, unlockedLevels);
            isFirstTime = false;
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
