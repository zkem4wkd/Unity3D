﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y2K.Characters
{
    public class RandomStateMachineBehaviour : StateMachineBehaviour
    {
        public int numberOfStates = 2;
        public float minNormTime = 0f;
        public float maxNormTime = 5f;

        protected float randomNormalTime;

        readonly int hashRandomIdle = Animator.StringToHash("RandomIdle");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Randomly decide a time at which to transition.
            randomNormalTime = Random.Range(minNormTime, maxNormTime);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // If transitioning awy from this state reset the random idle parameter to -1.
            if (animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
            {
                animator.SetInteger(hashRandomIdle, -1);
            }

            // If the state is beyond the randomly decided normalised time and not yet transitioning then set a random idle.
            if (stateInfo.normalizedTime > randomNormalTime && !animator.IsInTransition(0))
            {
                animator.SetInteger(hashRandomIdle, Random.Range(0, numberOfStates));
            }
        }
    }

}