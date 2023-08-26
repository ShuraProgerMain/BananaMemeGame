using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using ShuraGames.BananaMeme.Gameplay.PlayerIncarnation;
using ShuraGames.BananaMeme.Gameplay.Updating;
using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.Factories
{
    internal sealed class EnemiesFactory : ICharacterFactory
    {
        private readonly MoveCalculator _moveCalculator;
        private readonly Updater _updater;
        
        internal EnemiesFactory(MoveCalculator moveCalculator, Updater updater)
        {
            _moveCalculator = moveCalculator;
            _updater = updater;
        }

        internal EnemyCharacter GetEnemyCharacter(in EnemyCharacterData enemyCharacterData)
        {
            var presentationInstance = Object.Instantiate(enemyCharacterData.CharacterPresentationData);
            var enemy = new EnemyCharacter(_moveCalculator, enemyCharacterData.CharacterData, presentationInstance);
            _updater.AddUpdater(enemy);
            return enemy;
        }

        public ICharacter GetCharacter(IDefaultCharacterData characterData)
        {
            var presentationInstance = Object.Instantiate(characterData.CharacterPresentationData);
            var enemy = new EnemyCharacter(_moveCalculator, characterData.CharacterData, presentationInstance);
            _updater.AddUpdater(enemy);
            return enemy;
        }
    }
}