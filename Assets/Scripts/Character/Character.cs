using PrimitiveQuests.TestQuests;
using UnityEngine;

namespace PrimitiveQuests.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private View.QuestBook _questBookView;
        [SerializeField] private MouseInput _mouseInput;


        private IQuestBookController _quests;

        private void Awake()
        {
            _quests = new QuestBookController(
                new QuestBook(),
                _questBookView);

            _quests.Add(
                new ClickMouseButton(
                    _mouseInput,
                    _quests));

        }
    }
}