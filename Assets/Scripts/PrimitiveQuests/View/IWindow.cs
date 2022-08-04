namespace PrimitiveQuests.View
{
    public interface IWindow
    {
        bool IsActive { get; }
        void Open();
        void Close();
    }
}