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

    public AudioMixer master;

    private Vector2 playerPosition;
    private bool uiMovido = false;

    void Start() 
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        Pause();
        playerPosition.Set(objectRectTransform.rect.width/2, objectRectTransform.rect.height/2);

        master.SetFloat("volumen", PlayerPrefs.GetFloat("volumeValue", 0));
        Debug.Log("WOLODSAA");
        chooseVolumeImage();
    }

    void Awake()
    {
        
        
    }

    void Update()
    {
        if(Input.touchCount > 0 && !GameOverWindow.activeSelf)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Ended && !gameIsPaused)
            {
                playerPosition.Set(touch.position.x, touch.position.y);
                PlayButton.transform.position.Set(playerPosition.x,playerPosition.y,PlayButton.transform.position.z);
                PlayButton.GetComponent<RectTransform>().anchoredPosition = mappingJuegoACanvas(playerPosition);
                if (!gameIsPaused)
                {
                    Pause();
                }
            }
            else if(touch.phase == TouchPhase.Began)
            {
                if (gameIsPaused)
                {
                    if(touch.position.x <= playerPosition.x + 100 && touch.position.x >= playerPosition.x - 100 && touch.position.y <= playerPosition.y + 100 && touch.position.y >= playerPosition.y - 100 )
                    {
                        Resume();
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
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Vector3 pos1 = VolumeButton.transform.position;
        Vector3 pos2 = MenuButton.transform.position;
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.y >=  objectRectTransform.rect.height/2 )
            {
                uiMovido = true;
                pos1.y =(pos1.y*-1);
                VolumeButton.transform.position = pos1;
                pos2.y = (pos2.y*-1);
                MenuButton.transform.position = pos2;
            }
        }
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
        return new Vector2(coordJuego.x-objectRectTransform.rect.width/2,coordJuego.y-objectRectTransform.rect.height/2);
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
}
