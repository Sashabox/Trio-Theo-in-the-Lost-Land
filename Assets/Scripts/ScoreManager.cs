using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score = 10;

    public Text scoreText;

    public AudioClip coinSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
    }

    public void AddPoint()
    {
        PlayerPrefs.SetInt("Score", ++Score);
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }

    void Update()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }
}
