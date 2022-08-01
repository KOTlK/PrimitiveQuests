using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public class QuestBookController : IQuestBookController
    {
        private readonly IQuestBook _questBook;
        private readonly IQuestBookView _questBookView;

        public QuestBookController(IQuestBook questBook, IQuestBookView questBookView)
        {
            _questBook = questBook;
            _questBookView = questBookView;
        }

        public void Add(IQuest quest)
        {
            _questBook.Add(quest);
            UpdateBook();
        }

        public void UpdateBook()
        {
            _questBook.Draw(_questBookView);
        }
    }
}