using UnityEngine;

namespace ShuraGames.BananaMeme.SkillsSystem
{
    internal interface ISkill
    {
        public void Employ();
    }

    internal class MagicBallSkill : ISkill
    {
        private MagicBallSkillData _skillData;

        public MagicBallSkill(MagicBallSkillData skillData)
        {
            _skillData = skillData;
        }
        
        public void Employ()
        {
            Debug.Log("Magic ball some work");
        }
    }
}