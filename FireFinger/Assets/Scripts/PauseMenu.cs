using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject MenuButton;
    public GameObject VolumeButton;
    public GameObject PlayButton;
    public Vector2 playerPosition;
    public GameObject Player;
    private bool uiMovido = false;

    void Start() 
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        Pause();
        playerPosition.Set(objectRectTransform.rect.width/2, objectRectTransform.rect.height/2);

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Ended && !gameIsPaused)
            {
                playerPosition.Set(touch.position.x, touch.position.y);
                PlayButton.transform.position.Set(playerPosition.x,playerPosition.y,PlayButton.transform.position.z);
                //PlayButton.GetComponent<RectTransform>().localPosition.Set(playerPosition.x,playerPosition.y,PlayButton.GetComponent<RectTransform>().localPosition.z);
                PlayButton.GetComponent<RectTransform>().anchoredPosition = mappingJuegoACanvas(playerPosition);
                
                //playerPosition.Set(Player.GetComponent<Rigidbody2D>().position.x,Player.GetComponent<Rigidbody2D>().position.y);
                if (!gameIsPaused)
                {
                    //while(playerPosition != touch.position){ }
                    
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
 
    Vector2 mappingJuegoACanvas(Vector2 coordJuego)
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
        return new Vector2(coordJuego.x-objectRectTransform.rect.width/2,coordJuego.y-objectRectTransform.rect.height/2);
    }
}
