using System.Collections.Generic;
using UnityEngine;
using View;

namespace PrimitiveQuests.View
{
    public class QuestBook : MonoBehaviour, IQuestBookView
    {
        [SerializeField] private QuestView _questViewPrefab;


        private readonly Dictionary<IQuest, IQuestView> _spawnedQuests = new();


        public void UpdateQuests(IEnumerable<IQuest> quests)
        {
            foreach (var quest in quests)
            {
                if (_spawnedQuests.ContainsKey(quest))
                {
                    quest.Draw(_spawnedQuests[quest]);
                    continue;
                }

                var obj = InstantiateNewQuest();
                _spawnedQuests.Add(quest, obj);
                quest.Draw(obj);
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private QuestView InstantiateNewQuest()
        {
            return Instantiate(_questViewPrefab, transform);
        }
    }
}