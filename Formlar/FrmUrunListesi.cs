using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressTeknikServisUrunTakipSistemi.Formlar
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        void Listele()
        {
            // Listeleme(To List)
            var degerler = db.TBLURUN.ToList();                             // degerler degiskenine db nesnesi uzerinden erisim sagladigimiz TBLURUN tablosundaki urunleri ToList metodu ile listeleyip degiskenimize atama islemi yaptik.
            gCurunListe.DataSource = degerler;                              // gridControl de gozukmesi icin DataSource uzerinden urunleri listeledigimiz degiskenimizi atama islemi yaptik.
        }

        DbUrunTeknikServisEntities db = new DbUrunTeknikServisEntities();         // Projemize eklemiz oldugumuz model ile veritabanimizdaki tablolarla iletisim kuruyoruz. Modelimizin sinifindan db adinda bir nesne turetiyoruz.
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyati.Text);                // Decimal olarak tanimladigimiz degisken turumuzu string olarak alacamiyacagimiz icin donusum uygulamamiz gerekir.
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyati.Text);
            t.STOK = short.Parse(TxtStok.Text);
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaydedildi ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
