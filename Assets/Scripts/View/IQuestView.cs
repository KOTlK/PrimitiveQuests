using System.Collections.Generic;
using PrimitiveQuests;

namespace View
{
    public interface IQuestView
    {
        void UpdateQuest(IQuest quest);
        void UpdateStages(IEnumerable<IStage> stages);
    }
}