using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Card_Game
{

    public partial class Form2 : Form
    {

        ////////// Kart Tanımlamaları /////////////
        public Kartlar_Ozellikleri Kart1 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart2 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart3 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart4 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart5 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart6 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart7 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart8 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart9 = new Kartlar_Ozellikleri();
        public Kartlar_Ozellikleri Kart10 = new Kartlar_Ozellikleri();



        public Form2()
        {
            InitializeComponent();


        }

        string[] kartlar = { "Kart1", "Kart2", "Kart3", "Kart4", "Kart5", "Kart6", "Kart7", "Kart8", "Kart9", "Kart10"};
        string[] kartlar_yedek = { "Kart1", "Kart2", "Kart3", "Kart4", "Kart5", "Kart6", "Kart7", "Kart8", "Kart9", "Kart10"};
        string[] OyunModu = { "Öncül 1", "Öncül 2", "Öncül 3", "Öncül 4", "Öncül 5" };
        String SeçilenMod;
        string[] bilgisayar ={};
        string[] oyuncu = {};
        int rasgele_index;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            bilgisayar = new string[2];
            oyuncu = new string[2];
            button3.Enabled = true;
            button4.Enabled = true;           
            Random rnd5 = new Random();
            int rasgele_mod_index = rnd5.Next(OyunModu.Length);
            SeçilenMod = OyunModu[rasgele_mod_index];
            label41.Visible = true;
            label43.Visible = true;
            String Oncul1_mod = "Mod1";
            String Oncul2_mod = "Mod2";
            String Oncul3_mod = "Mod3";
            String Oncul4_mod = "Mod4";
            String Oncul5_mod = "Mod5";
            if (SeçilenMod == "Öncül 1")
            {
                label27.Text = "Oyun Modu: "+Oncul1_mod;
                label40.Text = Oncul1_mod+": ";
                label42.Text = Oncul1_mod + ": ";
            }
            else if (SeçilenMod == "Öncül 2")
            {
                label27.Text = "Oyun Modu: "+Oncul2_mod;
                label40.Text = Oncul2_mod + ": ";
                label42.Text = Oncul2_mod + ": ";
            }
            else if (SeçilenMod == "Öncül 3")
            {
                label27.Text = "Oyun Modu: "+Oncul3_mod;
                label40.Text = Oncul3_mod + ": ";
                label42.Text = Oncul3_mod + ": ";
            }
            else if (SeçilenMod == "Öncül 4")
            {
                label27.Text = "Oyun Modu: "+Oncul4_mod;
                label40.Text = Oncul4_mod + ": ";
                label42.Text = Oncul4_mod + ": ";
            }
            else if (SeçilenMod == "Öncül 5")
            {
                label27.Text = "Oyun Modu: "+Oncul5_mod;
                label40.Text = Oncul5_mod + ": ";
                label42.Text = Oncul5_mod + ": ";
            }


            for (int i = 0; i < 2; i++)
            {
                Random rnd1 = new Random();
                rasgele_index = rnd1.Next(kartlar.Length);
                bilgisayar[i] = kartlar[rasgele_index];
                kartlar = kartlar.Except(new string[] { kartlar[rasgele_index] }).ToArray();

            }

            for (int j = 0; j < 2; j++)
            {
                Random rnd2 = new Random();
                rasgele_index = rnd2.Next(kartlar.Length);
                oyuncu[j] = kartlar[rasgele_index];
                kartlar = kartlar.Except(new string[] { kartlar[rasgele_index] }).ToArray();
                
            }
            pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover.png");
            pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover.png");
            pictureBox3.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[0] + ".png");       
            pictureBox4.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[1] + ".png");
            OyuncuKart1_Eşleştirici(oyuncu[0]);
            OyuncuKart2_Eşleştirici(oyuncu[1]);
            BilgisayarKart1_Eşleştirici(bilgisayar[0]);
            BilgisayarKart2_Eşleştirici(bilgisayar[1]);

            
        }
        Boolean bilgisayarkart1_oynama=true, bilgisayarkart0_oynama=true;
        Boolean oyuncukart1_used = false, oyuncukart0_used = false;
        Boolean oyun_oynanıyor = false;
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (oyun_oynanıyor==true)
            {

            }
            else if (oyun_oynanıyor == false)
            {
                pictureBox5.Image = pictureBox3.Image;
                button3.Enabled = false;

                label28.Text = "Kalan Kart Sayısı: "+ kartlar.Length.ToString();
                Random rnd3 = new Random();
                int rasgele_index_atama = rnd3.Next(bilgisayar.Length);
                if (rasgele_index_atama == 0)
                {
                    if (bilgisayarkart0_oynama==true)
                    {
                        bilgisayarkart0_oynama = false;
                        pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                    }
                    else if (bilgisayarkart0_oynama==false)
                    {
                        bilgisayarkart1_oynama = false;
                        pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                        rasgele_index_atama = 1;
                    }
                    
                }
                else if (rasgele_index_atama == 1)
                {
                    if (bilgisayarkart1_oynama==true)
                    {
                        bilgisayarkart1_oynama = false;
                        pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                    }
                    else if (bilgisayarkart1_oynama==false)
                    {                      
                        bilgisayarkart0_oynama = false;
                        pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                        rasgele_index_atama = 0;
                    }
                    
                }               
                pictureBox6.Image = Image.FromFile(@"..\Kartlar\" + bilgisayar[rasgele_index_atama] + ".png");                
                tierortaoyuncu.Text = tierlabel1.Text;
                pictureBox3.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[0] + "_used" + ".png");
                oyuncukart0_used = true;
                if (SeçilenMod == "Öncül 1")
                {
                    label23.Text = label3.Text;
                }
                else if (SeçilenMod == "Öncül 2")
                {
                    label23.Text = label4.Text;
                }
                else if (SeçilenMod == "Öncül 3")
                {
                    label23.Text = label5.Text;
                }
                else if (SeçilenMod == "Öncül 4")
                {
                    label23.Text = label6.Text;
                }
                else if (SeçilenMod == "Öncül 5")
                {
                    label23.Text = label7.Text;
                }
                //// Pc Kartlarının Özelliklerinin Ortaya Aktarılması ////
                if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 1")
                {
                    label24.Text = label17.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 2")
                {
                    label24.Text = label16.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 3")
                {
                    label24.Text = label15.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 4")
                {
                    label24.Text = label14.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 5")
                {
                    label24.Text = label13.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                //// Pc Kart 1 index ataması için üstekinin kopyası////
                if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 1")
                {
                    label24.Text = label22.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 2")
                {
                    label24.Text = label21.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 3")
                {
                    label24.Text = label20.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 4")
                {
                    label24.Text = label19.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 5")
                {
                    label24.Text = label18.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                label28.Text = "Kalan Kart Sayısı: " + kartlar.Length.ToString();
                oyun_oynanıyor = true;
                timer1.Start();              
            }
            

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (oyun_oynanıyor==true)
            {

            }
            else if (oyun_oynanıyor==false)
            {
                pictureBox5.Image = pictureBox4.Image;
                button4.Enabled = false;
                Random rnd4 = new Random();
                int rasgele_index_atama = rnd4.Next(bilgisayar.Length);
                if (rasgele_index_atama == 0)
                {
                    if (bilgisayarkart0_oynama==true)
                    {
                        bilgisayarkart0_oynama = false;
                        pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                    }
                    else if (bilgisayarkart0_oynama==false)
                    {
                        bilgisayarkart1_oynama = false;
                        pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                        rasgele_index_atama = 1;
                    }

                }
                else if (rasgele_index_atama == 1)
                {
                    if (bilgisayarkart1_oynama==true)
                    {
                        bilgisayarkart1_oynama = false;
                        pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                    }
                    else if (bilgisayarkart1_oynama==false)
                    {
                        bilgisayarkart0_oynama = false;
                        pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover_used.png");
                        rasgele_index_atama = 0;
                    }

                }
                pictureBox6.Image = Image.FromFile(@"..\Kartlar\" + bilgisayar[rasgele_index_atama] + ".png");
                pictureBox4.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[1] + "_used" + ".png");
                oyuncukart1_used = true;
                tierortaoyuncu.Text = tierlabel2.Text;
                if (SeçilenMod == "Öncül 1")
                {
                    label23.Text = label12.Text;
                }
                else if (SeçilenMod == "Öncül 2")
                {
                    label23.Text = label11.Text;
                }
                else if (SeçilenMod == "Öncül 3")
                {
                    label23.Text = label10.Text;
                }
                else if (SeçilenMod == "Öncül 4")
                {
                    label23.Text = label9.Text;
                }
                else if (SeçilenMod == "Öncül 5")
                {
                    label23.Text = label8.Text;
                }
                //// Pc Kartlarının Özelliklerinin Ortaya Aktarılması ////
                if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 1")
                {
                    label24.Text = label17.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 2")
                {
                    label24.Text = label16.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 3")
                {
                    label24.Text = label15.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 4")
                {
                    label24.Text = label14.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                else if (rasgele_index_atama == 0 && SeçilenMod == "Öncül 5")
                {
                    label24.Text = label13.Text;
                    tierortabilgisayar.Text = tierlabel3.Text;
                }
                //// Pc Kart 1 index ataması için üstekinin kopyası////
                if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 1")
                {
                    label24.Text = label22.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 2")
                {
                    label24.Text = label21.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 3")
                {
                    label24.Text = label20.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 4")
                {
                    label24.Text = label19.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                else if (rasgele_index_atama == 1 && SeçilenMod == "Öncül 5")
                {
                    label24.Text = label18.Text;
                    tierortabilgisayar.Text = tierlabel4.Text;
                }
                label28.Text = "Kalan Kart Sayısı: " + kartlar.Length.ToString();
                oyun_oynanıyor = true;
                timer1.Start();
                

            }
            
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            ////
            Kart1.kartadi = "Kart1Adı";
            Kart1.oncul1 = 84;
            Kart1.oncul2 = 86;
            Kart1.oncul3 = 81;
            Kart1.oncul4 = 91;
            Kart1.oncul5 = 90;
            Kart1.tier = 5;
            ////
            Kart2.kartadi = "Kart2Adı";
            Kart2.oncul1 = 80;
            Kart2.oncul2 = 85;
            Kart2.oncul3 = 82;
            Kart2.oncul4 = 89;
            Kart2.oncul5 = 88;
            Kart2.tier = 4;
            ////
            Kart3.kartadi = "Kart3Adı";
            Kart3.oncul1 = 79;
            Kart3.oncul2 = 83;
            Kart3.oncul3 = 84;
            Kart3.oncul4 = 87;
            Kart3.oncul5 = 86;
            Kart3.tier = 3;
            ////
            Kart4.kartadi = "Kart4Adı";
            Kart4.oncul1 = 83;
            Kart4.oncul2 = 87;
            Kart4.oncul3 = 85;
            Kart4.oncul4 = 83;
            Kart4.oncul5 = 86;
            Kart4.tier = 4;

            ////
            Kart5.kartadi = "Kart5Adı";
            Kart5.oncul1 = 82;
            Kart5.oncul2 = 84;
            Kart5.oncul3 = 84;
            Kart5.oncul4 = 83;
            Kart5.oncul5 = 87;
            Kart5.tier = 3;
            ////
            Kart6.kartadi = "Kart6Adı";
            Kart6.oncul1 = 85;
            Kart6.oncul2 = 82;
            Kart6.oncul3 = 82;
            Kart6.oncul4 = 83;
            Kart6.oncul5 = 85;
            Kart6.tier = 2;
            ////
            Kart7.kartadi = "Kart7Adı";
            Kart7.oncul1 = 83;
            Kart7.oncul2 = 83;
            Kart7.oncul3 = 84;
            Kart7.oncul4 = 86;
            Kart7.oncul5 = 88;
            Kart7.tier = 5;
            ////
            Kart8.kartadi = "Kart8Adı";
            Kart8.oncul1 = 86;
            Kart8.oncul2 = 84;
            Kart8.oncul3 = 88;
            Kart8.oncul4 = 86;
            Kart8.oncul5 = 89;
            Kart8.tier = 5;
            ////
            Kart9.kartadi = "Kart9Adı";
            Kart9.oncul1 = 87;
            Kart9.oncul2 = 88;
            Kart9.oncul3 = 86;
            Kart9.oncul4 = 85;
            Kart9.oncul5 = 91;
            Kart9.tier = 5;
            ////
            Kart10.kartadi = "Kart10Adı";
            Kart10.oncul1 = 84;
            Kart10.oncul2 = 82;
            Kart10.oncul3 = 82;
            Kart10.oncul4 = 85;
            Kart10.oncul5 = 84;
            Kart10.tier = 4;
           

        }

        //////////// Kart Eşleştirici Fonksiyonları //////////////
        public void OyuncuKart1_Eşleştirici(string kartlar_)
        {

            //////// Picture Box 1 Eşleştirici ////////
            if (kartlar_ == "Kart1")
            {
                label1.Text = Kart1.kartadi;
                label3.Text = ""+Kart1.oncul1;
                label4.Text = ""+Kart1.oncul2;
                label5.Text = ""+Kart1.oncul3;
                label6.Text = ""+Kart1.oncul4;
                label7.Text = ""+Kart1.oncul5;
                tierlabel1.Text = "" + Kart1.tier;
                return;
            }
            else if (kartlar_ == "Kart2")
            {
                label1.Text = Kart2.kartadi;
                label3.Text = "" + Kart2.oncul1;
                label4.Text = "" + Kart2.oncul2;
                label5.Text = "" + Kart2.oncul3;
                label6.Text = "" + Kart2.oncul4;
                label7.Text = "" + Kart2.oncul5;
                tierlabel1.Text = "" + Kart2.tier;
                return;
            }
            else if (kartlar_ == "Kart3")
            {
                label1.Text = Kart3.kartadi;
                label3.Text = "" + Kart3.oncul1;
                label4.Text = "" + Kart3.oncul2;
                label5.Text = "" + Kart3.oncul3;
                label6.Text = "" + Kart3.oncul4;
                label7.Text = "" + Kart3.oncul5;
                tierlabel1.Text = "" + Kart3.tier;
                return;
            }
            else if (kartlar_ == "Kart4")
            {
                label1.Text = Kart4.kartadi;
                label3.Text = "" + Kart4.oncul1;
                label4.Text = "" + Kart4.oncul2;
                label5.Text = "" + Kart4.oncul3;
                label6.Text = "" + Kart4.oncul4;
                label7.Text = "" + Kart4.oncul5;
                tierlabel1.Text = "" + Kart4.tier;
                return;
            }
            else if (kartlar_ == "Kart5")
            {
                label1.Text = Kart5.kartadi;
                label3.Text = "" + Kart5.oncul1;
                label4.Text = "" + Kart5.oncul2;
                label5.Text = "" + Kart5.oncul3;
                label6.Text = "" + Kart5.oncul4;
                label7.Text = "" + Kart5.oncul5;
                tierlabel1.Text = "" + Kart5.tier;
                return;
            }
            else if (kartlar_ == "Kart6")
            {
                label1.Text = Kart6.kartadi;
                label3.Text = "" + Kart6.oncul1;
                label4.Text = "" + Kart6.oncul2;
                label5.Text = "" + Kart6.oncul3;
                label6.Text = "" + Kart6.oncul4;
                label7.Text = "" + Kart6.oncul5;
                tierlabel1.Text = "" + Kart6.tier;
                return;
            }
            else if (kartlar_ == "Kart7")
            {
                label1.Text = Kart7.kartadi;
                label3.Text = "" + Kart7.oncul1;
                label4.Text = "" + Kart7.oncul2;
                label5.Text = "" + Kart7.oncul3;
                label6.Text = "" + Kart7.oncul4;
                label7.Text = "" + Kart7.oncul5;
                tierlabel1.Text = "" + Kart7.tier;
                return;
            }
            else if (kartlar_ == "Kart8")
            {
                label1.Text = Kart8.kartadi;
                label3.Text = "" + Kart8.oncul1;
                label4.Text = "" + Kart8.oncul2;
                label5.Text = "" + Kart8.oncul3;
                label6.Text = "" + Kart8.oncul4;
                label7.Text = "" + Kart8.oncul5;
                tierlabel1.Text = "" + Kart8.tier;
                return;
            }
            else if (kartlar_ == "Kart9")
            {
                label1.Text = Kart9.kartadi;
                label3.Text = "" + Kart9.oncul1;
                label4.Text = "" + Kart9.oncul2;
                label5.Text = "" + Kart9.oncul3;
                label6.Text = "" + Kart9.oncul4;
                label7.Text = "" + Kart9.oncul5;
                tierlabel1.Text = "" + Kart9.tier;
                return;
            }
            else if (kartlar_ == "Kart10")
            {
                label1.Text = Kart10.kartadi;
                label3.Text = "" + Kart10.oncul1;
                label4.Text = "" + Kart10.oncul2;
                label5.Text = "" + Kart10.oncul3;
                label6.Text = "" + Kart10.oncul4;
                label7.Text = "" + Kart10.oncul5;
                tierlabel1.Text = "" + Kart10.tier;
                return;
            }
            
        }

        ///////// Oyuncu Kart2 Eşleştirici ////////////

        public  void OyuncuKart2_Eşleştirici(string kartlar_)
        {
            

            //////// Picture Box 2 Eşleştirici ////////
            if (kartlar_ == "Kart1")
            {
                label2.Text = Kart1.kartadi;
                label12.Text = "" + Kart1.oncul1;
                label11.Text = "" + Kart1.oncul2;
                label10.Text = "" + Kart1.oncul3;
                label9.Text = "" + Kart1.oncul4;
                label8.Text = "" + Kart1.oncul5;
                tierlabel2.Text = "" + Kart1.tier;
                return;
            }
            else if (kartlar_ == "Kart2")
            {
                label2.Text = Kart2.kartadi;
                label12.Text = "" + Kart2.oncul1;
                label11.Text = "" + Kart2.oncul2;
                label10.Text = "" + Kart2.oncul3;
                label9.Text = "" + Kart2.oncul4;
                label8.Text = "" + Kart2.oncul5;
                tierlabel2.Text = "" + Kart2.tier;
                return;
            }
            else if (kartlar_ == "Kart3")
            {
                label2.Text = Kart3.kartadi;
                label12.Text = "" + Kart3.oncul1;
                label11.Text = "" + Kart3.oncul2;
                label10.Text = "" + Kart3.oncul3;
                label9.Text = "" + Kart3.oncul4;
                label8.Text = "" + Kart3.oncul5;
                tierlabel2.Text = "" + Kart3.tier;
                return;
            }
            else if (kartlar_ == "Kart4")
            {
                label2.Text = Kart4.kartadi;
                label12.Text = "" + Kart4.oncul1;
                label11.Text = "" + Kart4.oncul2;
                label10.Text = "" + Kart4.oncul3;
                label9.Text = "" + Kart4.oncul4;
                label8.Text = "" + Kart4.oncul5;
                tierlabel2.Text = "" + Kart4.tier;
                return;
            }
            else if (kartlar_ == "Kart5")
            {
                label2.Text = Kart5.kartadi;
                label12.Text = "" + Kart5.oncul1;
                label11.Text = "" + Kart5.oncul2;
                label10.Text = "" + Kart5.oncul3;
                label9.Text = "" + Kart5.oncul4;
                label8.Text = "" + Kart5.oncul5;
                tierlabel2.Text = "" + Kart5.tier;
                return;
            }
            else if (kartlar_ == "Kart6")
            {
                label2.Text = Kart6.kartadi;
                label12.Text = "" + Kart6.oncul1;
                label11.Text = "" + Kart6.oncul2;
                label10.Text = "" + Kart6.oncul3;
                label9.Text = "" + Kart6.oncul4;
                label8.Text = "" + Kart6.oncul5;
                tierlabel2.Text = "" + Kart6.tier;
                return;
            }
            else if (kartlar_ == "Kart7")
            {
                label2.Text = Kart7.kartadi;
                label12.Text = "" + Kart7.oncul1;
                label11.Text = "" + Kart7.oncul2;
                label10.Text = "" + Kart7.oncul3;
                label9.Text = "" + Kart7.oncul4;
                label8.Text = "" + Kart7.oncul5;
                tierlabel2.Text = "" + Kart7.tier;
                return;
            }
            else if (kartlar_ == "Kart8")
            {
                label2.Text = Kart8.kartadi;
                label12.Text = "" + Kart8.oncul1;
                label11.Text = "" + Kart8.oncul2;
                label10.Text = "" + Kart8.oncul3;
                label9.Text = "" + Kart8.oncul4;
                label8.Text = "" + Kart8.oncul5;
                tierlabel2.Text = "" + Kart8.tier;
                return;
            }
            else if (kartlar_ == "Kart9")
            {
                label2.Text = Kart9.kartadi;
                label12.Text = "" + Kart9.oncul1;
                label11.Text = "" + Kart9.oncul2;
                label10.Text = "" + Kart9.oncul3;
                label9.Text = "" + Kart9.oncul4;
                label8.Text = "" + Kart9.oncul5;
                tierlabel2.Text = "" + Kart9.tier;
                return;
            }
            else if (kartlar_ == "Kart10")
            {
                label2.Text = Kart10.kartadi;
                label12.Text = "" + Kart10.oncul1;
                label11.Text = "" + Kart10.oncul2;
                label10.Text = "" + Kart10.oncul3;
                label9.Text = "" + Kart10.oncul4;
                label8.Text = "" + Kart10.oncul5;
                tierlabel2.Text = "" + Kart10.tier;
                return;
            }
            
        }

        ///////// Bilgisayar Kart1 Eşleştirici ////////////

        public void BilgisayarKart1_Eşleştirici(string kartlar_)
        {


            //////// Picture Box 1 Eşleştirici ////////
            if (kartlar_ == "Kart1")
            {
                
                label17.Text = "" + Kart1.oncul1;
                label16.Text = "" + Kart1.oncul2;
                label15.Text = "" + Kart1.oncul3;
                label14.Text = "" + Kart1.oncul4;
                label13.Text = "" + Kart1.oncul5;
                tierlabel3.Text = "" + Kart1.tier;
                return;
            }
            else if (kartlar_ == "Kart2")
            {
                
                label17.Text = "" + Kart2.oncul1;
                label16.Text = "" + Kart2.oncul2;
                label15.Text = "" + Kart2.oncul3;
                label14.Text = "" + Kart2.oncul4;
                label13.Text = "" + Kart2.oncul5;
                tierlabel3.Text = "" + Kart2.tier;
                return;
            }
            else if (kartlar_ == "Kart3")
            {
                
                label17.Text = "" + Kart3.oncul1;
                label16.Text = "" + Kart3.oncul2;
                label15.Text = "" + Kart3.oncul3;
                label14.Text = "" + Kart3.oncul4;
                label13.Text = "" + Kart3.oncul5;
                tierlabel3.Text = "" + Kart3.tier;
                return;
            }
            else if (kartlar_ == "Kart4")
            {
                
                label17.Text = "" + Kart4.oncul1;
                label16.Text = "" + Kart4.oncul2;
                label15.Text = "" + Kart4.oncul3;
                label14.Text = "" + Kart4.oncul4;
                label13.Text = "" + Kart4.oncul5;
                tierlabel3.Text = "" + Kart4.tier;
                return;
            }
            else if (kartlar_ == "Kart5")
            {
                
                label17.Text = "" + Kart5.oncul1;
                label16.Text = "" + Kart5.oncul2;
                label15.Text = "" + Kart5.oncul3;
                label14.Text = "" + Kart5.oncul4;
                label13.Text = "" + Kart5.oncul5;
                tierlabel3.Text = "" + Kart5.tier;
                return;
            }
            else if (kartlar_ == "Kart6")
            {
                
                label17.Text = "" + Kart6.oncul1;
                label16.Text = "" + Kart6.oncul2;
                label15.Text = "" + Kart6.oncul3;
                label14.Text = "" + Kart6.oncul4;
                label13.Text = "" + Kart6.oncul5;
                tierlabel3.Text = "" + Kart6.tier;
                return;
            }
            else if (kartlar_ == "Kart7")
            {
                
                label17.Text = "" + Kart7.oncul1;
                label16.Text = "" + Kart7.oncul2;
                label15.Text = "" + Kart7.oncul3;
                label14.Text = "" + Kart7.oncul4;
                label13.Text = "" + Kart7.oncul5;
                tierlabel3.Text = "" + Kart7.tier;
                return;
            }
            else if (kartlar_ == "Kart8")
            {
                
                label17.Text = "" + Kart8.oncul1;
                label16.Text = "" + Kart8.oncul2;
                label15.Text = "" + Kart8.oncul3;
                label14.Text = "" + Kart8.oncul4;
                label13.Text = "" + Kart8.oncul5;
                tierlabel3.Text = "" + Kart8.tier;
                return;
            }
            else if (kartlar_ == "Kart9")
            {
                
                label17.Text = "" + Kart9.oncul1;
                label16.Text = "" + Kart9.oncul2;
                label15.Text = "" + Kart9.oncul3;
                label14.Text = "" + Kart9.oncul4;
                label13.Text = "" + Kart9.oncul5;
                tierlabel3.Text = "" + Kart9.tier;
                return;
            }
            else if (kartlar_ == "Kart10")
            {
                
                label17.Text = "" + Kart10.oncul1;
                label16.Text = "" + Kart10.oncul2;
                label15.Text = "" + Kart10.oncul3;
                label14.Text = "" + Kart10.oncul4;
                label13.Text = "" + Kart10.oncul5;
                tierlabel3.Text = "" + Kart10.tier;
                return;
            }
            
        }

        ///////// Bilgisayar Kart2 Eşleştirici ////////////

        public void BilgisayarKart2_Eşleştirici(string kartlar_)
        {


            //////// Picture Box 1 Eşleştirici ////////
            if (kartlar_ == "Kart1")
            {

                label22.Text = "" + Kart1.oncul1;
                label21.Text = "" + Kart1.oncul2;
                label20.Text = "" + Kart1.oncul3;
                label19.Text = "" + Kart1.oncul4;
                label18.Text = "" + Kart1.oncul5;
                tierlabel4.Text = "" + Kart1.tier;
                return;
            }
            else if (kartlar_ == "Kart2")
            {

                label22.Text = "" + Kart2.oncul1;
                label21.Text = "" + Kart2.oncul2;
                label20.Text = "" + Kart2.oncul3;
                label19.Text = "" + Kart2.oncul4;
                label18.Text = "" + Kart2.oncul5;
                tierlabel4.Text = "" + Kart2.tier;
                return;
            }
            else if (kartlar_ == "Kart3")
            {

                label22.Text = "" + Kart3.oncul1;
                label21.Text = "" + Kart3.oncul2;
                label20.Text = "" + Kart3.oncul3;
                label19.Text = "" + Kart3.oncul4;
                label18.Text = "" + Kart3.oncul5;
                tierlabel4.Text = "" + Kart3.tier;
                return;
            }
            else if (kartlar_ == "Kart4")
            {

                label22.Text = "" + Kart4.oncul1;
                label21.Text = "" + Kart4.oncul2;
                label20.Text = "" + Kart4.oncul3;
                label19.Text = "" + Kart4.oncul4;
                label18.Text = "" + Kart4.oncul5;
                tierlabel4.Text = "" + Kart4.tier;
                return;
            }
            else if (kartlar_ == "Kart5")
            {

                label22.Text = "" + Kart5.oncul1;
                label21.Text = "" + Kart5.oncul2;
                label20.Text = "" + Kart5.oncul3;
                label19.Text = "" + Kart5.oncul4;
                label18.Text = "" + Kart5.oncul5;
                tierlabel4.Text = "" + Kart5.tier;
                return;
            }
            else if (kartlar_ == "Kart6")
            {

                label22.Text = "" + Kart6.oncul1;
                label21.Text = "" + Kart6.oncul2;
                label20.Text = "" + Kart6.oncul3;
                label19.Text = "" + Kart6.oncul4;
                label18.Text = "" + Kart6.oncul5;
                tierlabel4.Text = "" + Kart6.tier;
                return;
            }
            else if (kartlar_ == "Kart7")
            {

                label22.Text = "" + Kart7.oncul1;
                label21.Text = "" + Kart7.oncul2;
                label20.Text = "" + Kart7.oncul3;
                label19.Text = "" + Kart7.oncul4;
                label18.Text = "" + Kart7.oncul5;
                tierlabel4.Text = "" + Kart7.tier;
                return;
            }
            else if (kartlar_ == "Kart8")
            {

                label22.Text = "" + Kart8.oncul1;
                label21.Text = "" + Kart8.oncul2;
                label20.Text = "" + Kart8.oncul3;
                label19.Text = "" + Kart8.oncul4;
                label18.Text = "" + Kart8.oncul5;
                tierlabel4.Text = "" + Kart8.tier;
                return;
            }
            else if (kartlar_ == "Kart9")
            {

                label22.Text = "" + Kart9.oncul1;
                label21.Text = "" + Kart9.oncul2;
                label20.Text = "" + Kart9.oncul3;
                label19.Text = "" + Kart9.oncul4;
                label18.Text = "" + Kart9.oncul5;
                tierlabel4.Text = "" + Kart9.tier;
                return;
            }
            else if (kartlar_ == "Kart10")
            {

                label22.Text = "" + Kart10.oncul1;
                label21.Text = "" + Kart10.oncul2;
                label20.Text = "" + Kart10.oncul3;
                label19.Text = "" + Kart10.oncul4;
                label18.Text = "" + Kart10.oncul5;
                tierlabel4.Text = "" + Kart10.tier;
                return;
            }
           
        }



        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                panel7.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible=false;
            label4.Visible=false;
            label5.Visible=false;
            label6.Visible=false;
            label7.Visible=false;
            panel7.Visible=false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (label3.Text!="")
            {
                panel8.Visible = true;
                label12.Visible = true;
                label11.Visible = true;
                label10.Visible = true;
                label9.Visible = true;
                label8.Visible = true;
            }          
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label12.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            panel8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");
            pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");
            pictureBox3.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");
            pictureBox4.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");
            pictureBox5.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");
            pictureBox6.Image = Image.FromFile(@"..\Kartlar\pcKartCover_default.png");            
            label1.Text = "";
            label2.Text = "";
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            kartlar = kartlar_yedek;
            label27.Text = "Oyun Modu: Belirlenmedi";
            label25.Text = "Oyuncu: 0";
            label26.Text = "Bilgisayar: 0";
            oyuncuskor = 0;
            bilgisayarskor = 0;
            oyun_oynanıyor = false;
            bilgisayarkart0_oynama = true;
            bilgisayarkart1_oynama = true;
            oyuncukart0_used = false;
            oyuncukart1_used = false;
            label29.Text = "";
            label3.Text = "";
            label41.Visible = false;
            label43.Visible = false;
            label42.Text = "";
            label40.Text = "";
            tierortaoyuncu.Text = "";
            tierortabilgisayar.Text = "";
            label23.Text = "";
            label24.Text = "";
            timer1.Stop();
            Kontrol_Zamanlayıcı = 0;
            panel2.BackColor = Color.Maroon;
            panel3.BackColor = Color.Maroon;
            label28.Text = "Kalan Kart Sayısı: "+kartlar.Length;

        }

        ushort Kontrol_Zamanlayıcı = 0;
        int cevap;
        int oyuncuskor,bilgisayarskor;

        private void button5_Click(object sender, EventArgs e)
        {
            Random rnd9 = new Random();
            int rasgele_index_eklenen1 = rnd9.Next(kartlar.Length);
            bilgisayar[0] = kartlar[rasgele_index_eklenen1];
            kartlar = kartlar.Except(new string[] { kartlar[rasgele_index_eklenen1] }).ToArray();
            pictureBox1.Image = Image.FromFile(@"..\Kartlar\pcKartCover.png");
            BilgisayarKart1_Eşleştirici(bilgisayar[0]);
            bilgisayarkart0_oynama = true;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random rnd10 = new Random();
            int rasgele_index_eklenen2 = rnd10.Next(kartlar.Length - 1);
            bilgisayar[1] = kartlar[rasgele_index_eklenen2];
            kartlar = kartlar.Except(new string[] { kartlar[rasgele_index_eklenen2] }).ToArray();
            pictureBox2.Image = Image.FromFile(@"..\Kartlar\pcKartCover.png");
            BilgisayarKart2_Eşleştirici(bilgisayar[1]);
            bilgisayarkart1_oynama = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Kontrol_Zamanlayıcı++;
            
            if (Kontrol_Zamanlayıcı==2)
            {
                if (SeçilenMod == "Öncül 1")
                {
                    cevap = Class1.oncul_kontrol(label23.Text,label24.Text);
                    if (cevap == 1)
                    {
                        oyuncuskor++;
                        panel2.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == -1)
                    {
                        bilgisayarskor++;
                        panel3.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == 0)
                    {
                        cevap = Class1.tier_kontrol(tierortaoyuncu.Text,tierortabilgisayar.Text);
                        if (cevap == 1)
                        {
                            oyuncuskor++;
                            panel2.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == -1)
                        {
                            bilgisayarskor++;
                            panel3.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == 0)
                        {
                            oyuncuskor++;
                            bilgisayarskor++;
                            panel2.BackColor = Color.OrangeRed;
                            panel3.BackColor = Color.OrangeRed;
                        }
                    }                   
                    
                    
                }
                else if (SeçilenMod == "Öncül 2")
                {
                    cevap = Class1.oncul_kontrol(label23.Text, label24.Text);
                    if (cevap == 1)
                    {
                        oyuncuskor++;
                        panel2.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == -1)
                    {
                        bilgisayarskor++;
                        panel3.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == 0)
                    {
                        cevap = Class1.tier_kontrol(tierortaoyuncu.Text, tierortabilgisayar.Text);
                        if (cevap == 1)
                        {
                            oyuncuskor++;
                            panel2.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == -1)
                        {
                            bilgisayarskor++;
                            panel3.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == 0)
                        {
                            oyuncuskor++;
                            bilgisayarskor++;
                            panel2.BackColor = Color.OrangeRed;
                            panel3.BackColor = Color.OrangeRed;
                        }
                    }
                    
                }
                else if (SeçilenMod == "Öncül 3")
                {
                    cevap = Class1.oncul_kontrol(label23.Text, label24.Text);
                    if (cevap == 1)
                    {
                        oyuncuskor++;
                        panel2.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == -1)
                    {
                        bilgisayarskor++;
                        panel3.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == 0)
                    {
                        cevap = Class1.tier_kontrol(tierortaoyuncu.Text, tierortabilgisayar.Text);
                        if (cevap == 1)
                        {
                            oyuncuskor++;
                            panel2.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == -1)
                        {
                            bilgisayarskor++;
                            panel3.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == 0)
                        {
                            oyuncuskor++;
                            bilgisayarskor++;
                            panel2.BackColor = Color.OrangeRed;
                            panel3.BackColor = Color.OrangeRed;
                        }
                    }
                    
                }
                else if (SeçilenMod == "Öncül 4")
                {
                    cevap = Class1.oncul_kontrol(label23.Text, label24.Text);
                    if (cevap == 1)
                    {
                        oyuncuskor++;
                        panel2.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == -1)
                    {
                        bilgisayarskor++;
                        panel3.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == 0)
                    {
                        cevap = Class1.tier_kontrol(tierortaoyuncu.Text, tierortabilgisayar.Text);
                        if (cevap == 1)
                        {
                            oyuncuskor++;
                            panel2.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == -1)
                        {
                            bilgisayarskor++;
                            panel3.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == 0)
                        {
                            oyuncuskor++;
                            bilgisayarskor++;
                            panel2.BackColor = Color.OrangeRed;
                            panel3.BackColor = Color.OrangeRed;
                        }
                    }
                    
                }
                else if (SeçilenMod == "Öncül 5")
                {
                    cevap = Class1.oncul_kontrol(label23.Text, label24.Text);
                    if (cevap == 1)
                    {
                        oyuncuskor++;
                        panel2.BackColor = Color.BlueViolet;
                    }
                    else if (cevap == -1)
                    {
                        bilgisayarskor++;
                        panel3.BackColor= Color.BlueViolet;
                    }
                    else if (cevap == 0)
                    {
                        cevap = Class1.tier_kontrol(tierortaoyuncu.Text, tierortabilgisayar.Text);
                        if (cevap == 1)
                        {
                            oyuncuskor++;
                            panel2.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == -1)
                        {
                            bilgisayarskor++;
                            panel3.BackColor = Color.BlueViolet;
                        }
                        else if (cevap == 0)
                        {
                            oyuncuskor++;
                            bilgisayarskor++;
                            panel2.BackColor = Color.OrangeRed;
                            panel3.BackColor = Color.OrangeRed;
                        }
                    }
                    
                }
                
                label25.Text = "Oyuncu: " + oyuncuskor;
                label26.Text = "Bilgisayar: " + bilgisayarskor;
                
            }
            if (Kontrol_Zamanlayıcı==3)
            {
                panel2.BackColor = Color.Maroon;
                panel3.BackColor = Color.Maroon;
            }
            if (Kontrol_Zamanlayıcı == 4)
            {
                Kontrol_Zamanlayıcı = 0;
                
                if (button3.Enabled==false && kartlar.Length!=0)
                {
                    Kart_Ekleyici(0);
                    button3.Enabled = true;
                   
                    
                }
                else if (button4.Enabled==false && kartlar.Length != 0)
                {
                    Kart_Ekleyici(1);
                    button4.Enabled = true;
                    
                    
                }
                
                
                if (oyuncukart0_used == true && oyuncukart1_used == true)
                {
                    if (oyuncuskor > bilgisayarskor && oyuncukart0_used == true && oyuncukart1_used == true)
                    {
                        timer1.Stop();
                        label29.Text = "KAZANDIN!!!";
                        button3.Enabled = false;
                        button4.Enabled = false;
                        oyun_oynanıyor = false;


                    }
                    else if (oyuncuskor < bilgisayarskor && oyuncukart0_used == true && oyuncukart1_used == true)
                    {
                        timer1.Stop();
                        label29.Text = "KAYBETTİN!!!";
                        button3.Enabled = false;
                        button4.Enabled = false;
                        oyun_oynanıyor = false;

                    }
                    else if (oyuncuskor == bilgisayarskor && oyuncukart0_used == true && oyuncukart1_used == true)
                    {
                        timer1.Stop();
                        label29.Text = "BERABERE!!!";
                        button3.Enabled = false;
                        button4.Enabled = false;
                        oyun_oynanıyor = false;
                        
                    }

                }
                timer1.Stop();
                oyun_oynanıyor = false;
            }
        }        
        public void Kart_Ekleyici(int z)
        {
            if (kartlar.Length > 0 && z==0)
            {
                Random rnd6 = new Random();
                int rasgele_index_eklenen = rnd6.Next(kartlar.Length);
                oyuncu[z] = kartlar[rasgele_index_eklenen];
                kartlar = kartlar.Except(new string[] { kartlar[rasgele_index_eklenen] }).ToArray();
                pictureBox3.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[z] + ".png");
                OyuncuKart1_Eşleştirici(oyuncu[z]);
                label28.Text = "Kalan Kart Sayısı: " + kartlar.Length.ToString();
                oyuncukart0_used = false;
                
                if (kartlar.Length > 0 && bilgisayarkart0_oynama == false)
                {
                    button5_Click(button5, new EventArgs());
                }
                else if (kartlar.Length > 0 && bilgisayarkart1_oynama == false)
                {
                    button6_Click(button6, new EventArgs());
                }


            }
            if (kartlar.Length > 0 && z == 1)
            {
                Random rnd7 = new Random();
                int rasgele_index_eklenen = rnd7.Next(kartlar.Length);
                oyuncu[z] = kartlar[rasgele_index_eklenen];
                kartlar = kartlar.Except(new string[] { kartlar[rasgele_index_eklenen] }).ToArray();
                label28.Text = "Kalan Kart Sayısı: " + kartlar.Length.ToString();
                pictureBox4.Image = Image.FromFile(@"..\Kartlar\" + oyuncu[z] + ".png");
                OyuncuKart2_Eşleştirici(oyuncu[z]);
                oyuncukart1_used = false;
                if (kartlar.Length > 0 && bilgisayarkart0_oynama == false)
                {
                    button5_Click(button5, new EventArgs());
                }
                else if (kartlar.Length > 0 && bilgisayarkart1_oynama == false)
                {
                    button6_Click(button6, new EventArgs());
                }


            }


            
            
        }
    }
    }




