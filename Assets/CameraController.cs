using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Shake()
    {
        animator.SetTrigger("shake");
    }

    public void Rotate()
    {
        animator.SetTrigger("Rotate");
    }
}
