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
    
            // Trainsition to white
            // This is achieved by increasing white alpha (from 0 to 1)
            Color tempColor = whiteBG.color;
            tempColor.a += TRANSITION_SPEED * Time.deltaTime;
            if(tempColor.a > 1) { // Don't allow out of bounds
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
            if(tempColor.a < 0) { // Don't allow out of bounds
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
