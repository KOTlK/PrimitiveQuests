using System.Collections.Generic;

namespace PrimitiveQuests.View
{
    public interface IQuestView
    {
        void UpdateQuest(IQuest quest);
        void UpdateStages(IEnumerable<IStage> stages);
    }
}