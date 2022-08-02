using View;

namespace PrimitiveQuests
{
    public interface IQuest : IAccomplishable, IDescribable, IDrawable<IQuestView>
    {
        void StartQuest();
        void NextStage();
        void CompleteStage(int index, bool completeEveryBefore = false);
    }
}