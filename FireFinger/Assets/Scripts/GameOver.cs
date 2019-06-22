using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text finalScore;
    public Text highScore;
    private string sceneName;
    private ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnEnable()
    {
        sceneName = SceneManager.GetActiveScene().name;
        finalScore.text = scoreText.text;
        string highScoreKey = "Scene"+sceneName+"HighScore0";
        highScore.text = PlayerPrefs.GetFloat(highScoreKey,0).ToString("0");
    }
}
