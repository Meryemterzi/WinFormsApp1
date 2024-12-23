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
    public partial class FrmProductManagement : Form
    {
        public FrmProductManagement()
        {
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0) // Geçerli bir satır seçilmişse
            {
                DialogResult result = MessageBox.Show(
                    "Seçilen satırı silmek istediğinize emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Bağlantı zaten açık mı kontrol et
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        // Seçilen satırdaki ÜrünID değerini al
                        int urunID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                        // Silme sorgusu
                        string sorgu = "DELETE FROM public.\"Ürünler\" WHERE \"ÜrünID\" = @p1";
                        using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                        {
                            command.Parameters.AddWithValue("@p1", urunID);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Seçilen satır başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Bağlantıyı açık ise kapat
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Bağlantıyı aç
                    conn.Open();

                    // TextBox'ların boş olup olmadığını kontrol et
                    if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
                    {
                        MessageBox.Show("Lütfen tüm kutuları doldurun", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // SQL INSERT sorgusu hazırlığı
                        NpgsqlCommand command1 = new NpgsqlCommand(
                            "INSERT INTO \"Ürünler\"(\"ÜrünAdı\", \"KategoriID\", \"Fiyat\", \"StokMiktarı\") VALUES (@p1, @p2, @p3, @p4)", conn);

                        // Parametreleri ekle
                        command1.Parameters.AddWithValue("@p1", textBox1.Text); // ÜrünAdı
                        command1.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text)); // KategoriID
                        command1.Parameters.AddWithValue("@p3", Convert.ToDecimal(textBox3.Text)); // Fiyat
                        command1.Parameters.AddWithValue("@p4", Convert.ToInt16(textBox4.Text)); // StokMiktarı

                        // Sorguyu çalıştır
                        command1.ExecuteNonQuery();

                        // Başarı mesajı göster
                        MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajını göster
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Bağlantıyı kapat
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Bağlantı başarılı!"); // Bağlantı kontrolü

                string sorgu = "SELECT\r\n" +
                    "\"Ürünler\".\"ÜrünID\", \"Ürünler\".\"ÜrünAdı\" AS \"Ürün Adı\",\r\n" +
                    "\"Kategoriler\".\"KategoriAdı\" AS \"Kategori Adı\",\r\n" +
                    "\"Ürünler\".\"Fiyat\",\r\n" +
                    "\"Ürünler\".\"StokMiktarı\"\r\n" +
                    "FROM \"Ürünler\"\r\n" +
                    "JOIN \"Kategoriler\" ON \"Ürünler\".\"KategoriID\" = \"Kategoriler\".\"KategoriID\"\r\n" +
                    "ORDER BY \"ÜrünID\" ASC";

                // Veriyi doldurmak için DataAdapter ve DataSet kullanıyoruz
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0) // Veri kontrolü
                {
                    MessageBox.Show($"{ds.Tables[0].Rows.Count} kayıt bulundu."); // Satır sayısını göster
                    dataGridView1.AutoGenerateColumns = true; // Sütunları otomatik oluştur
                    dataGridView1.DataSource = ds.Tables[0]; // Veri kaynağını bağla
                }
                else
                {
                    MessageBox.Show("Hiç kayıt bulunamadı."); // Boş tablo durumu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}"); // Hata mesajı
            }
            finally
            {
                conn.Close(); // Bağlantıyı kapat
            }
        }

        private void CheckCriticalStockLogs()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Stok sıfıra düşen logları sorgula
                string query = "SELECT \"ÜrünID\", \"Mesaj\", \"Tarih\" FROM public.\"StokLog\" WHERE \"Mesaj\" LIKE '%sıfıra düştü%' ORDER BY \"Tarih\" DESC;";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                // Eğer log varsa kullanıcıya göster
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ürünID = reader.GetInt32(0); // ÜrünID
                        string mesaj = reader.GetString(1); // Mesaj
                        DateTime tarih = reader.GetDateTime(2); // Tarih

                        // Kullanıcıya bilgi göster
                        MessageBox.Show($"Ürün ID: {ürünID}\nMesaj: {mesaj}\nTarih: {tarih}", "Kritik Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Kritik stok seviyesiyle ilgili bir log bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close(); // Reader'ı kapat
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


        private void button3_Click(object sender, EventArgs e)
        {
            // Satır seçilip seçilmediğini kontrol et
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bağlantıyı kontrol et ve aç
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Seçilen satırdaki ÜrünID değerini al
                int urunID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                // Güncelleme sorgusu
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(
                    "UPDATE public.\"Ürünler\" SET\r\n" +
                    "\"ÜrünAdı\" = @p1,\r\n" +
                    "\"Fiyat\" = @p2,\r\n" +
                    "\"StokMiktarı\" = @p3\r\n" +
                    "WHERE \"ÜrünID\" = @p4", conn);

                // Parametreler
                npgsqlCommand.Parameters.AddWithValue("@p1", textBox5.Text); // ÜrünAdı
                npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox6.Text)); // Fiyat
                npgsqlCommand.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox7.Text)); // StokMiktarı
                npgsqlCommand.Parameters.AddWithValue("@p4", urunID); // ÜrünID

                // Sorguyu çalıştır
                npgsqlCommand.ExecuteNonQuery();

                // Güncelleme başarı mesajı
                MessageBox.Show("Ürün başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Trigger tarafından eklenen logları kontrol et
                CheckCriticalStockLogs();
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private int selectedRowIndex = -1; // Başlangıçta geçersiz değer

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Geçerli bir satıra tıklanmışsa
            {
                selectedRowIndex = e.RowIndex; // Satır index'ini güncelle
                MessageBox.Show($"Seçilen satır: {selectedRowIndex}");
            }
        }

        private void FrmProductManagement_Load(object sender, EventArgs e)
        {
            // DataGridView'de tüm satırı seçmek için ayarlar
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tüm satırı seç
            dataGridView1.MultiSelect = false; // Birden fazla satır seçilmesini engelle
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Fonksiyon çağrısı
                string query = "SELECT * FROM get_top_selling_products(@start_date, @end_date)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@start_date", NpgsqlTypes.NpgsqlDbType.Date, DateTime.Parse("2024-01-01"));
                    cmd.Parameters.AddWithValue("@end_date", NpgsqlTypes.NpgsqlDbType.Date, DateTime.Parse("2024-12-31"));

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
                // Bağlantıyı kapat
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // PostgreSQL bağlantı dizesi
            NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SirketDB; user Id=postgres;password=12345");

            try
            {
                conn.Open();

                // Kullanıcıdan kategori ID'sini al
                int categoryId;
                if (!int.TryParse(textBox8.Text, out categoryId))
                {
                    MessageBox.Show("Lütfen geçerli bir kategori ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // PostgreSQL fonksiyonunu çağır
                string query = "SELECT * FROM get_products_by_category(@category_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@category_id", categoryId);

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 FORM1 = new Form1();
            FORM1.Show(); // Yeni formu açar
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapatır
        }
    }

}

