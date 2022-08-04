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
        
        public bool IsActive => _questBookView.IsActive;

        public void Add(IQuest quest)
        {
            _questBook.Add(quest);
            UpdateView();
        }

        public void UpdateView()
        {
            _questBook.Draw(_questBookView);
        }

        public void Open()
        {
            _questBookView.Open();
            UpdateView();
        }

        public void Close() => _questBookView.Close();
    }
}