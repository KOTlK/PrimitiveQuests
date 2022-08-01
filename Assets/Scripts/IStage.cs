using View;

namespace PrimitiveQuests
{
    public interface IStage : IAccomplishable, IDescribable
    {
        void Begin();
        void Complete();
    }
}