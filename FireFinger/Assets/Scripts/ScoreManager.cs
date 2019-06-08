using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // text component
    public float scoreCount; // score counter 
    public float sps; // score per second
    public int leaderboardSize = 1; // number of high scores to record
    private string sceneName;

    void Start(){
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount += sps * Time.deltaTime;
        scoreText.text = scoreCount.ToString("0");
    }

    public void UpdateHighScores()
    {
        float score = scoreCount;
        Debug.Log("Score: "+scoreCount.ToString("0"));
        for(int i = 0; i < leaderboardSize; i++) {
            // scores specific to scene
            string highScoreKey = "Scene"+sceneName+"HighScore"+i.ToString();
            float curHS = PlayerPrefs.GetFloat(highScoreKey,0);
            // if new score greater than "highScores[i]"
            if(score > curHS) {
                // Store highScores[i] in temp for rearranging
                float temp = curHS;
                // Store new score in PlayerPrefs "highScores[i]"
                PlayerPrefs.SetFloat(highScoreKey,score);
                // Place temp (previous highScores[i]) for rearrangement on next iteration
                score = temp;

                if(i == 0) {
                    NewRecord();
                }
            }
        }
    }

    public void NewRecord()
    {
        // New Record Spectacle
    }
}
