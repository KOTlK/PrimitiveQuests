using System.Collections.Generic;
using PrimitiveQuests;
using UnityEngine;
using Stage = PrimitiveQuests.View.Stage;

namespace View
{
    [RequireComponent(typeof(RectTransform))]
    public class QuestView : MonoBehaviour, IQuestView
    {
        [SerializeField] private Stage _stagePrefab;
        
        private readonly Dictionary<IStage, Stage> _spawnedStages = new();


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

        private Stage InstantiateStage()
        {
            return Instantiate(_stagePrefab, transform);
        }
    }
}