using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScoresPanel;
    //public GameObject highScoresTexts;
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    public Text highScore4;
    public Text highScore5;


    private void Start()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        getHighScores();
        highScoresPanel.SetActive(false);
    }
    public void playGame()
    {
        //Debug.Log("test");
        SceneManager.LoadScene("FingerFire");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
    }

     public void getHighScores()
    {
        string sceneName = "FingerFire";

        string highScoreKey = "Scene"+sceneName+"HighScore0";
        float curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore1.text = "1. " + curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore1";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore2.text = "2. " + curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore2";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore3.text = "3. " + curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore3";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore4.text = "4. " + curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore4";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore5.text = "5. " + curHS.ToString("0");
        //TextMeshProUGUI txtHS1 = highScore1.GetComponent<TextMeshProUGUI>();
        //txtHS1.Text = "1. " + curHS.ToString("0");

        /* 
        int i = 0;
        while(true) {
            string highScoreKey = "Scene"+sceneName+"HighScore"+i.ToString();
            float curHS = PlayerPrefs.GetFloat(highScoreKey,0);
            if(curHS == 0) {
                break;
            }
            GameObject highScoreTxtGO = new GameObject("highScore"+(i+1).ToString());
            highScoreTxtGO.transform.SetParent(highScoresTexts.transform);
            Text curHSText = highScoreTxtGO.AddComponent<Text>();
            //Text curHSText = highScoresTexts.AddComponent<Text>();
            curHSText.text = (i+1).ToString() + ". " + curHS.ToString("0");
            //curHSText.transform.position = new Vector2(0,i*(-30));
            highScoreTxtGO.transform.position = new Vector2(0,i*(-60));

            i++;
        }*/
        
    }
}
