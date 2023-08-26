using System;
using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using ShuraGames.BananaMeme.Gameplay.Factories;
using ShuraGames.BananaMeme.Gameplay.Pausing.Interfaces;
using ShuraGames.BananaMeme.Gameplay.Updating.Interfaces;
using ShuraProgerGame.UserInputs;

namespace ShuraGames.BananaMeme.Gameplay.PlayerIncarnation
{
    internal sealed class PlayerCharacter : ICharacter, IUpdated, IPaused, IDisposable
    {
        private readonly GameplayInput _gameplayInput;
        private readonly BaseCharacterData _baseCharacterData;
        private readonly CharacterMoverPresentation _characterMoverPresentation;


        public PlayerCharacter(GameplayInput gameplayInput, MoveCalculator moveCalculator, 
            BaseCharacterData baseCharacterData, CharacterPresentationData presentationData)
        {
            _gameplayInput = gameplayInput;
            _baseCharacterData = baseCharacterData;
            _gameplayInput.Move.Enable();

            _characterMoverPresentation = new CharacterMoverPresentation(moveCalculator, presentationData);
            SubscribeAllEvents();
        }
        
        public void Update()
        {
            _characterMoverPresentation.Move(_baseCharacterData.MoveSpeed);
        }

        private void SubscribeAllEvents()
        {
            _gameplayInput.Move.Velocity.performed += _characterMoverPresentation.OnVelocityOnPerformed;
            _gameplayInput.Move.Velocity.canceled += _characterMoverPresentation.OnVelocityOnCanceled;
        }

        private void UnsubscribeAllEvents()
        {
            _gameplayInput.Move.Velocity.performed -= _characterMoverPresentation.OnVelocityOnPerformed;
            _gameplayInput.Move.Velocity.canceled -= _characterMoverPresentation.OnVelocityOnCanceled;
        }

        public void TurnOnPause()
        {
            UnsubscribeAllEvents();
        }

        public void TurnOffPause()
        {
            SubscribeAllEvents();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();

            if (disposing)
            {
                UnsubscribeAllEvents();
                // _gameplayInput?.Dispose();
            }
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }
    }
}