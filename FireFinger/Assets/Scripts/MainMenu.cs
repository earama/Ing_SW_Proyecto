using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScoresPanel;
    public GameObject options;

    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    public Text highScore4;
    public Text highScore5;

    public Text nameOfHS1;
    public Text nameOfHS2;
    public Text nameOfHS3;
    public Text nameOfHS4;
    public Text nameOfHS5;

    private void Start()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        getHighScores();
        highScoresPanel.SetActive(false);
        options.SetActive(false);
    }
    public void playGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("FingerFire");
    }
    public void showOptions()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);
    }
 
    public void getHighScores()
    {
        string sceneName = "FingerFire";

        string highScoreKey = "Scene"+sceneName+"HighScore0";
        float curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore1.text = curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore1";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore2.text = curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore2";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore3.text = curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore3";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore4.text = curHS.ToString("0");

        highScoreKey = "Scene"+sceneName+"HighScore4";
        curHS = PlayerPrefs.GetFloat(highScoreKey,0);
        highScore5.text = curHS.ToString("0");

        // Names:

        highScoreKey = "Scene"+sceneName+"HSName0";
        string curHSName = PlayerPrefs.GetString(highScoreKey,"");
        nameOfHS1.text = curHSName;

        highScoreKey = "Scene"+sceneName+"HSName1";
        curHSName = PlayerPrefs.GetString(highScoreKey,"");
        nameOfHS2.text = curHSName;

        highScoreKey = "Scene"+sceneName+"HSName2";
        curHSName = PlayerPrefs.GetString(highScoreKey,"");
        nameOfHS3.text = curHSName;

        highScoreKey = "Scene"+sceneName+"HSName3";
        curHSName = PlayerPrefs.GetString(highScoreKey,"");
        nameOfHS4.text = curHSName;
        
        highScoreKey = "Scene"+sceneName+"HSName4";
        curHSName = PlayerPrefs.GetString(highScoreKey,"");
        nameOfHS5.text = curHSName;
    }
}
