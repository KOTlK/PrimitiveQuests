# PrimitiveQuests (**_Work In Progress_**)

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
........