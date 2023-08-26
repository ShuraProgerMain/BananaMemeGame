using System.Collections.Generic;
using UnityEngine;

namespace ShuraGames.BananaMeme.SkillsSystem
{
    internal interface ISkillsBehaviour
    {
        public void AddSkill(in ISkill skill);
    }
    
    internal class SkillsBehaviours : ISkillsBehaviour
    {
        private readonly byte _maxSkillsCount;
        private byte _currentSkillsCount;

        private readonly ISkill[] _skills;

        public SkillsBehaviours(byte maxSkillsCount, IReadOnlyList<ISkill> skills)  // Нет смысла выделываться с дженериками, потому что наследники ISkill всегда классы
        {
            _maxSkillsCount = maxSkillsCount;
            _currentSkillsCount = (byte)skills.Count;
            
            _skills = new ISkill[maxSkillsCount];
            
            for (var i = 0; i < skills.Count; i++)
            {
                _skills.SetValue(skills[i], i);
                
                skills[i].Employ();
            }
        }

        public void AddSkill(in ISkill skill)
        {
            if (_currentSkillsCount >= _maxSkillsCount)
                Debug.LogError("Chota ne to");
            
            _skills[_currentSkillsCount] = skill;
            _currentSkillsCount++;
            
            skill.Employ();
        }
    }
}