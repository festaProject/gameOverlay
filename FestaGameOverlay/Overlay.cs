namespace FestaGameOverlay
{
    public partial class Overlay : Form
    {
        private void LoadFromCPanel()
        {
            // 플레이어 목록 불러오기
            playerList = new List<Player>() { Program.A, Program.B, Program.C, Program.D, Program.E };
            playerList = playerList.Where(player => player.OnStage).ToList();

            if (playerList.Count != 2)
            {
                Program.OpenedOverlay?.Close();
                return;
            }

            One = playerList[0];
            Two = playerList[1];

            UpdateLabel();
        }

        private void UpdateLabel()
        {
            Stage.Text = Program.Stage;
            Match.Text = Program.Match + " " + Program.MatchDetail;

            Player1.Text = One?.Name;
            Player2.Text = Two?.Name;

            ResetStatusImage();
        }

        private void ResetStatusImage()
        {
            Player1Status.Image = null;
            Player2Status.Image = null;
        }

        Player? One;
        Player? Two;
        List<Player>? playerList;

        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            LoadFromCPanel();
        }

        private void UpdateOverlay_Click(object sender, EventArgs e)
        {
            LoadFromCPanel();
        }

        private void ChangePosition_Click(object sender, EventArgs e)
        {
            (Two, One) = (One, Two);
            UpdateLabel();
        }

        private void Player1Win_Click(object sender, EventArgs e)
        {
            ResetStatusImage();
            Player1Status.Image = Properties.Resources.Winner;
        }

        private void Player2Win_Click(object sender, EventArgs e)
        {
            ResetStatusImage();
            Player2Status.Image = Properties.Resources.Winner;
        }
    }
}
