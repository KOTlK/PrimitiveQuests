using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public interface IQuestBook
    {
        void Add(IQuest quest);
        void Draw(IQuestBookView view);
    }
}