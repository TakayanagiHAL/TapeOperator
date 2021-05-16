using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Framework.State{
    public class StateBase<T>
    {
        public virtual void OnEnter(T obj) { }
        public virtual void OnExit(T obj) { }
        public virtual StateBase<T> OnUpdate(T obj) { return this; }
    }

    public class StateMachine<T>
    {
        private StateBase<T> _currentState;
        private bool _isInitalized;

        /**
         *  @brief  初期化処理
         */
        public void Initalize(StateBase<T> firstState, T obj)
        {
            _currentState = firstState;
            _currentState.OnEnter(obj);

            _isInitalized = true;
        }

        /**
         *  @brief  更新処理
         */
        public void OnUpdate(T obj)
        {
            if (!_isInitalized) return;

            StateBase<T> _nextState = _currentState.OnUpdate(obj);

            // ステートの切り替え処理
            if (_nextState != _currentState)
            {
                _currentState.OnExit(obj);
                _nextState.OnEnter(obj);
                _currentState = _nextState;
            }
        }
    }
}
