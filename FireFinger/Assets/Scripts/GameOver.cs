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
    public GameObject HSNameWindow;
    public Text HSName;
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
        sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        int namePosition = sm.GetPositionOfNewScore();
        HSNameWindow.SetActive(namePosition != -1);

    }

    public void OnContinueButton()
    {
        UpdateHSNames();
        HSNameWindow.SetActive(false);
    }

    private void UpdateHSNames()
    {
        sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        int namePosition = sm.GetPositionOfNewScore();
        string curHSName = HSName.text; // new name
        if(namePosition != -1) { // Just to be sure there's a new score
            // Place new name and displace existing names on leaderboard accordingly
            for(int i = namePosition; i < sm.leaderboardSize; i++) { // Start on position of new score
                string highScoreNameKey = "Scene"+sceneName+"HSName"+i.ToString(); // Get key
                string temp = PlayerPrefs.GetString(highScoreNameKey,"");
                PlayerPrefs.SetString(highScoreNameKey,curHSName);
                curHSName = temp;
                
            }
        }
        
    }
}
