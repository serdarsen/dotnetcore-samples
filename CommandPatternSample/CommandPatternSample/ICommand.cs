namespace CommandPatternSample
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}