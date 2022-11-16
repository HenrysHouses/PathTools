// * Pathing Tools
// *
// * Copyright (C) 2022  Henrik Hustoft
// *
// * This program is free software: you can redistribute it and/or modify
// * it under the terms of the GNU General Public License as published by
// * the Free Software Foundation, either version 3 of the License, or
// * (at your option) any later version.
// *
// * This program is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// * GNU General Public License for more details.
// *
// * You should have received a copy of the GNU General Public License
// * along with this program.  If not, see <http://www.gnu.org/licenses/>.

using UnityEngine;
using System;

namespace HH.PathingTools
{
    public class AnimationEventManager : MonoBehaviour
    {
        static AnimationEventManager instance;
        public static AnimationEventManager getInstance => instance;


        [SerializeField, Tooltip("Current Unhandled Requests")]

        /// <summary>invoked when new requests are added</summary>
        public event Action<string, animRequestData> OnAnimationRequestChange; 

        /// <summary>count of animations requested in this instance</summary>
        int animNum;

        private void Awake() 
        {
            animNum = 0;

            if(!instance)
                instance = this;
            else
                Destroy(gameObject);
        }

        /// <summary>Request a single animation</summary>
        /// <param name="pathName">The animator that should read this request</param>
        /// <param name="target">GameObject that will be animated</param>
        /// <param name="delay">time delay before animation starts</param>
        /// <param name="coolDown">time cool down before a new animation can start</param>
        /// <param name="animationOverrideOptions">Overrides the settings that are not null</param>
        public void requestAnimation(string pathName, GameObject target, float delay = 0, PathAnimatorController.pathAnimation animationOverrideOptions = null)
        {
            target.name += "_pathAnim" + animNum;
            animRequestData anim = new animRequestData(pathName, target.name, delay, animationOverrideOptions);
            OnAnimationRequestChange?.Invoke(pathName, anim);
            // OnAnimationRequested?.Invoke();
            animNum++;
        }

        /// <summary>Request a ordered list of animations</summary>
        /// <param name="pathName">The animator that should read this request</param>
        /// <param name="targets">GameObject that will be animated in order</param>
        /// <param name="delay">time delay before animation starts</param>
        /// <param name="coolDown">time cool down before a new animation can start</param>
        /// <param name="animationOverrideOptions">Overrides the settings that are not null</param>
        public void requestAnimation(string pathName, GameObject[] targets, float delay = 0, PathAnimatorController.pathAnimation[] animationOverrideOptions = null)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                animRequestData anim = null;
                targets[i].name += "_pathAnim" + animNum;
                float totalDelay = delay * i;
                if(animationOverrideOptions != null)
                    anim = new animRequestData(pathName, targets[i].name, totalDelay, animationOverrideOptions[i]);
                else
                    anim = new animRequestData(pathName, targets[i].name, totalDelay, null);
                animNum++;
                if(anim != null)
                {
                    OnAnimationRequestChange?.Invoke(pathName, anim);
                    // OnAnimationRequested?.Invoke();
                }
            }
        }
    }


    /// <summary>Contains request name, targeted GameObject and animation parameters</summary>
    [System.Serializable]
    public class animRequestData
    {
        public string requestName;
        public string target;
        public PathAnimatorController.pathAnimation anim;
        public float delay;
        public bool requestAccepted;

        public animRequestData(string pathName, string targetName, float delay, PathAnimatorController.pathAnimation animation)
        {
            this.requestName = pathName;
            this.target = targetName;
            this.delay = delay;
            this.anim = animation;
        }
    }
}