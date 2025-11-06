public interface Skill
{
    void UseSkill();      // 기능(함수)
    float cooltime { get; }  // 읽기 전용 프로퍼티
    int use_number { get; }   // 읽기 전용 프로퍼티
    float cost { get; }   // 읽기 전용 프로퍼티
}