using System.Collections.Generic;
using PrimitiveQuests;
using PrimitiveQuests.View;
using UnityEngine;

namespace Example.Scripts.UI
{
    public class QuestBookView : MonoBehaviour, IQuestBookView
    {
        [SerializeField] private QuestView _questViewPrefab;
        [SerializeField] private Canvas _canvas;


        private readonly Dictionary<IQuest, IQuestView> _spawnedQuests = new();

        public bool IsActive { get; private set; }

        public void UpdateQuests(IEnumerable<IQuest> quests)
        {
            foreach (var quest in quests)
            {
                if (_spawnedQuests.ContainsKey(quest))
                {
                    quest.Draw(_spawnedQuests[quest]);
                    continue;
                }

                var obj = InstantiateNewView();
                _spawnedQuests.Add(quest, obj);
                quest.Draw(obj);
            }
        }

        public void Open()
        {
            if (IsActive) return;
            _canvas.gameObject.SetActive(true);
            IsActive = true;
        }

        public void Close()
        {
            if (IsActive == false) return;
            _canvas.gameObject.SetActive(false);
            IsActive = false;
        }

        private QuestView InstantiateNewView()
        {
            return Instantiate(_questViewPrefab, transform);
        }
    }
}