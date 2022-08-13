using Example.Scripts.Environment;
using PrimitiveQuests;

namespace Example.Scripts.Quests
{
    public class ChopTrees : InheritableQuest
    {
        protected override IStage[] StagesInternal { get; }
        protected override string NameInternal { get; }
        protected override string DescriptionInternal { get; }

        public ChopTrees(ITree[] trees)
        {
            NameInternal = nameof(ChopTrees);
            DescriptionInternal = "Chop trees to complete the quest";
            StagesInternal = new IStage[]
            {
                new ChopThreeTrees(trees)
            };
        }
    }
}