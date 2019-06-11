using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestPlayer
    {
        

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerTakesOneHit_LosesOneLife()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            var livesBefore = player.getNumLives();
            player.TakeHit(1);
            var livesAfter = player.getNumLives();
            // Assert: exactly 1 life lost
            Assert.AreEqual(livesBefore-livesAfter,1);

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator PlayerSetLives_SetsLives()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            int numOfLives = 6;
            player.SetLives(numOfLives);
            Assert.AreEqual(numOfLives,player.getNumLives());

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator PlayerDies_PlayerObjectGetsDestroyed()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            player.Die();
            yield return null; // run one frame (needed to execute Destroy() method)
            if (player != null) {
                Assert.Fail();
            }

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator PlayerTakesDamageEqualToHealth_Dies()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            int numOfLives = 6;
            player.SetLives(numOfLives);
            player.TakeHit(numOfLives);
            yield return null; // run one frame (needed to execute Destroy() method)
            if (player != null) {
                Assert.Fail();
            }

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator PlayerTakesDamageGreaterThanHealth_Dies()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            int numOfLives = 6;
            player.SetLives(numOfLives);
            player.TakeHit(numOfLives+1);
            yield return null; // run one frame (needed to execute Destroy() method)
            if (player != null) {
                Assert.Fail();
            }

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator PlayerDies_ShowsGameOver()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject playerGO = GameObject.Find("Player");
            Player player = playerGO.GetComponent<Player>();
            player.Die();
            GameObject gameOverGO = GameObject.Find("GameOverWindow");
            Assert.IsTrue(gameOverGO.activeSelf);

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }
    }
}
