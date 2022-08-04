using Example.Scripts.Characters;
using Example.Scripts.Characters.QuestGiver;
using Example.Scripts.Quests;
using Example.Scripts.UI;
using PrimitiveQuests;
using UnityEngine;
using Tree = Example.Scripts.Environment.Tree;

namespace Example.Scripts.Initialization
{
    public class Init : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private QuestGiver _questGiver;
        [SerializeField] private QuestBookView _questBook;

        private void Awake()
        {
            var player = Instantiate(_player, Vector3.zero, Quaternion.identity);
            var questGiver = Instantiate(_questGiver, new Vector3(-2, -4, 0), Quaternion.identity);

            var trees = FindObjectsOfType<Tree>();

            
            player.Init(
                "Player",
                new QuestBookController(
                    new QuestBook(),
                    _questBook));

            questGiver.Init("QuestGiver", new Quest(
                new IStage[]
                {
                    new ChopThreeTrees(trees)
                },
                "Trees Chopper",
                "Chop trees until the quest is done"));
        }
    }
}