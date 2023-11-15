using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    // The function specified in the Animation Event
    public void EndAnimationEvent()
    {
        // Add any code to end the animation here
        animator.enabled = false; // Disable the animator to stop the animation
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
