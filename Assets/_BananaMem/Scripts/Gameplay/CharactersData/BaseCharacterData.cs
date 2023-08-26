using System;
using UnityEngine;

namespace ShuraGames.BananaMeme.Gameplay.CharactersData
{
    [Serializable]
    public struct BaseCharacterData
    {
        [field: SerializeField]
        public float Health { get; private set; }
        [field: SerializeField]
        public float Armor { get; private set; }
        [field: SerializeField]
        public float MoveSpeed { get; private set; }
    }
}