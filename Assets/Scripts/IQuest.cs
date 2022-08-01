using View;

namespace PrimitiveQuests
{
    public interface IQuest : IAccomplishable, IDescribable
    {
        void StartQuest();
        void NextStage();
        void CompleteStage(int index, bool completeEveryBefore = false);
        void DrawStages(IQuestView view);
    }
}