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
        public IEnumerator TiempoParalizadoEnPausa() // test if time stops
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
        public IEnumerator TiempoNoParalizadoEnNoPausa() // test if time resumes
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
        public IEnumerator NoHayColisionEntrePlayButtonYOtrosBotones() // test if pause menu crashes with play button
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            for(int i = 0; i < 100; i++) {
                yield return new WaitForSeconds(0.1f);
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
