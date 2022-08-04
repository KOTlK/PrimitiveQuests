using System;

namespace PrimitiveQuests
{
    public class Stage : IStage
    {
        private readonly Action _onBegin;
        private readonly Action _onComplete;

        public bool Completed { get; private set; } = false;

        public Stage(string name, string description, Action onBegin, Action onComplete) : this(name, description)
        {
            _onBegin = onBegin;
            _onComplete = onComplete;
        }
        public Stage(string name, string description, Action onComplete) : this(name, description)
        {
            _onComplete = onComplete;
        }
        public Stage(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Stage()
        {
            // Constructor for inheritors
        }
        
        public virtual string Name { get; }
        public virtual string Description { get; }

        public virtual void Begin()
        {
            if (Completed) throw new Exception("The stage is already completed");
            Completed = false;
            _onBegin?.Invoke();
        }

        public virtual void Complete()
        {
            if (Completed) throw new Exception("The stage is already completed");
            Completed = true;
            _onComplete?.Invoke();
        }
  
    }
}