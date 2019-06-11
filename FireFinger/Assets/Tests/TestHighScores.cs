using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestHighScores
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewHighestScore_UpdatesProperly()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            float oldHS0 = PlayerPrefs.GetFloat("SceneFingerFireHighScore0",0);
            float oldHS1 = PlayerPrefs.GetFloat("SceneFingerFireHighScore1",0);
            float oldHS2 = PlayerPrefs.GetFloat("SceneFingerFireHighScore2",0);
            float oldHS3 = PlayerPrefs.GetFloat("SceneFingerFireHighScore3",0);
            float oldHS4 = PlayerPrefs.GetFloat("SceneFingerFireHighScore4",0);

            ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            sm.scoreCount = oldHS0 + 1; 
            sm.UpdateHighScores();

            float newHS0 = PlayerPrefs.GetFloat("SceneFingerFireHighScore0",0);
            float newHS1 = PlayerPrefs.GetFloat("SceneFingerFireHighScore1",0);
            float newHS2 = PlayerPrefs.GetFloat("SceneFingerFireHighScore2",0);
            float newHS3 = PlayerPrefs.GetFloat("SceneFingerFireHighScore3",0);
            float newHS4 = PlayerPrefs.GetFloat("SceneFingerFireHighScore4",0);

            if (newHS0 == (oldHS0 + 1) && newHS1 == oldHS0 && newHS2 == oldHS1 &&
                newHS3 == oldHS2 && newHS4 == oldHS3) {

            } else {
                Assert.Fail();
            }

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }
    }
}
