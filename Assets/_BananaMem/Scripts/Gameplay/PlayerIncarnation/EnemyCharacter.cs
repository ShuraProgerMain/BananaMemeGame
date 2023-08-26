using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using ShuraGames.BananaMeme.Gameplay.Factories;
using ShuraGames.BananaMeme.Gameplay.Pausing.Interfaces;
using ShuraGames.BananaMeme.Gameplay.Updating.Interfaces;
using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.PlayerIncarnation
{
    internal sealed class EnemyCharacter : ICharacter, IUpdated, IPaused
    {
        private readonly BaseCharacterData _baseCharacterData;
        private readonly CharacterMoverPresentation _characterMoverPresentation;
        
        public EnemyCharacter(MoveCalculator moveCalculator, 
            BaseCharacterData baseCharacterData, CharacterPresentationData presentationData)
        {
            _baseCharacterData = baseCharacterData;
            _characterMoverPresentation = new CharacterMoverPresentation(moveCalculator, presentationData);
        }

        internal void UpdatePresentationPosition(Vector3 position)
        {
            _characterMoverPresentation.UpdatePresentationPosition(position);
        }
        
        #region Inherited

        
        public void Update()
        {
            
        }

        public void TurnOnPause()
        {
           
        }

        public void TurnOffPause()
        {
          
        }

        #endregion
        
        
    }
}