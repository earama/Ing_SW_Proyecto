using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator camAnim;
    private RipplePostProcessor camRipple;

    private void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
    }
    public void Shake()
    {
        camAnim.SetTrigger("Shake");
    }
    public void Ripple()
    {
        camRipple.RippleEffect();
    }
}
