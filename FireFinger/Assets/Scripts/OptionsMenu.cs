using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Sprite[] thumbnails;

    public GameObject currentBG;

    void Start() {
        if(PlayerPrefs.GetString("fondo") == "espacioThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[0];
        }
        else if(PlayerPrefs.GetString("fondo") == "playaThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[1];
        }
        else {
            currentBG.GetComponent<Image> ().sprite = thumbnails[2];
        }
    }

    public void changeThumbnail() {
        if(currentBG.GetComponent<Image> ().sprite.name == "espacioThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[1];
        }
        else if(currentBG.GetComponent<Image> ().sprite.name == "playaThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[2];
        }
        else {
            currentBG.GetComponent<Image> ().sprite = thumbnails[0];
        }

        PlayerPrefs.SetString("fondo",  currentBG.GetComponent<Image> ().sprite.name);
    }
}
