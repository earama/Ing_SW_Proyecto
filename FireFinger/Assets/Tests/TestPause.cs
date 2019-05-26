using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestPause : MonoBehaviour
    {
        private bool hayColision; 

        [UnityTest]
        public IEnumerator TiempoParalizadoEnPausa()
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            for(int i = 0; i < 100; i++) {
                yield return new WaitForSeconds(0.1f);
                var pauseMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
                if(pauseMenu.activeInHierarchy){
                    Assert.AreEqual(Time.timeScale,0f);
                }
            }
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator TiempoNoParalizadoEnNoPausa()
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            for(int i = 0; i < 100; i++) {
                yield return new WaitForSeconds(0.1f);
                var pauseMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
                if(!pauseMenu.activeInHierarchy){
                    Assert.AreNotEqual(Time.timeScale,0f);
                }
            }
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator NoHayColisionEntrePlayButtonYOtrosBotones()
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            for(int i = 0; i < 100; i++) {
                yield return new WaitForSeconds(0.1f);
                //var canvasRT = GameObject.Find("Canvas").GetComponent<RectTransform> ();
                //var menuButton = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.transform.Find("MenuButton").gameObject;
                //var volumeButton = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.transform.Find("VolumeButton").gameObject;
                //var playButton = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.transform.Find("PlayButton").gameObject;
                if(hayColision){
                    Assert.Fail();
                }
            }
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("PauseMenuButton")){
                hayColision = true;
            }
        }
    }
}
