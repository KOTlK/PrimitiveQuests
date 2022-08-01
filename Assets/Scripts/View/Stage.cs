using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrimitiveQuests.View
{
    [RequireComponent(typeof(RectTransform))]
    public class Stage : MonoBehaviour, IStageView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _status;
        
        public void UpdateStage(IStage stage)
        {
            _name.text = stage.Name;
            _description.text = stage.Description;
            _status.color = stage.Completed ? Color.green : Color.red;
            Debug.Log($"{stage.Name} - {stage.Completed}");
        }
    }
}