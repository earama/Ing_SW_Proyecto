using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestPlayerMovement
    {
        [UnityTest]
        public IEnumerator JugadorEnPosicionDelDedo()
        {

            SetupScene();
            
            
            for(int i = 0; i < 10; i++) {
                yield return new WaitForSeconds(1);
                if (Input.touchCount > 0) 
                {
                    var playerPos = GameObject.Find("Player(Clone)").GetComponent<Rigidbody2D>().position;
                    var touch = Input.GetTouch(0);
                    Vector2 touchPosition;
                    touchPosition.x = Camera.main.ScreenToWorldPoint(touch.position).x;
                    touchPosition.y = Camera.main.ScreenToWorldPoint(touch.position).y;
                    Assert.AreEqual(touchPosition, playerPos);
                    
                }
            }
            
            //yield return new WaitForSeconds(3);

            
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Background"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }

    }
}
