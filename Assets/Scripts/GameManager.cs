using System;
using GameCycle;
using Interfaces;
using UnityEngine;
using Zenject;

public sealed class GameManager : 
        MonoBehaviour, 
        IGameListener, 
        IFixedTickable, 
        ITickable
    {
        public enum State
        {
            Unknown,
            Start,
            Pause,
            Resume,
            Finish
        }

        public State state { get; private set; }

        private ListenersStorage _listenersStorage;

        [Inject]
        private void Construct(ListenersStorage listenersStorage)
        {
            _listenersStorage = listenersStorage;
        }

        private void Start()
        {
            SetState(State.Start);
        }

        private void SwitchState(State state)
        {
            switch (state)
            {
                case State.Start:
                    for (int i = 0; i < _listenersStorage.StartListeners.Count; i++)
                    {
                        _listenersStorage.StartListeners[i].OnStart();
                    }
                    break;
                case State.Pause:
                    for (int i = 0; i < _listenersStorage.PauseListeners.Count; i++)
                    {
                        _listenersStorage.PauseListeners[i].OnPause();
                    }
                    break;
                case State.Resume:
                    for (int i = 0; i < _listenersStorage.ResumeListeners.Count; i++)
                    {
                        _listenersStorage.ResumeListeners[i].OnResume();
                    }
                    break;
                case State.Finish:
                    for (int i = 0; i < _listenersStorage.FinishListeners.Count; i++)
                    {
                        _listenersStorage.FinishListeners[i].OnFinish();
                    }
                    break;
            }
        }
        
        public void FixedTick()
        {
            if (!CanUpdate()) return;

            for (int i = 0; i < _listenersStorage.FixedUpdateListeners.Count; i++)
            {
                _listenersStorage.FixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        public void Tick()
        {
            if (!CanUpdate()) return;

            for (int i = 0; i < _listenersStorage.UpdateListeners.Count; i++)
            {
                _listenersStorage.UpdateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        public void SetState(State newState)
        {
            if (state != newState)
            {
                SwitchState(newState);
            }
            state = newState;
        }

        public void FinishGame()
        {
            Debug.Log("Game over!");
            SetState(State.Finish);
        }

        private bool CanUpdate()
        {
            return state is State.Start or State.Resume;
        }
    }