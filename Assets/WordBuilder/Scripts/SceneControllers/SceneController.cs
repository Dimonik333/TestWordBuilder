using System;
using System.Collections.Generic;
using UnityEngine;

namespace WordBuilder
{
    public abstract class SceneController : MonoBehaviour
    {
        private Dictionary<SceneActionLifePoint, Action> _actions = new();

        private bool _controlled = false;
        private static SceneController _instance;
        public static SceneController CurrentSceneActions => _instance;

        protected virtual void Awake()
        {
            _instance = this;
        }

        protected virtual void Start()
        {
            if (_controlled)
                return;

            Action action = null;
            if (_actions.TryGetValue(SceneActionLifePoint.BeforeFadeOut, out action))
                action?.Invoke();
            if(_actions.TryGetValue(SceneActionLifePoint.AfterFadeOut, out action))
                action?.Invoke();
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

        public void SetControled()
        {
            _controlled = true;
        }
    }
}