namespace Card_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
            //Sifre = Password
        {
            try
            {
                if (textBox1.Text=="Password")
                {
                    
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}