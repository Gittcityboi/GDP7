using UnityEngine;

public interface Skill
{
    void UseSkill();
    float cooltime { get; }
    int use_number { get; }
    float cost { get; }
    string text { get; }
    Texture skill_icon { get; }
}