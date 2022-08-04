using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public interface IQuestBook : IDrawable<IQuestBookView>
    {
        void Add(IQuest quest);
    }
}