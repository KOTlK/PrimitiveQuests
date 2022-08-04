using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts.UI
{
    public class QuestCompletion : MonoBehaviour
    {
        [SerializeField] private Sprite _completed;
        [SerializeField] private Sprite _uncompleted;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetCompletion(bool completed)
        {
            if (_image == null) _image = GetComponent<Image>();
            if (completed)
            {
                _image.sprite = _completed;
                return;
            }
            // I Don't give a fuck why there is Null reference exception on _sprite
            
            _image.sprite = _uncompleted;
        }
    }
}