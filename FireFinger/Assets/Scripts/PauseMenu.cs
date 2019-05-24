using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject Canvas;
    public GameObject MenuButton;
    public GameObject VolumeButton;
    private Vector2 playerPosition;
    public GameObject Player;
    private bool uiMovido = false;
    public int offset;

    void Start() 
    {
        Pause();
        playerPosition.Set(-Player.transform.position.x + 768, -Player.transform.position.y + 1024);
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(playerPosition);
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && !gameIsPaused)
            {
                playerPosition.Set(touch.position.x, touch.position.y);
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
            pos1.y =(pos1.y*offset);
            VolumeButton.transform.position = pos1;
            pos2.y = (pos2.y*offset);
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
            if(Input.GetTouch(0).position.y >=  objectRectTransform.rect.height )
            {
                uiMovido = true;
                pos1.y =(pos1.y/offset);
                VolumeButton.transform.position = pos1;
                pos2.y = (pos2.y/offset);
                MenuButton.transform.position = pos2;
            }
        }
    }
}
