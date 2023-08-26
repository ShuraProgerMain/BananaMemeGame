using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using ShuraGames.BananaMeme.Gameplay.PlayerIncarnation;
using ShuraGames.BananaMeme.Gameplay.Updating;
using ShuraProgerGame.UserInputs;
using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.Factories
{
    internal sealed class PlayerFactory : ICharacterFactory
    {
        private readonly GameplayInput _gameplayInput;
        private readonly MoveCalculator _moveCalculator;
        private readonly Updater _updater;
        
        internal PlayerFactory(GameplayInput gameplayInput, MoveCalculator moveCalculator, Updater updater)
        {
            _gameplayInput = gameplayInput;
            _moveCalculator = moveCalculator;
            _updater = updater;
        }
        
        internal PlayerCharacter GetCharacter(in PlayerCharacterData playerCharacterData)
        {
            var presentationInstance = Object.Instantiate(playerCharacterData.CharacterPresentationData);
            var playerCharacter = new PlayerCharacter(_gameplayInput, _moveCalculator, playerCharacterData.CharacterData, presentationInstance);
            
            _updater.AddUpdater(playerCharacter);
            
            return playerCharacter;
        }

        public ICharacter GetCharacter(IDefaultCharacterData characterData)
        {
            var presentationInstance = Object.Instantiate(characterData.CharacterPresentationData);
            var playerCharacter = new PlayerCharacter(_gameplayInput, _moveCalculator, characterData.CharacterData, presentationInstance);
            
            _updater.AddUpdater(playerCharacter);
            
            return playerCharacter;
        }
    }
}