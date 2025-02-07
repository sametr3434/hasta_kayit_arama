using System.Data.SQLite;

namespace hasta_kayıt_arama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlite = "Data source=C:\\Users\\uneri\\OneDrive\\Masaüstü\\kodlar\\SQLiteProjeler\\sqlite4.db;version=3;";
            using var baglan = new SQLiteConnection(sqlite);//baglantı oluştu
            {
                //try
                //{
                //    baglan.Open();
                //    MessageBox.Show("baglandı");
                //}
                //catch (Exception hata)
                //{

                //    MessageBox.Show(hata.Message);
                //}
                string ID = textBox5.Text;
                using (var komut = new SQLiteCommand($"SELECT * FROM hasta_kayıt WHERE ID={ID}", baglan))//sonuna baglan diyoruz cünkü nereden ne kullanını bilmesi lazım
                {
                    try
                    {
                        komut.Connection.Open(); // bağlantıyı açmak lazım
                        SQLiteDataReader veri = komut.ExecuteReader();
                        if (veri.Read())
                        {
                            textBox1.Text = veri["ad"].ToString();
                            textBox2.Text = veri["soyad"].ToString();
                            textBox3.Text = veri["TC"].ToString();
                            textBox4.Text = veri["adres"].ToString();
                        }

                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show(hata.Message);
                        Console.WriteLine(hata.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox5.Text;
            // yol ,baglantı , işlem yaptır silme olacak.
            string yol = "Data Source=C:\\Users\\uneri\\OneDrive\\Masaüstü\\kodlar\\SQLiteProjeler\\sqlite4.db;Version=3;";
            
            using var baglan = new SQLiteConnection(yol);
            
            using (var komut = new SQLiteCommand($"DELETE FROM hasta_kayıt WHERE ID={a}", baglan))
            { komut.Connection.Open();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
