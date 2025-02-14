using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

namespace GameCycle
{
    public class ListenersStorage
    {
        public IReadOnlyList<IGameListener> GameListeners => _gameListeners;
        public IReadOnlyList<IGameStartListener> StartListeners => _startListeners;
        public IReadOnlyList<IGamePauseListener> PauseListeners => _pauseListeners;
        public IReadOnlyList<IGameResumeListener> ResumeListeners => _resumeListeners;
        public IReadOnlyList<IGameFinishListener> FinishListeners => _finishListeners;
        public IReadOnlyList<IGameUpdateListener> UpdateListeners => _updateListeners;
        public IReadOnlyList<IGameFixedUpdateListener> FixedUpdateListeners => _fixedUpdateListeners;
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGameStartListener> _startListeners = new();
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGamePauseListener> _pauseListeners = new();
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGameResumeListener> _resumeListeners = new();
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGameFinishListener> _finishListeners = new();
        
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGameListener> _gameListeners = new();

        [Inject(Optional = true, Source = InjectSources.Any)]
        private readonly List<IGameUpdateListener> _updateListeners = new();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IGameFixedUpdateListener> _fixedUpdateListeners = new();
        
        
    }
}