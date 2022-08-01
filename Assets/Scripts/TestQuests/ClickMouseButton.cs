using System;

namespace PrimitiveQuests.TestQuests
{
    public class ClickMouseButton : InheritableQuest, IDisposable
    {
        private readonly IMouseInput _mouseInput;
        private readonly IQuestBookController _questBookController;

        public ClickMouseButton(IMouseInput mouseInput, IQuestBookController questBookController)
        {
            _mouseInput = mouseInput;
            _questBookController = questBookController;
            _mouseInput.LMBClicked += CompleteStage1;
            _mouseInput.DoubleLMBClick += CompleteStage2;
            _mouseInput.TripleLMBClick += CompleteStage3;
        }

        protected override IStage[] Stages { get; set; } = 
        {
            new Stage(
                "Click Left Mouse Button once",
                "You should click left mouse button to complete this quest"),
            new Stage(
                "Click Left Mouse Button twice",
                "You should click left mouse button two times to complete this quest"),
            new Stage(
                "Click Left Mouse Button three times",
                "You should click left mouse button three times to complete this quest")
        };
        public override string Name => "Mouse Button Click";
        public override string Description => "Click mouse button to complete";

        public void Dispose()
        {
            _mouseInput.LMBClicked -= CompleteStage1;
            _mouseInput.DoubleLMBClick -= CompleteStage2;
            _mouseInput.TripleLMBClick -= CompleteStage3;
        }

        private void CompleteStage1()
        {
            CompleteStage(0);
            _questBookController.UpdateBook();
        }

        private void CompleteStage2()
        {
            CompleteStage(1);
            _questBookController.UpdateBook();
        }

        private void CompleteStage3()
        {
            CompleteStage(2);
            _questBookController.UpdateBook();
        }
    }
}