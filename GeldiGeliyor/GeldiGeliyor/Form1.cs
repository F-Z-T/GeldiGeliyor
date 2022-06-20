using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeldiGeliyor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Category> CatList = new List<Category>();
        Shipper[] ShipDizi = new Shipper[0];
        List<Product> ProList = new List<Product>();


        private void Form1_Load(object sender, EventArgs e)
        {

            #region AddCategory

            Category c1 = new Category();
            c1.CategoryName = "Teknoloji";
            c1.Description = "telefon,tablet";
            CatList.Add(c1);

            Category c2 = new Category();
            c2.CategoryName = "Spor";
            c2.Description = "sağlıklı yaşam için egzersiz";
            CatList.Add(c2);

            Category c3 = new Category();
            c3.CategoryName = "TKitap";
            c3.Description = "hayatınıza anlam katar";
            CatList.Add(c3);


            foreach (var item in CatList)
            {
                cmbKategori.Items.Add(item);

            }


            #endregion

            #region AddShiper

            Shipper s1 = new Shipper();
            s1.ShipperName = "Aras";
            s1.Phone = "0212 345 6789";
            s1.Region = "Marmara";
            s1.City = "Istanbul";
            s1.Address = "Hadimkoy";

            Array.Resize(ref ShipDizi, ShipDizi.Length + 1);
            ShipDizi[ShipDizi.Length - 1] = s1;

            Shipper s2 = new Shipper();
            s2.ShipperName = "UPS";
            s2.Phone = "0212 345 6781";
            s2.Region = "Anadolu";
            s2.City = "Ankara";
            s2.Address = "Kızılay";

            Array.Resize(ref ShipDizi, ShipDizi.Length + 1);
            ShipDizi[ShipDizi.Length - 1] = s2;


            Shipper s3 = new Shipper();
            s3.ShipperName = "Yurtiçi";
            s3.Phone = "0212 345 6783";
            s3.Region = "Ege";
            s3.City = "İzmir";
            s3.Address = "Buca";

            Array.Resize(ref ShipDizi, ShipDizi.Length + 1);
            ShipDizi[ShipDizi.Length - 1] = s3;

            foreach (Shipper item in ShipDizi)
            {
                foreach (var cont in this.Controls)
                {
                    if (cont is RadioButton)
                    {
                        RadioButton rdbShip = (RadioButton)cont;
                        if (rdbShip.Text == null || rdbShip.Text =="")
                        {
                            rdbShip.Text = item.ShipperName;
                            rdbShip.Tag = item; //Tag = object tutmamızı sağlıyor.
                            break;
                        }
                    }
                }
            }


            #endregion 


            #region AddProduct

            Product p1 = new Product();
            p1.ProductName = "PC";
            p1.Price = 10000;
            p1.Stock = 20;
            p1.Description = "Cok Pahalı";
            p1.Category = c1;
            ProList.Add(p1);

            Product p2 = new Product();
            p2.ProductName = "Uzuc Iphone";
            p2.Price = 200;
            p2.Stock = 12;
            p2.Description = "Her eve lazım";
            p2.Category = c1;
            ProList.Add(p2);


            Product p3 = new Product();
            p3.ProductName = "Basketball short";
            p3.Price = 600;
            p3.Stock = 23;
            p3.Description = "clima cool";
            p3.Category = c2;
            ProList.Add(p3);


            Product p4 = new Product();
            p4.ProductName = "Basketball socks";
            p4.Price = 200;
            p4.Stock = 34;
            p4.Description = "ter tutmaz";
            p4.Category = c2;
            ProList.Add(p4);


            Product p5 = new Product();
            p5.ProductName = "Harry Potter Felsefe taşı";
            p5.Price = 35;
            p5.Stock = 234;
            p5.Description = "fantastik kurgu";
            p5.Category = c3;
            ProList.Add(p5);


            Product p6 = new Product();
            p6.ProductName = "Seyehatname";
            p6.Price = 123;
            p6.Stock = 23;
            p6.Description = "evliya çelebi tarafından yazıldı";
            p6.Category = c3;
            ProList.Add(p6);


            #endregion

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeyazdir();

            Category secilenKategori = (Category)cmbKategori.SelectedItem;
            listView1.Items.Clear();
            foreach (Product item in ProList)
            {
                if (item.Category == secilenKategori)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = item.ProductName;
                    li.SubItems.Add(item.Price.ToString());
                    li.SubItems.Add(item.Stock.ToString());
                    li.Tag = item;
                    listView1.Items.Add(li);

                }
            }
        }
        private void listeyazdir()
        {
            Category secilenCategory = (Category)cmbKategori.SelectedItem;
            listView1.Items.Clear();
            foreach (Product item in ProList)
            {
                if (item.Category == secilenCategory)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = item.ProductName;
                    li.SubItems.Add(item.Price.ToString());
                    li.SubItems.Add(item.Stock.ToString());
                    li.Tag = item;
                    listView1.Items.Add(li);
                }
            }
        }





        ListView.SelectedListViewItemCollection secilenElemanlar;
        List<Product> secilenUrunler = new List<Product>();

        private void button1_Click(object sender, EventArgs e)
        {
            secilenElemanlar = listView1.SelectedItems;
            foreach (ListViewItem item in secilenElemanlar)
            {
                Product secilenUrun = (Product) item.Tag;
                secilenUrunler.Add(secilenUrun);
                lstSepet.Items.Add(secilenUrun);
            }

            


        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            int check = 0;
            RadioButton rdbbtn = new RadioButton();
            foreach (Control item in this.Controls)
            {
                if (item is RadioButton)
                {
                    rdbbtn = (RadioButton)item;
                    if (rdbbtn.Checked == true)
                    {
                        check++;
                        break;

                    }
                }
            }

            if ((check == 0) || (secilenElemanlar == null))
            {
                MessageBox.Show("Lütfen Kargo veya urun seciniz.");
            }
            else
            {
                Customer MyMusteri = new Customer();
                MyMusteri.Firstname = "Fatma";
                MyMusteri.LastName = "Turhan";

                Order ord = new Order();
                ord.OrderName = Guid.NewGuid().ToString(); //Guid = Pc'deki tarihe göre random değer üretirr.
                ord.Product = secilenUrunler;
                ord.orderData = DateTime.Now;
                ord.shipper = (Shipper)rdbbtn.Tag;
                ord.Customer = MyMusteri;


                foreach (Product item in secilenUrunler)
                {
                    item.Stock--;
                    listeyazdir();
                }

                

                Form2 frm2 = new Form2(ord);
                frm2.ShowDialog(); 

              

            }
        }


    }
}