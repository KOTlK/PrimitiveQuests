using System.Collections.Generic;
using PrimitiveQuests;

namespace View
{
    public interface IQuestView
    {
        void UpdateStages(IEnumerable<IStage> stages);
    }
}