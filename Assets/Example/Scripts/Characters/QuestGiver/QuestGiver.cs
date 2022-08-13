using Example.Scripts.Characters.Animation;
using PrimitiveQuests;
using TMPro;
using UnityEngine;

namespace Example.Scripts.Characters.QuestGiver
{
    public class QuestGiver : MonoBehaviour, IInteractableCharacter
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private TMP_Text _hint;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private PlayerAnimation _animationProperties = new();

        private IQuest _quest;
        private IPlayer _player;
        private bool _questGiven = false;
        
        public string Name { get; private set; }

        public void Init(string name, IQuest quest)
        {
            Name = name;
            _quest = quest;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        
        public void Move(Vector2 direction)
        {
            _animationProperties.Speed = _speed * Time.deltaTime * direction.magnitude;

            _spriteRenderer.flipX = direction.x < 0;
            
            _rigidbody.MovePosition(_rigidbody.position + direction * _animationProperties.Speed);
            
            _animator.SetFloat(nameof(_animationProperties.Speed), _animationProperties.Speed);
        }
        
        public void Interact()
        {
            if (_questGiven) return;
            if (_player == null) return;
            
            _player.GiveQuest(_quest);
            _questGiven = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                _player = player;
                ShowHint();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                _player = null;
                HideHint();
            }
        }
        
        private void ShowHint()
        {
            _hint.gameObject.SetActive(true);
        }

        private void HideHint()
        {
            _hint.gameObject.SetActive(false);
        }
    }
}