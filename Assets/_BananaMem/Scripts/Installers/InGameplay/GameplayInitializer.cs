using ShuraGames.BananaMeme.Gameplay.PlayerIncarnation;
using ShuraGames.BananaMeme.Gameplay.Updating;
using UnityEngine;
using VContainer;

namespace ShuraGames.BananaMeme.Installers.InGameplay
{
    internal sealed class GameplayInitializer : MonoBehaviour
    {
        private PlayerHandler _playerHandler;
        private EnemiesService _enemiesService;
        private Updater _updater;
        
        [Inject]
        private void Construct(Updater updater, PlayerHandler playerHandler, EnemiesService enemiesService)
        {
            _playerHandler = playerHandler;
            _enemiesService = enemiesService;
            _updater = updater;
        }

        private void Update()
        {
            _updater.Update();
        }


#if UNITY_EDITOR
        [SerializeField] private Vector3 enemyGeneratingRadius = new Vector3(10, 0, 5);
        [SerializeField] private Vector3 enemyGeneratingRadiusOffset = new Vector3(3, 0, 2);
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(Vector3.zero, enemyGeneratingRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawCube(Vector3.zero, enemyGeneratingRadiusOffset);
        }
#endif
    }
}