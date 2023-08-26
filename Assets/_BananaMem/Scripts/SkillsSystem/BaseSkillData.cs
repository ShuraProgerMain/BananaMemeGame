namespace ShuraGames.BananaMeme.SkillsSystem
{
    internal sealed class BaseSkillData
    {
        public float EnemyFindRadius { get; }
        public float Cooldown { get; }
        public float Damage { get; }
        
        public BaseSkillData(float enemyFindRadius, float cooldown, float damage)
        {
            EnemyFindRadius = enemyFindRadius;
            Cooldown = cooldown;
            Damage = damage;
        }
    }

    internal sealed class MagicBallSkillData
    {
        private BaseSkillData BaseSkillData { get; }
        private uint BallsCount { get; }
        
        public MagicBallSkillData(BaseSkillData baseSkillData, uint ballsCount)
        {
            BaseSkillData = baseSkillData;
            BallsCount = ballsCount;
        }
    }
}