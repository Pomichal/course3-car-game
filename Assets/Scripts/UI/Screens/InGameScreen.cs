namespace UI
{
    public class InGameScreen : ScreenBase
    {

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public void ReturnToMenu()
        {
            App.gameManager.ReturnToMenu();
            Hide();
        }
    }
}
