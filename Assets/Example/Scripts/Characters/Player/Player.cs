using System;
using PrimitiveQuests;
using UnityEngine;
using Example.Scripts.Characters.Animation;

namespace Example.Scripts.Characters
{
    public class Player : MonoBehaviour, IPlayer
    {
        private event Action SpaceClicked;
        private event Action EClicked;
        
        [SerializeField] private float _speed = 5f;
        [SerializeField] private ContactFilter2D _contactFilterForInteraction;
        
        private readonly PlayerAnimation _animationProperties = new();
        
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;

        private IQuestBookController _questBook;

        
        public string Name { get; private set; }

        public void Init(string name, IQuestBookController questBookController)
        {
            Name = name;
            _questBook = questBookController;
            SpaceClicked += Interact;
            EClicked += OpenCloseQuestBook;
        }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }
        

        public void Move(Vector2 direction)
        {
            _animationProperties.Speed = _speed * Time.deltaTime * direction.magnitude;

            _renderer.flipX = direction.x < 0;
            
            _rigidbody.MovePosition(_rigidbody.position + direction * _animationProperties.Speed);
            
            _animator.SetFloat(nameof(_animationProperties.Speed), _animationProperties.Speed);
        }


        public void GiveQuest(IQuest quest) => _questBook.Add(quest);
        

        private void Interact()
        {
            var results = new Collider2D[16];

            if(Physics2D.OverlapCircle(transform.position, 0.5f, _contactFilterForInteraction, results) < 1) return;

            foreach (var result in results)
            {
                if (result != null)
                {
                    if (result.TryGetComponent(out IInteractable interactable))
                    {
                        interactable.Interact();
                    }
                }
            }
        }

        private void OpenCloseQuestBook()
        {
            if (_questBook.IsActive) _questBook.Close();
            else _questBook.Open();
        }
        

        private void OnDestroy()
        {
            EClicked -= OpenCloseQuestBook;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpaceClicked?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                EClicked?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            Move(new Vector2(h, v));
        }
        
    }
}

