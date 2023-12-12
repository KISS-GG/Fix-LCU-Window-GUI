using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fix_LCU_Window
{
    public partial class MainForm : Form
    {
        private static bool _autoChangeFlag;
        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await Program.Plan1(), "提示");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(await Program.Plan3(), "提示");
            }
            catch (Exception)
            {
                MessageBox.Show("操作失败，可能是英雄联盟未运行！", "提示");
            }
        }
        
        private async void  button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(await Program.Plan4(), "提示");
            }
            catch (Exception)
            {
                MessageBox.Show("操作失败，可能是英雄联盟未运行！", "提示");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _autoChangeFlag = !_autoChangeFlag;
            if (_autoChangeFlag)
            {
                // 启动
                button4.Text = "关闭自动恢复客户端大小";
                AutoChange();
            }
            else
            {
                // 关闭
                button4.Text = "启动自动恢复客户端大小";
            }
        }
        
        static async void AutoChange()
        {
            while (_autoChangeFlag)
            {
                await Program.FixLeagueClientWindow();
                await Task.Delay(1500);
            };
        }
        
    }
}