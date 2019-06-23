using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator camAnim;

    private void Start()
    {
    }
    public void Shake()
    {
        camAnim.SetTrigger("Shake");
    }

}
