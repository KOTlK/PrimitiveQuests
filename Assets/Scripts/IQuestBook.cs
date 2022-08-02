using PrimitiveQuests.View;
using View;

namespace PrimitiveQuests
{
    public interface IQuestBook : IDrawable<IQuestBookView>
    {
        void Add(IQuest quest);
    }
}