using System;
using UnityEngine;

namespace Helpers
{
    public class AnimationEventDispatcher : MonoBehaviour
    {
        public event Action AnimationTrigger;

        public void ApplyMotion() => AnimationTrigger?.Invoke();
    }
}