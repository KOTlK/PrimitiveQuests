namespace PrimitiveQuests
{
    public abstract class InheritableQuest : Quest
    {
        public override string Name => NameInternal;
        public override string Description => DescriptionInternal;
        protected override IStage[] _stages => StagesInternal;

        protected abstract IStage[] StagesInternal { get; }
        protected abstract string NameInternal { get; }
        protected abstract string DescriptionInternal { get; }
    }
}