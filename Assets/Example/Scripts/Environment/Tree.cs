using System;
using UnityEngine;

namespace Example.Scripts.Environment
{
    public class Tree : MonoBehaviour, ITree
    {
        public event Action CutDown;

        public void Interact()
        {
            CutDown?.Invoke();
            Destroy(gameObject);
        }
    }
}