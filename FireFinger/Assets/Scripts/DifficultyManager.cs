using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public BgTransition bt;
    public ScoreManager sm;
    public EnemySpawn es;
    public float[] diffCheckpoints; // Scores that tell when to change difficulty
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        int curTransitionNum = bt.GetTransitionNumber();
        if (sm.scoreCount >= diffCheckpoints[0] && curTransitionNum == 0) {
            bt.BackgroundTransition(1);
            SetDifficulty(1.4f, 0.9f);
        } else if (sm.scoreCount >= diffCheckpoints[1] && curTransitionNum == 1) {
            bt.BackgroundTransition(2);
            SetDifficulty(1.60f, 0.8f);
            StartCoroutine(FinalDifficulty());
        }
    }

    IEnumerator FinalDifficulty()
    {
        // Slightly increase difficulty every few seconds
        do {
            yield return new WaitForSeconds(10);
            MultiplyDifficulty(1.05f, 0.98f);
        } while(true);
    }

    void SetDifficulty(float speedDifficulty, float respawnDifficulty)
    {
        // initial values get multiplied by parameters
        // difficulty changes in absolute terms
        es.SetSpeedModifier(speedDifficulty);
        es.SetRespawnTimeModifier(respawnDifficulty);
    }

    void MultiplyDifficulty(float speedDifficulty, float respawnDifficulty)
    {
        // previous values get multiplied by parameters
        // difficulty changes relative to previous difficulty
        es.MultiplySpeedModifier(speedDifficulty);
        es.MultiplyRespawnTimeModifier(respawnDifficulty);
    }
}
