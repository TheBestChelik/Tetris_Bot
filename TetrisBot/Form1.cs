namespace TetrisBot
{
    public partial class TetrisBot : Form
    {
        public TetrisBot()
        {
            InitializeComponent();
            if (Properties.Settings.Default.BoardPos.IsEmpty)
            {
                CalibrationInfo.Text = Properties.Settings.Default.MustCalibrate;
                log.Text = Properties.Settings.Default.LogTextMustCalibrate;
                PlayBut.Enabled = false;
            }
            else
            {
                CalibrationInfo.Text = string.Format(Properties.Settings.Default.CalibrationInfo,
                    Environment.NewLine,
                    Properties.Settings.Default.BoardPos.ToString(),
                    Properties.Settings.Default.BoardSize.ToString(),
                    Properties.Settings.Default.NextFigurePos.ToString(),
                    Properties.Settings.Default.NextFigureSize.ToString());
                log.Text = Properties.Settings.Default.LogTextCalibrationDone;
                PlayBut.Enabled = true;
            }
            label3.Text = String.Format(Properties.Settings.Default.PauseBtwPresText, Properties.Settings.Default.PauseBtwPressingKeys.ToString());
            trackBar1.Value = Properties.Settings.Default.PauseBtwPressingKeys;
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            CalibrationInfo.Text = Properties.Settings.Default.CalibrationWaitMessage;
            button1.Enabled = false;
            await Task.Run(() => {
                CalibrationInfo.Text = MainCalibration.main(BoardPic.Image, NextPic.Image);
                button1.Enabled = true;
                if (Properties.Settings.Default.BoardPos.IsEmpty)
                {
                    log.Text = Properties.Settings.Default.LogTextMustCalibrate;
                    PlayBut.Enabled = false;
                }
                else
                {
                    log.Text = Properties.Settings.Default.LogTextCalibrationDone;
                    PlayBut.Enabled = true;
                }

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BoardPic.Image = Clipboard.GetImage();
            if (BoardPic.Image != null && NextPic.Image != null)
                button1.Enabled = true;
            else
                button1.Enabled=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NextPic.Image = Clipboard.GetImage();
            if (BoardPic.Image != null && NextPic.Image != null)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        async private void PlayBut_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                log.Text = "Start the tetris game and TetrisBot will play it!";
                PlayBut.Enabled = false;
                while (true)
                {
                    log.Text = MainPlaying.Start(MainCalibration.Board, MainCalibration.NextFig, log);
                }
            });
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.PauseBtwPressingKeys = trackBar1.Value;
            Properties.Settings.Default.Save();
            label3.Text = String.Format(Properties.Settings.Default.PauseBtwPresText, Properties.Settings.Default.PauseBtwPressingKeys.ToString());

        }
    }
}