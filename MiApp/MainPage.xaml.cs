namespace MiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnOtherButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {

        }
    }

}
