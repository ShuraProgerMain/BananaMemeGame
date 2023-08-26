using System;
using System.Collections.Generic;
using System.Linq;
using AddressableExtensions;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using ShuraGames.BananaMeme.Gameplay.Factories;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;
using Random = System.Random;

namespace ShuraGames.BananaMeme.Gameplay.PlayerIncarnation
{
    internal sealed class PlayerHandler
    {
        private PlayerCharacter _playerCharacter;
        
        internal PlayerHandler(PlayerFactory playerFactory)
        {
            var playerData = Addressables.LoadAssetAsync<PlayerCharacterData>
                (DefaultLocalGroup.Bananacatplayercharacter).WaitForCompletion();

            _playerCharacter = playerFactory.GetCharacter(in playerData);
        }
    }

    internal readonly struct SessionEnemiesConfig
    {
        internal readonly IReadOnlyList<EnemyCharacterData> Data;
    }

    internal readonly struct SessionConfig
    {
        internal readonly SessionEnemiesConfig EnemiesConfig;
    }
    
    internal sealed class EnemiesService
    {
        private EnemiesSpawner _enemiesSpawner;
        private IReadOnlyList<EnemyCharacterData> _data;
        private readonly SessionEnemiesConfig _enemiesConfig;
        
        internal EnemiesService(EnemiesFactory enemiesFactory, SessionConfig sessionConfig)
        {
            _enemiesConfig = sessionConfig.EnemiesConfig;
            
            var defaultEnemy = Addressables.LoadAssetAsync<EnemyCharacterData>(DefaultLocalGroup.Defaultenemy).WaitForCompletion();
            _enemiesSpawner = new EnemiesSpawner(enemiesFactory,new List<EnemyCharacterData>() { defaultEnemy });
        }
    }

    internal sealed class EnemiesSpawner
    {
        private readonly EnemiesFactory _enemiesFactory;

        private readonly ObjectPool<EnemyCharacter> _enemyCharacters;
        private readonly Dictionary<string, ObjectPool<EnemyCharacter>> _charactersEnemy = new();

        internal EnemiesSpawner(EnemiesFactory enemiesFactory, IReadOnlyList<EnemyCharacterData> enemiesData)
        {
            _enemiesFactory = enemiesFactory;

            foreach (var enemy in enemiesData)
            {
                enemy.CharacterPresentationData.name = "enemy " + Guid.NewGuid();
                var func = new Func<EnemyCharacter>(() => (EnemyCharacter)_enemiesFactory.GetCharacter(enemy));
                _charactersEnemy.Add(enemy.name, new ObjectPool<EnemyCharacter>(func));
            }

            for (var i = 0; i < 10; i++)
            {
                SpawnOnMap(i % 2 == 0 ? 1 : -1, i % 3 == 0 ? 1 : -1);
            }
        }

        internal EnemyCharacter SpawnOnMap(int positionOffsetX, int positionOffsetZ)
        {
            var enemyGeneratingRadius = new Vector3(10, 0, 5);
            var enemyGeneratingRadiusOffset = new Vector3(3, 0, 2);


            var x = NextFloat(enemyGeneratingRadiusOffset.x, enemyGeneratingRadius.x) / 2;
            var z = NextFloat(enemyGeneratingRadiusOffset.z, enemyGeneratingRadius.z) / 2;

            var newPosition = new Vector3(x * positionOffsetX,0, z * positionOffsetZ) ;

            var enemyCharacter = _charactersEnemy.First().Value.Get();
            enemyCharacter.UpdatePresentationPosition(newPosition);

            return enemyCharacter;
        }
        
        // TODO: Вынести в какой-нибудь хелпер
        private float NextFloat(float min, float max){
            var random = new Random();
            var val = (random.NextDouble() * (max - min) + min);
            
            return (float)val;
        }
    }
}