using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // text component
    public float scoreCount; // score counter 
    public float sps; // score per second

    // Update is called once per frame
    void Update()
    {
        scoreCount += sps * Time.deltaTime;
        scoreText.text = scoreCount.ToString("0");
    }
}
