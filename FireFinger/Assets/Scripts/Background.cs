using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Sprite[] fondos;

    void Start()
    {
        if(PlayerPrefs.GetString("fondo") == "espacioThumbnail") {
            GameObject.Find("Background").GetComponent<Image> ().sprite = fondos[0];
        }
        else if(PlayerPrefs.GetString("fondo") == "playaThumbnail") {
            GameObject.Find("Background").GetComponent<Image> ().sprite = fondos[1];
        }
        else {
            GameObject.Find("Background").GetComponent<Image> ().sprite = fondos[2];
        }
    }
}
