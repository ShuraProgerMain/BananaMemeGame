using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.CharactersData
{
    public sealed class CharacterPresentationData : MonoBehaviour
    {
        [field: SerializeField]
        public Transform Transform { get; private set; }
    }
}