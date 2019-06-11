using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class TestBackground
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ActiveBackground_ChosenByUser()
        {
            // Before loading scene:
            // Get stored value to restore after testing
            string initialValue = PlayerPrefs.GetString("fondo");
            // Now simulate choosing a background
            PlayerPrefs.SetString("fondo","volcanThumbnail");

            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            string bgImageName = GameObject.Find("Canvas Background").transform.Find("Background").gameObject.GetComponent<Image>().sprite.name;
            if(bgImageName != "volcan") {
                Assert.Fail();
            }

            // Return stored value back
            PlayerPrefs.SetString("fondo",initialValue);            

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator ActiveBackground_EspacioByDefault()
        {
            // Before loading scene:
            // Get stored value to restore after testing
            string initialValue = PlayerPrefs.GetString("fondo");
            // Now simulate not having chosen a background
            PlayerPrefs.DeleteKey("fondo");

            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            string bgImageName = GameObject.Find("Canvas Background").transform.Find("Background").gameObject.GetComponent<Image>().sprite.name;
            if(bgImageName != "espacio") {
                Assert.Fail();
            }

            // Return stored value back
            PlayerPrefs.SetString("fondo",initialValue);            

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }
    }
}
