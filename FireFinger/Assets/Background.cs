using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetString("fondo") == "espacioThumbnail") {
            Debug.Log("Funciona");
        }
    }
}
