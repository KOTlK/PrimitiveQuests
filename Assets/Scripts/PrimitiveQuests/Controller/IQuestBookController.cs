using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public interface IQuestBookController : IWindow
    {
        void Add(IQuest quest);
        void UpdateView();
    }
}