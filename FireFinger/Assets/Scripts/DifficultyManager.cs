using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public BgTransition bt;
    public ScoreManager sm;
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        int curTransitionNum = bt.GetTransitionNumber();
        //Debug.Log("curTransitionNum: " + curTransitionNum.ToString());
        if (sm.scoreCount >= 20 && curTransitionNum == 0) {
            bt.BackgroundTransition(1);
        } else if (sm.scoreCount >= 200 && curTransitionNum == 1) {
            bt.BackgroundTransition(2);
        }
    }
}
