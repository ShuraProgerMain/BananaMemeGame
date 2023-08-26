namespace ShuraGames.BananaMeme.Debuffs
{
    internal struct BaseCharacterData
    {
        internal uint MoveSpeed { get; private set; }
        internal uint Health { get; private set; }
        internal byte Armor { get; private set; }
    }

    internal readonly struct FiredDebuffDto
    {
        public readonly float FiredChance { get; }
        public readonly float FiredTime { get; }
        
        public FiredDebuffDto(float firedChance, float firedTime)
        {
            FiredChance = firedChance;
            FiredTime = firedTime;
        }
    }
    
    internal readonly struct FreezingDebuffDto
    {
        public readonly float FreezingChance { get; }
        public readonly float FreezingTime { get; }
        
        public FreezingDebuffDto(float freezingChance, float freezingTime)
        {
            FreezingChance = freezingChance;
            FreezingTime = freezingTime;
        }
    }
    
    internal interface IFired
    {
        public void Impose(FiredDebuffDto dto);
    }

    internal interface IFreezing
    {
        public void Impose(FreezingDebuffDto dto);
    }

    internal class DebuffsBehaviour : IFired, IFreezing
    {
        public void Impose(FiredDebuffDto dto)
        {
            
        }

        public void Impose(FreezingDebuffDto dto)
        {
            
        }
    }
}