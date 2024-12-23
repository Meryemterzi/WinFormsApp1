using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmOrderManagement : Form
    {
        public FrmOrderManagement()
        {
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool ValidateMüşteriID(int müşteriID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // MüşteriID'yi doğrulamak için sorgu
                string query = "SELECT COUNT(*) FROM public.\"Müşteriler\" WHERE \"MüşteriID\" = @MüşteriID;";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MüşteriID", müşteriID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0; // Eğer müşteri bulunursa true döner
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox'ların dolu olup olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Lütfen tüm kutuları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int müşteriID = 0;

                // TextBox'tan müşteri ID değerini al ve kontrol et
                if (!int.TryParse(textBox1.Text, out müşteriID))
                {
                    MessageBox.Show("Lütfen geçerli bir Müşteri ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // MüşteriID doğrulama
                if (!ValidateMüşteriID(müşteriID))
                {
                    MessageBox.Show("Geçersiz Müşteri ID! Lütfen doğru bir Müşteri ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // İstatistikleri güncelle (Trigger veritabanında otomatik olarak çalışacak)

                // Sipariş ekleme işlemleri buraya gelir
                MessageBox.Show("Müşteri ID doğrulandı! Sipariş eklenebilir.");
                

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Sipariş bilgilerini ekle
                string query = "INSERT INTO public.\"Siparişler\" (\"MüşteriID\", \"Tarih\", \"ToplamTutar\", \"Durum\") VALUES (@MüşteriID, @Tarih, @ToplamTutar, @Durum) RETURNING \"SiparişID\";";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MüşteriID", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(textBox2.Text)); // Tarih TextBox'tan alınır
                cmd.Parameters.AddWithValue("@ToplamTutar", Convert.ToDecimal(textBox6.Text));
                cmd.Parameters.AddWithValue("@Durum", textBox3.Text);

                int siparişID = Convert.ToInt32(cmd.ExecuteScalar());

         
                MessageBox.Show("Sipariş başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Satır seçilip seçilmediğini kontrol et
            {
                DialogResult result = MessageBox.Show("Seçili siparişi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        int siparişID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SiparişID"].Value);

                        // Sipariş detaylarını sil
                        string detayQuery = "DELETE FROM public.\"SiparişDetayları\" WHERE \"SiparişID\" = @SiparişID;";
                        using (NpgsqlCommand detayCmd = new NpgsqlCommand(detayQuery, conn))
                        {
                            detayCmd.Parameters.AddWithValue("@SiparişID", siparişID);
                            detayCmd.ExecuteNonQuery();
                        }

                        // Siparişi sil
                        string query = "DELETE FROM public.\"Siparişler\" WHERE \"SiparişID\" = @SiparişID;";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SiparişID", siparişID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Sipariş başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir sipariş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Satır seçilip seçilmediğini kontrol et
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                        string.IsNullOrWhiteSpace(textBox7.Text) ||
                        string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    int siparişID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SiparişID"].Value);

                    // Sipariş bilgilerini güncelle
                    string query = "UPDATE public.\"Siparişler\" SET \"Tarih\" = @Tarih, \"ToplamTutar\" = @ToplamTutar, \"Durum\" = @Durum WHERE \"SiparişID\" = @SiparişID;";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(textBox4.Text));
                        cmd.Parameters.AddWithValue("@ToplamTutar", Convert.ToDecimal(textBox7.Text));
                        cmd.Parameters.AddWithValue("@Durum", textBox5.Text);
                        cmd.Parameters.AddWithValue("@SiparişID", siparişID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Sipariş başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir sipariş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int selectedRowIndex = -1; // Başlangıçta geçersiz değer
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Geçerli bir satıra tıklanmışsa
            {
                selectedRowIndex = e.RowIndex; // Satır index'ini güncelle
                MessageBox.Show($"Seçilen satır: {selectedRowIndex}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT s.\"SiparişID\", s.\"MüşteriID\", s.\"Tarih\", s.\"ToplamTutar\", s.\"Durum\" FROM public.\"Siparişler\" s;";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show($"{dt.Rows.Count} adet sipariş listelendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hiç sipariş bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void FrmOrderManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tüm satırı seç
            dataGridView1.MultiSelect = false; // Birden fazla satır seçilmesini engelle
        }

        private bool ValidateSiparişID(int siparişID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT COUNT(*) FROM public.\"Siparişler\" WHERE \"SiparişID\" = @SiparişID";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SiparişID", siparişID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0; // Eğer sonuç varsa, true döner
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int siparişID = Convert.ToInt32(textBox8.Text);

                // SiparişID'nin geçerli olup olmadığını kontrol edin
                if (!ValidateSiparişID(siparişID))
                {
                    MessageBox.Show("Geçersiz Sipariş ID! Lütfen doğru bir Sipariş ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // İade talebini ekle
                string query = "INSERT INTO public.\"İadeTalepleri\" (\"SiparişID\", \"Tarih\", \"Durum\") " +
                               "VALUES (@SiparişID, @Tarih, @Durum);";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SiparişID", siparişID);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now); // Şu anki tarih
                cmd.Parameters.AddWithValue("@Durum", "İnceleniyor"); // Varsayılan durum

                cmd.ExecuteNonQuery();

                MessageBox.Show("İade talebi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanı bağlantısını aç
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // İstatistikler tablosunu sorgula
                string query = "SELECT \"Tarih\", \"SatışAdedi\", \"Gelir\" FROM public.\"İstatistikler\"";

                // DataAdapter ile sorguyu çalıştır ve DataTable'a doldur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show($"İstatistikler yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // PostgreSQL bağlantı dizesi
            NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");

            try
            {
                conn.Open();

                // Kullanıcıdan SiparişID al
                int orderId;
                if (!int.TryParse(textBox9.Text, out orderId))
                {
                    MessageBox.Show("Lütfen geçerli bir Sipariş ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // PostgreSQL fonksiyonunu çağır
                string query = "SELECT calculate_order_total(@order_id) AS ToplamTutar";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);

                    // Sonucu DataTable'a doldur
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView'e verileri bağla
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // PostgreSQL bağlantı dizesi
            NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");

            try
            {
                conn.Open();

                // Kullanıcıdan SiparişID al
                int orderId;
                if (!int.TryParse(textBox10.Text, out orderId))
                {
                    MessageBox.Show("Lütfen geçerli bir Sipariş ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // PostgreSQL fonksiyonunu çağır
                string query = "SELECT * FROM get_order_details(@order_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);

                    // Sonuçları DataTable'a doldur
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView'e verileri bağla
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 FORM1 = new Form1();
            FORM1.Show(); // Yeni formu açar
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapatır
        }
    }
}
