using PrimitiveQuests;
using TMPro;
using UnityEngine;

namespace Example.Scripts.UI
{
    public class StageView : MonoBehaviour, IStageView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private QuestCompletion _completion;
        
        public void UpdateStage(IStage stage)
        {
            _name.text = stage.Name;
            _description.text = stage.Description;
            _completion.SetCompletion(stage.Completed);
        }
    }
}