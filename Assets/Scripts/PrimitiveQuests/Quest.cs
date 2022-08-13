using System;
using PrimitiveQuests.View;

namespace PrimitiveQuests
{
    public class Quest : IQuest
    {
        protected virtual IStage[] _stages { get; set; }

        private int _currentStage = 0;
        
        private const string NoName = "No Name";
        private const string NoDescription = "No Description";


        public Quest()
        {
        }
        public Quest(IStage[] stages, string name, string description) : this(stages)
        {
            Name = name;
            Description = description;
        }
        public Quest(IStage[] stages)
        {
            if (stages.Length == 0)
                throw new ArgumentException($"{nameof(stages)} can not be less than 0", nameof(stages));
            
            _stages = stages;
            Name = NoName;
            Description = NoDescription;
        }

        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public bool Completed => _stages[^1].Completed;

        public void StartQuest()
        {
            if (_currentStage != 0) throw new Exception("The quest is already started");
            _stages[_currentStage].Begin();
        }

        public void NextStage()
        {
            _stages[_currentStage].Complete();
            if (_currentStage + 1 >= _stages.Length) return;

            do
            {
                _currentStage++;
            } while (_stages[_currentStage].Completed);
            
            _stages[_currentStage].Begin();
        }

        public void CompleteStage(int index, bool completeEveryBefore = false)
        {
            if (index >= _stages.Length) throw new IndexOutOfRangeException();

            if (completeEveryBefore)
            {
                while (_currentStage != index)
                {
                    NextStage();
                }
            }
            
            _stages[index].Complete();
        }

        public void Draw(IQuestView view)
        {
            view.UpdateStages(_stages);
            view.UpdateQuest(this);
        }
    }

}