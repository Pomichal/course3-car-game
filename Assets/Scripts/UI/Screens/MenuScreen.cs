namespace UI
{
    public class MenuScreen : ScreenBase
    {

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public void StartButtonClicked()
        {
            App.gameManager.StartGame();
            Hide();
        }

        public void SettingsButtonClicked()
        {
            App.screenManager.Show<SettingsPopup>();
        }
    }
}
