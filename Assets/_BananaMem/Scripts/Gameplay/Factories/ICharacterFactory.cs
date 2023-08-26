using ShuraGames.BananaMeme.Gameplay.CharactersData;

namespace ShuraGames.BananaMeme.Gameplay.Factories
{
    internal interface ICharacterFactory
    {
        public ICharacter GetCharacter(IDefaultCharacterData characterData);
    }
}