namespace Pong_4ITA
{
    public partial class Form1 : Form
    {
        public Form1(SettingsData settings = null) {
            InitializeComponent();
            if(settings != null) {
                label1.Text = settings.player1;
                label2.Text = settings.player2;

                canvas1.SetBallSpeed(settings.ballSpeed);
                canvas1.ScoreChanged += OnScoreChanged;
            }
        }

        private void OnScoreChanged(int score1, int score2) {
            label3.Text = $"{score1}:{score2}";
        }
    }
}