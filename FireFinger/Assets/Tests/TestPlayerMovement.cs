using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestPlayerMovement
    {
        [UnityTest]
        public IEnumerator JugadorEnPosicionDelDedo() // test if player is in finger position
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            
            for(int i = 0; i < 10; i++) {
                Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().position);
                yield return new WaitForSeconds(1);
                if (Input.touchCount > 0) 
                {
                    var playerPos = GameObject.Find("Player").GetComponent<Rigidbody2D>().position;
                    var touch = Input.GetTouch(0);
                    Vector2 touchPosition;
                    touchPosition.x = Camera.main.ScreenToWorldPoint(touch.position).x;
                    touchPosition.y = Camera.main.ScreenToWorldPoint(touch.position).y;
                    Assert.AreEqual(touchPosition, playerPos);
                }
            }
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }
        [UnityTest]
        public IEnumerator JugadorDentroDeLimites() //test if player is within bounds
        {
            yield return SceneManager.LoadSceneAsync("FingerFire");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FingerFire"));
            var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            
            for(int i = 0; i < 100; i++) {
                Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().position);
                yield return new WaitForSeconds(0.1f);
                if (Input.touchCount > 0) {
                    var playerPos = GameObject.Find("Player").GetComponent<Rigidbody2D>().position;
                    if(playerPos.x < -screenBounds.x || playerPos.x > screenBounds.x || playerPos.y < -screenBounds.y || playerPos.y > screenBounds.y)
                        Assert.Fail();
                }
            }
            yield return SceneManager.UnloadSceneAsync("FingerFire");
        }
    }
}
