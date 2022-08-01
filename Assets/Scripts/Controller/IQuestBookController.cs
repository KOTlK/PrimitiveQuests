namespace PrimitiveQuests
{
    public interface IQuestBookController
    {
        void Add(IQuest quest);
        void UpdateBook();
    }
}