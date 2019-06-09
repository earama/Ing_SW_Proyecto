using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform> ();
    }
    public void playGame()
    {
        Debug.Log("test");
        SceneManager.LoadScene("FingerFire");
    }
}
