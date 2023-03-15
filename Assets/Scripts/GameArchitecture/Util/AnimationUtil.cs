using System;
using System.Collections;
using UnityEngine;

namespace GameArchitecture.Util
{
    public static class AnimationUtil
    {
        public static IEnumerator LerpInTimeWindow(float time, Action<float> action)
        {
            float f = 0f;
            var ret = new WaitForEndOfFrame();
            while (f <1f)
            {
                f += Time.deltaTime / time;
                action(f);
                yield return ret;
            }
            action(1f);
        }
    }
}