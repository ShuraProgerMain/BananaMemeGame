using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.CharactersData
{
    [CreateAssetMenu(menuName = "CharacterParameters/Enemy")]
    public sealed class EnemyCharacterData : ScriptableObject, IDefaultCharacterData
    {
        [field: SerializeField]
        public BaseCharacterData CharacterData { get; private set; }
        [field: SerializeField]
        public CharacterPresentationData CharacterPresentationData { get; private set; }
    }
}