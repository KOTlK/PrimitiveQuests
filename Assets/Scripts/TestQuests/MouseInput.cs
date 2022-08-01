using System;
using System.Collections;
using UnityEngine;

namespace PrimitiveQuests.TestQuests
{
    public class MouseInput : MonoBehaviour, IMouseInput
    {
        public event Action LMBClicked;
        public event Action DoubleLMBClick;
        public event Action TripleLMBClick;

        [SerializeField] private int _clickThreshold = 50;

        private Coroutine _coroutine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(Clicking(_clickThreshold));
                }
            }
        }

        private IEnumerator Clicking(int threshold)
        {
            var lmbPressed = 0;
            var framesPassed = 0;
            
            while (framesPassed < threshold)
            {
                if (lmbPressed == 3) break;
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    framesPassed = 0;
                    lmbPressed++;
                }

                framesPassed++;
                yield return null;
            }

            switch (lmbPressed)
            {
                case 1:
                    LMBClicked?.Invoke();
                    break;
                case 2:
                    DoubleLMBClick?.Invoke();
                    break;
                case 3:
                    TripleLMBClick?.Invoke();
                    break;
                default:
                    throw new ArgumentException("Wrong argument", nameof(lmbPressed));
            }
            
            _coroutine = null;
        }
        
    }
}