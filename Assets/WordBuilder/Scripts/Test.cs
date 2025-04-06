using System;
using System.Collections.Generic;
using UnityEngine;

namespace WordBuilder
{
    public abstract class SceneController : MonoBehaviour
    {
        private Dictionary<SceneActionLifePoint, Action> _actions = new();

        private static SceneController _instance;
        public static SceneController CurrentSceneActions => _instance;

        protected virtual void Awake()
        {
            _instance = this;
        }

        protected void RegisterAction(SceneActionLifePoint lifePoint, Action action)
        {
            _actions.Add(lifePoint, action);
        }

        public void InvokeAction(SceneActionLifePoint lifePoint)
        {
            if (_actions.TryGetValue(lifePoint, out Action action))
                action();
        }
    }

    public enum SceneActionLifePoint
    {
        BeforeFadeOut,
        AfterFadeOut,
        BeforeFadeIn,
        AfterFadeIn,
    }
}