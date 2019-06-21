using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject MenuButton;
    public GameObject VolumeButton;
    public GameObject volumeImage;
    public GameObject noVolumeImage;
    public GameObject PlayButton;
    public GameObject GameOverWindow;
    public GameObject Player;
    public GameObject cheaterMenuGO;

    public AudioMixer master;

    private Vector2 playerPosition;
    private bool uiMovido = false;

    private Vector3 screenBounds;

    private Vector2 lastPosBeforeCheat;
    private bool cheated;

    void Start() 
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // First Pause
        PlayButton.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        //playerPosition.Set(objectRectTransform.rect.width/2, objectRectTransform.rect.height/2);
        playerPosition.Set(Screen.width/2, Screen.height/2);
        master.SetFloat("volumen", PlayerPrefs.GetFloat("volumeValue", 0));
        Debug.Log("WOLODSAA");
        chooseVolumeImage();
        cheated = false;
    }

    void Awake()
    {
        
        
    }

    void Update()
    {
        
        if(Input.touchCount > 0 && !GameOverWindow.activeSelf && !cheaterMenuGO.activeSelf)
        {
            if (Input.touchCount > 1 && !gameIsPaused) // Pause the game for cheaters!
            {
                    //otherPause(Input.GetTouch(0));
                    lastPosBeforeCheat = Player.GetComponent<Rigidbody2D>().position;
                    cheaterMenu();
                    cheated = true;
            } else {
                Touch touch = Input.GetTouch(0);
                var touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                var playerRBPos = Player.GetComponent<Rigidbody2D>().position;
                if (touch.phase == TouchPhase.Ended && !gameIsPaused)
                {
                    var truePlayerPos = Camera.main.WorldToScreenPoint(Player.GetComponent<Rigidbody2D>().position);
                    //playerPosition.Set(truePlayerPos.x, truePlayerPos.y);
                    //playerPosition.Set(touch.position.x, touch.position.y);
                    //Player.GetComponent<Rigidbody2D>().position = touchPosition;
                    //playerPosition.Set(Player.GetComponent<Rigidbody2D>().position.x, Player.GetComponent<Rigidbody2D>().position.y);
                    //PlayButton.transform.position.Set(playerPosition.x,playerPosition.y,PlayButton.transform.position.z);
                    //PlayButton.GetComponent<RectTransform>().anchoredPosition = mappingJuegoACanvas(playerPosition);
                    //PlayButton.transform.position.Set(mappingJuegoACanvas(playerPosition).x,mappingJuegoACanvas(playerPosition).y,PlayButton.transform.position.z);
                    //PlayButton.GetComponent<RectTransform>().anchoredPosition = mappingJuegoACanvas(truePlayerPos);
                    if (!gameIsPaused)
                    {
                        Pause(touch);
                    }
                }
                else if(touch.phase == TouchPhase.Began)
                {
                    if (gameIsPaused)
                    {
                        Debug.Log("touch position: " + touchPosition.ToString());
                        Debug.Log("player position: " + playerRBPos.ToString());
                        var errorMargin = 0.5;
                        var distanceX = Mathf.Abs(playerRBPos.x - touchPosition.x);
                        var distanceY = Mathf.Abs(playerRBPos.y - touchPosition.y);
                        //if(touch.position.x <= playerPosition.x + 100 && touch.position.x >= playerPosition.x - 100 && touch.position.y <= playerPosition.y + 100 && touch.position.y >= playerPosition.y - 100 )
                        //if(touchPosition.x <= playerRBPos.x*(1+errorMargin)  && touchPosition.x >= playerRBPos.x*(1-errorMargin) && touchPosition.y <= playerRBPos.y*(1+errorMargin) && touchPosition.y >= playerRBPos.y*(1-errorMargin) )
                        if(distanceX < errorMargin && distanceY < errorMargin)
                        {
                            Resume();
                        }
                    }
                }
            }
        }
        if(Player == null){
            Time.timeScale = 0f; // Stop time
            GameOverWindow.SetActive(true);
        }
        
    }
    void Resume()
    {
        PlayButton.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Vector3 pos1 = VolumeButton.transform.position;
        Vector3 pos2 = MenuButton.transform.position;
        if(uiMovido)
        {
            uiMovido = false;
            pos1.y =(pos1.y*-1);
            VolumeButton.transform.position = pos1;
            pos2.y = (pos2.y*-1);
            MenuButton.transform.position = pos2;
        }
    }
    void Pause(Touch touch)
    {
        //yield return 0; // Wait 1 frame to pause
        //yield return 0; // Wait 1 frame to pause
        if(!cheated){
            Player.GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(touch.position);
            Player.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
        } else {
            cheated = false;
        }
        PlayButton.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Vector3 pos1 = VolumeButton.transform.position;
        Vector3 pos2 = MenuButton.transform.position;
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        //if(Input.touchCount > 0)
        //{
            //if(playerPosition.y >=  Screen.height/2 )
            //var touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //if(touchPosition.y > 0)
            if(Player.GetComponent<Rigidbody2D>().position.y > 0)
            {
                uiMovido = true;
                pos1.y =(pos1.y*-1);
                VolumeButton.transform.position = pos1;
                pos2.y = (pos2.y*-1);
                MenuButton.transform.position = pos2;
            }
        //}
        //yield return 0; // Wait 1 frame to pause
    }

    public void Menu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu UI");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    Vector2 mappingJuegoACanvas(Vector2 coordJuego)
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();

        return new Vector2(coordJuego.x-Screen.width/2,coordJuego.y-Screen.height/2);
        //var temp = Camera.main.WorldToScreenPoint(new Vector3(coordJuego.x, coordJuego.y, 0));
        //return new Vector2(temp.x, temp.y);
    }

    void OnDisable()
    {
        gameIsPaused = true;
    }

    void chooseVolumeImage()
    {
        float valorVolumen;
        master.GetFloat("volumen", out valorVolumen);
        
        if(valorVolumen != -80) {
            noVolumeImage.SetActive(false);
            volumeImage.SetActive(true);
        }
        else {
            noVolumeImage.SetActive(true);
            volumeImage.SetActive(false);
        }
    }

    void otherPause(Touch touch)
    {
        PlayButton.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Vector3 pos1 = VolumeButton.transform.position;
        Vector3 pos2 = MenuButton.transform.position;
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        //if(Input.touchCount > 0)
        //{
            //if(playerPosition.y >=  Screen.height/2 )
            var touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touchPosition.y > 0)
            {
                uiMovido = true;
                pos1.y =(pos1.y*-1);
                VolumeButton.transform.position = pos1;
                pos2.y = (pos2.y*-1);
                MenuButton.transform.position = pos2;
            }
        //}
    }

    void cheaterMenu()
    {
        Time.timeScale = 0f; // Stop time
        cheaterMenuGO.SetActive(true);
    }

    public void ResumeFromCheat()
    {
        if(Input.touchCount <= 1)
        {
            cheaterMenuGO.SetActive(false);
            //Time.timeScale = 1f; // restart time
            
            Player.GetComponent<Rigidbody2D>().position = lastPosBeforeCheat;
            Player.transform.position = lastPosBeforeCheat;
            //yield return 0;
            
        }    
    }

    /* 
    public void TriggerResumeFromCheat()
    {
        StartCoroutine(ResumeFromCheat());
    }*/
}
