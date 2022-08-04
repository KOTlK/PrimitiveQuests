using Example.Scripts.Environment;
using PrimitiveQuests;

namespace Example.Scripts.Quests
{
    public class ChopThreeTrees : Stage
    {
        private readonly ITree[] _trees;

        private int _treesCutDown = 0;

        public ChopThreeTrees(ITree[] trees)
        {
            _trees = trees;
        }

        public override string Name => "Get three trees";
        public override string Description => "Find a place where the trees grow and chop three of it";

        public override void Begin()
        {
            base.Begin();
            
            foreach (var tree in _trees)
            {
                tree.CutDown += TryComplete;
            }
        }

        public override void Complete()
        {
            foreach (var tree in _trees)
            {
                tree.CutDown -= TryComplete;
            }
            base.Complete();
        }

        private void TryComplete()
        {
            _treesCutDown++;
            if (_treesCutDown < 3) return;

            Complete();
        }
    }
}