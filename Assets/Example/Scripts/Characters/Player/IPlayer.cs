using PrimitiveQuests;

namespace Example.Scripts.Characters
{
    public interface IPlayer : ICharacter
    {
        void GiveQuest(IQuest quest);
    }
}