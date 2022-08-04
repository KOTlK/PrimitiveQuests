using System.Collections.Generic;
using PrimitiveQuests;
using TMPro;
using UnityEngine;
using PrimitiveQuests.View;

namespace Example.Scripts.UI
{
    public class QuestView : MonoBehaviour, IQuestView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private StageView _stagePrefab;
        [SerializeField] private Transform _stagesParent;
        
        private readonly Dictionary<IStage, StageView> _spawnedStages = new();


        public void UpdateQuest(IQuest quest)
        {
            _name.text = quest.Name;
            _description.text = quest.Description;
        }

        public void UpdateStages(IEnumerable<IStage> stages)
        {
            foreach (var stage in stages)
            {
                if (_spawnedStages.ContainsKey(stage))
                {
                    _spawnedStages[stage].UpdateStage(stage);
                    continue;
                }
                
                var obj = InstantiateStage();
                _spawnedStages.Add(stage, obj);
                obj.UpdateStage(stage);
            }
        }

        private StageView InstantiateStage()
        {
            return Instantiate(_stagePrefab, _stagesParent);
        }
    }
}