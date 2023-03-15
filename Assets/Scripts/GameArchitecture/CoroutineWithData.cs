using System.Collections;
using UnityEngine;

namespace GameArchitecture
{
    public class CoroutineWithData
    {
        public Coroutine coroutine { get; private set; }
        public object Result;
        private IEnumerator target;
        public CoroutineWithData(MonoBehaviour owner, IEnumerator target)
        {
            this.target = target;
            coroutine = owner.StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            while (target.MoveNext())
            {
                Result = target.Current;
                yield return Result;
            }
        }
    }
}