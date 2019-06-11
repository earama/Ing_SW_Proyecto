using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

        [UnityTest]
        public IEnumerator VolumeMuted_ShowsNoVolumeIcon()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject volumeImage = GameObject.Find("Canvas").transform.Find("PauseMenu").transform.Find("VolumeButton").transform.Find("Image").gameObject;
            GameObject noVolumeImage = GameObject.Find("Canvas").transform.Find("PauseMenu").transform.Find("VolumeButton").transform.Find("No").gameObject;
            AudioManager audioMgr = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            AudioMixer master = audioMgr.master;
            // First, make sure to have normal volume
            master.SetFloat("volumen", 0);
            // Then, toggle audio to mute the volume
            audioMgr.toggleAudio();
            // Assert state of images
            if(volumeImage.activeSelf && !noVolumeImage.activeSelf) {
                Assert.Fail();
            }

            // Unload scene
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }

        [UnityTest]
        public IEnumerator VolumeNotMuted_ShowsVolumeIcon()
        {
            // Load and set scene for testing
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            yield return null; // run one frame

            // Test body
            GameObject volumeImage = GameObject.Find("Canvas").transform.Find("PauseMenu").transform.Find("VolumeButton").transform.Find("Image").gameObject;
            GameObject noVolumeImage = GameObject.Find("Canvas").transform.Find("PauseMenu").transform.Find("VolumeButton").transform.Find("No").gameObject;
            AudioManager audioMgr = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            AudioMixer master = audioMgr.master;
            // First, make sure to mute volume
            master.SetFloat("volumen", -80);
            // Then, toggle audio to put volume back to normal
            audioMgr.toggleAudio();
            // Assert state of images
            if(!volumeImage.activeSelf && noVolumeImage.activeSelf) {
                Assert.Fail();
            }

            // Unload scene
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
