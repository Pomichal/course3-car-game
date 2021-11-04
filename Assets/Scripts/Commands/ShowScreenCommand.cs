namespace Commands
{
    public class ShowScreenCommand<T> : ICommand
    {

        public void Execute()
        {
            App.screenManager.Show<T>();
        }
    }
}
