using System;
using System.Collections.Generic;
using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public sealed class QuestBook : IQuestBook
    {
        private readonly List<IQuest> _quests;

        public QuestBook() : this(Array.Empty<IQuest>())
        {
        }
        public QuestBook(IEnumerable<IQuest> quests)
        {
            _quests = new List<IQuest>(quests);
        }

        public void Add(IQuest quest)
        {
            if (_quests.Contains(quest))
                throw new ArgumentException($"{nameof(quest)} is already exist", nameof(quest));

            _quests.Add(quest);
            quest.StartQuest();
        }

        public void Draw(IQuestBookView view)
        {
            view.UpdateQuests(_quests);
        }
    }
}