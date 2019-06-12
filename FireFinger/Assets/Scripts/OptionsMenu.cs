using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject volumeImage;
    public GameObject noVolumeImage;
    public Sprite[] thumbnails;
    public GameObject currentBG;
    

    void Start() {
        if(PlayerPrefs.GetString("fondo") == "volcanThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[2];
        }
        else if(PlayerPrefs.GetString("fondo") == "playaThumbnail") {
            currentBG.GetComponent<Image> ().sprite = thumbnails[1];
        }
        else {
            currentBG.GetComponent<Image> ().sprite = thumbnails[0];
        }
    }

    void Awake() {
        chooseVolumeImage();
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

    public void toggleVolume() {
        float valorVolumen;
        valorVolumen = PlayerPrefs.GetFloat("volumeValue", 0);
        if(valorVolumen != -80) {
            PlayerPrefs.SetFloat("volumeValue", -80);
            noVolumeImage.SetActive(true);
            volumeImage.SetActive(false);
        }
        else {
            PlayerPrefs.SetFloat("volumeValue", 0);
            noVolumeImage.SetActive(false);
            volumeImage.SetActive(true);
        }
    }

    void chooseVolumeImage()
    {
        float valorVolumen;
        valorVolumen = PlayerPrefs.GetFloat("volumeValue", 0);
        
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
