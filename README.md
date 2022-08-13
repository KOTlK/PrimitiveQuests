# PrimitiveQuests

# **Usage**

## There is two ways of creating quests:
1. ### Create it with **_Quest_** class cunstructor:
``` csharp
var quest = new Quest(
    new IStage[]
    {
        new Stage("Test stage 1", "Test description 1"),
        new Stage("Test stage 2", "Test description 2", OnComplete),
        new Stage("Test stage 3", "Test description 3", OnBegin, OnComplete)
    });
```
2. ### Create new class, inherited from **_InheritableQuest_** and write logic there:
``` csharp
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
```

## To draw quests on the screen there is view for each object:
- **_IQuestBookView_**
- **_IQuestView_**
- **_IStageView_**

### Implement this interfaces in your view and draw your quests:
```csharp
namespace PrimitiveQuests.View
{
    public class QuestBook : MonoBehaviour, IQuestBookView
    {
        [SerializeField] private QuestView _questViewPrefab;


        private readonly Dictionary<IQuest, IQuestView> _spawnedQuests = new();


        public void UpdateQuests(IEnumerable<IQuest> quests)
        {
            foreach (var quest in quests)
            {
                if (_spawnedQuests.ContainsKey(quest))
                {
                    quest.DrawStages(_spawnedQuests[quest]);
                    continue;
                }

                var obj = InstantiateNewQuest();
                _spawnedQuests.Add(quest, obj);
                quest.DrawStages(obj);
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private QuestView InstantiateNewQuest()
        {
            return Instantiate(_questViewPrefab, transform);
        }
    }
}
```

## Stages can be created same as quests, either with constructor or inherit from **_Stage_** class:

``` csharp
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
```