using System;
using View;

namespace PrimitiveQuests
{
    public abstract class InheritableQuest : IQuest
    {
        protected abstract IStage[] Stages { get; set; }

        private int _currentStage = 0;
        
        protected const string NoName = "No Name";
        protected const string NoDescription = "No Description";

        public abstract string Name { get; }
        public abstract string Description { get; }
        public bool Completed => Stages[^1].Completed;

        public void StartQuest()
        {
            if (_currentStage != 0) throw new Exception("The quest is already started");
            Stages[_currentStage].Begin();
        }

        public void NextStage()
        {
            Stages[_currentStage].Complete();
            if (_currentStage + 1 >= Stages.Length) return;

            do
            {
                _currentStage++;
            } while (Stages[_currentStage].Completed);
            
            Stages[_currentStage].Begin();
        }

        public void CompleteStage(int index, bool completeEveryBefore = false)
        {
            if (index >= Stages.Length) throw new IndexOutOfRangeException();

            if (completeEveryBefore)
            {
                while (_currentStage != index)
                {
                    NextStage();
                }
            }
            
            Stages[index].Complete();
        }

        public void Draw(IQuestView view)
        {
            view.UpdateStages(Stages);
            view.UpdateQuest(this);
        }
    }
}