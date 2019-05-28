using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to destroy particles effect
public class destroyParticlesEffect : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
