using System.Collections.Generic;

namespace PrimitiveQuests.View
{
    public interface IQuestBookView : IWindow
    {
        void UpdateQuests(IEnumerable<IQuest> quests);
    }
}