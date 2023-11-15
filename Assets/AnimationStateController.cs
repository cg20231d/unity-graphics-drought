using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash;
    int IsRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // if player presses w key
        if (!IsWalking && forwardPressed)
        {
            // then set the IsWalking boolean to be true
            animator.SetBool(IsWalkingHash, true);
        }

        // if the player not pressing w key
        if (IsWalking && !forwardPressed)
        {
            // then set the IsWalking boolean to be false
            animator.SetBool(IsWalkingHash, false);
        }

        // if player is walking and not running and presses left shift
        if (!IsRunning && (forwardPressed && runPressed))
        {
            // then set the IsRunning boolean to be true
            animator.SetBool(IsRunningHash, true);
        }

        // if player is running and stops running or stop walking
        if (IsRunning && (!forwardPressed || !runPressed))
        {
            // then set the IsRunning boolean to be false
            animator.SetBool(IsRunningHash, false);
        }
    }
}
