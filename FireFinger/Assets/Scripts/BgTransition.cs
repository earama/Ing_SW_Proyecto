using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgTransition : MonoBehaviour
{
    public GameObject background;
    public Image whiteBG;
    public Sprite[] backgrounds;

    private int transitionNumber;
    private float TRANSITION_SPEED;
    private bool changedBackground;

    // Start is called before the first frame update
    void Start()
    {
        // Place first background
        background.GetComponent<Image> ().sprite = backgrounds[0];
        transitionNumber = 0;
        TRANSITION_SPEED = 1f;
        changedBackground = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there's a new transition starting
        if(backgrounds[transitionNumber] != background.GetComponent<Image> ().sprite)
        {
            /* 
            // Make old background more transparent slowly
            // This is achieved by decreasing alpha (from 1 to 0)
            Color tempColor = background.GetComponent<Image>().color;
            tempColor.a -= TRANSITION_SPEED * Time.deltaTime;
            if(tempColor.a < 0) {
                tempColor.a = 0;
            }
            background.GetComponent<Image>().color = tempColor;

            Debug.Log("tempColor.a: " + tempColor.a.ToString());

            

            // If alpha reached 0, change background and start increasing alpha
            if (tempColor.a == 0) {
                background.GetComponent<Image> ().sprite = backgrounds[transitionNumber];
                changedBackground = true;
            }*/

            Color tempColor = whiteBG.color;
            tempColor.a += TRANSITION_SPEED * Time.deltaTime;
            if(tempColor.a > 1) {
                tempColor.a = 1;
            }
            whiteBG.color = tempColor;
            // If alpha reached 1, change background and start decreasing alpha
            if (tempColor.a == 1) {
                background.GetComponent<Image> ().sprite = backgrounds[transitionNumber];
                changedBackground = true;
            }

        } else if (changedBackground) {
            // Make new background less transparent
            Color tempColor = whiteBG.color;
            tempColor.a -= TRANSITION_SPEED * Time.deltaTime;
            whiteBG.color = tempColor;
            if(tempColor.a < 0) {
                tempColor.a = 0;
            }
            if (tempColor.a == 0) {
                changedBackground = false;
            }
        }
    }

    public void BackgroundTransition(int transitionNum)
    {
        transitionNumber = transitionNum;
    }

    public int GetTransitionNumber()
    {
        return transitionNumber;
    }
}
