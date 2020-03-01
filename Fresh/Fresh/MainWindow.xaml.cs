using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using System.Data;


namespace Fresh
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class MyTable
    {
        public MyTable(int id_goods,int height, int deph,int widh,int packing_count,int goods_life,bool in_stock,string name)
        {
            this.ID_goods = id_goods;
            this.Height = height;
            this.Deph = deph;
            this.Widh = widh;
            this.Packing_count = packing_count;
            this.Goods_life = goods_life;
            this.In_stock = in_stock;
            this.Name = name;
        }
        public int ID_goods { get; set; }
        public int Height { get; set; }
        public int Deph { get; set; }
        public int Widh { get; set; }
        public int Packing_count { get; set; }
        public int Goods_life { get; set; }
        public bool In_stock { get; set; }
        public string Name { get; set; }

    }
    public class goods
    {
        public goods(int deph_goods, int width_goods, int count_goods)
        {
            this.Deph_goods = deph_goods;
            this.Width_goods = width_goods;
            this.Count_goods = count_goods;
        }
        public int Deph_goods { get; set; }
        public int Width_goods { get; set; }
        public int Count_goods { get; set; }
    }
    public class shelf
    {
        public shelf(int height_shelf, int width_shelf, int deph_shelf)
        {
            this.Deph_shelf = deph_shelf;
            this.Width_shelf = width_shelf;
            this.Height_shelf = height_shelf;
        }
        public int Deph_shelf { get; set; }
        public int Width_shelf { get; set; }
        public int Height_shelf { get; set; }
    }
    public class packing_goods
    {
        public packing_goods(int deph_goods, int width_goods, int packing_goods)
        {
            this.Deph_goods = deph_goods;
            this.Width_goods = width_goods;
            this.Packing_goods = packing_goods;
        }
        public int Deph_goods { get; set; }
        public int Width_goods { get; set; }
        public int Packing_goods { get; set; }
    }
    public partial class MainWindow : Window
    {
        public string select;
        int DEPH_shelf = 0;
        int WIDH_shelf = 0;
        int deph_shelf = 0;
        int widh_shelf = 0;
        int COUNT_goods = 0;
        List<goods> list = new List<goods>();
        List<packing_goods> packing_list = new List<packing_goods>();
        List<packing_goods> new_goods = new List<packing_goods>();
        List<shelf> shelfes = new List<shelf>();
        public MainWindow()
        {
            InitializeComponent();
            List<goods> list = new List<goods>();
            List<packing_goods> packing_list = new List<packing_goods>();
            List<packing_goods> new_goods = new List<packing_goods>();
        }

        public void DataBase ()
        {
            int id1, id2,id3,id4,id5,id6;
            bool id7;
            string id8;
            NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123654;Database=Shop");
            NpgsqlCommand com = new NpgsqlCommand(select, con);
            con.Open();
            NpgsqlDataReader reader ;
            reader = com.ExecuteReader();
            List<MyTable> list = new List<MyTable>();
            while (reader.Read())
            {
                id1 = Convert.ToInt32(reader.GetValue(0));
                id2 = Convert.ToInt32(reader.GetValue(1));
                id3 = Convert.ToInt32(reader.GetValue(2));
                id4 = Convert.ToInt32(reader.GetValue(3));
                id5 = Convert.ToInt32(reader.GetValue(4));
                id6 = Convert.ToInt32(reader.GetValue(5));
                id8 = reader.GetValue(7).ToString();
                id7= Convert.ToBoolean(reader.GetValue(6));

                list.Add(new MyTable(id1, id2,id3,id4,id5,id6,id7,id8));

            }
            con.Close();
            select = null;
            goodsGrid.ItemsSource = list ;
        
        }

        private void MyButton4_Click(object sender, RoutedEventArgs e)
        {

            select = "select deph,widh,count_goods from goods,shipment,goods_shelf where goods.id_goods = shipment.id_goods and goods.id_goods = goods_shelf.id_goods and id_shelf = 1";
            AutoMethod();
            //Goods goods = new Goods();
            //goods.Show();
            //this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Goods goods = new Goods();
            goods.Show();
            this.Close();
        }
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            
            if(tvItem.Header.ToString() == "Полка 1")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 1";
                DataBase();
            }
            else if (tvItem.Header.ToString() == "Полка 2")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 2";
                DataBase();
            }
            else if (tvItem.Header.ToString() == "Полка 3")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 3";
                DataBase();
            }
        }
        private void TreeViewItem_Selected2(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            if (tvItem.Header.ToString() == "Полка 1")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 4";
                DataBase();
            }
            else if (tvItem.Header.ToString() == "Полка 2")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 5";
                DataBase();
            }
        }
        private void TreeViewItem_Selected3(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            if (tvItem.Header.ToString() == "Полка 1")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 6";
                DataBase();
            }
            else if (tvItem.Header.ToString() == "Полка 2")
            {
                select = "select * from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf = 7";
                DataBase();
            }
        }
        public void AutoMethod()
        {
            list.Clear();
            packing_list.Clear();
            shelfes.Clear();
            new_goods.Clear();
            int id1, id2, id3;
            int id4, id5, id6;
            int id7, id8, id9;
            NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123654;Database=Shop");
            NpgsqlCommand com = new NpgsqlCommand("select distinct deph, widh, count_goods from goods, shipment, goods_shelf where goods.id_goods = shipment.id_goods and goods.id_goods = goods_shelf.id_goods and id_shelf = 7;", con);
            con.Open();
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                id1 = Convert.ToInt32(reader.GetValue(0));
                id2 = Convert.ToInt32(reader.GetValue(1));
                id3 = Convert.ToInt32(reader.GetValue(2));

                list.Add(new goods(id1, id2, id3));

            }
            con.Close();

            com = new NpgsqlCommand("select distinct deph,widh,packing_count from goods,goods_shelf where goods.id_goods = goods_shelf.id_goods and id_shelf =7; ", con);
            con.Open();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                id4 = Convert.ToInt32(reader.GetValue(0));
                id5 = Convert.ToInt32(reader.GetValue(1));
                id6 = Convert.ToInt32(reader.GetValue(2));

                packing_list.Add(new packing_goods(id4, id5, id6));

            }
            con.Close();

            com = new NpgsqlCommand("select deph, widh,height from shelf where id_shelf = 7", con);
            con.Open();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                id7 = Convert.ToInt32(reader.GetValue(0));
                id8 = Convert.ToInt32(reader.GetValue(1));
                id9 = Convert.ToInt32(reader.GetValue(2));

                shelfes.Add(new shelf(id9, id8, id7));

            }
            con.Close();
            widh_shelf = shelfes[0].Width_shelf;
            deph_shelf = shelfes[0].Deph_shelf;
            //box.Text = list.Count.ToString();
            for (int i = 0; i < list.Count; i++)
            {
                DEPH_shelf = list[i].Deph_goods * list[i].Count_goods;
                WIDH_shelf += list[i].Width_goods;

                while (DEPH_shelf >= deph_shelf)
                {
                    DEPH_shelf -= deph_shelf;
                    WIDH_shelf += list[i].Width_goods;
                }
            }
            widh_shelf -= WIDH_shelf;

           for (int i = 0; i < packing_list.Count; i++)
                {
                    WIDH_shelf = 0;
                    DEPH_shelf = 0;
                    if (widh_shelf >= packing_list[i].Width_goods)
                    {

                        DEPH_shelf = packing_list[i].Packing_goods * packing_list[i].Deph_goods;
                        WIDH_shelf = widh_shelf;
                        while (DEPH_shelf > deph_shelf)
                        {
                            DEPH_shelf -= packing_list[i].Deph_goods;
                            WIDH_shelf -= packing_list[i].Width_goods;
                            COUNT_goods += packing_list[i].Packing_goods;
                        }
                        if (widh_shelf >= 0)
                        {
                            new_goods.Add(new packing_goods(packing_list[i].Deph_goods, packing_list[i].Width_goods, COUNT_goods));
                            COUNT_goods = 0;
                            widh_shelf -= packing_list[i].Width_goods;
                        }
                    }
                }
                goodsGrid.ItemsSource = new_goods;
            }
        

            int Height, Deph, Widh, Packing_count, Goods_life;
            string Name;
            public void NewGood(int height, int deph, int widh, int packing_count, int goods_life, string name)
            {

                Height = height;
                Deph = deph;
                Widh = widh;
                Packing_count = packing_count;
                Goods_life = goods_life;
                Name = name;

                Add_Method();
            }
            public void Add_Method()
            {
            int id1, id2, id3;
            int id4, id5, id6;
            int id7, id8, id9;
            NpgsqlConnection con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123654;Database=Shop");
                NpgsqlCommand com = new NpgsqlCommand("select deph, widh, count_goods from goods, shipment, goods_shelf where goods.id_goods = shipment.id_goods and goods.id_goods = goods_shelf.id_goods and id_shelf = 1", con);
                con.Open();
                NpgsqlDataReader reader;
                reader = com.ExecuteReader();
                List<goods> list = new List<goods>();
                List<packing_goods> packing_list = new List<packing_goods>();
                List<packing_goods> new_goods = new List<packing_goods>();
                List<shelf> shelfes = new List<shelf>();
                while (reader.Read())
                {
                    id1 = Convert.ToInt32(reader.GetValue(0));
                    id2 = Convert.ToInt32(reader.GetValue(1));
                    id3 = Convert.ToInt32(reader.GetValue(2));

                    list.Add(new goods(id1, id2, id3));

                }
                con.Close();

                com = new NpgsqlCommand("select deph, widh,height from shelf where id_shelf = 1", con);
                con.Open();
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id4 = Convert.ToInt32(reader.GetValue(0));
                    id5 = Convert.ToInt32(reader.GetValue(1));
                    id6 = Convert.ToInt32(reader.GetValue(2));

                    shelfes.Add(new shelf(id4, id5, id6));

                }
                con.Close();


                int DEPH_shelf = 0;
                int WIDH_shelf = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    DEPH_shelf = 0;
                    WIDH_shelf += list[i].Width_goods;

                    for (int j = 0; j < list[i].Count_goods; j++)
                    {
                        DEPH_shelf += list[i].Deph_goods;
                        if (DEPH_shelf >= deph_shelf)
                        {
                            DEPH_shelf = 0;
                            WIDH_shelf += list[i].Width_goods;
                        }
                    }
                }
            widh_shelf = shelfes[0].Width_shelf;
            widh_shelf -= WIDH_shelf;

                DEPH_shelf = 0;
                WIDH_shelf = 0;
                int COUNT_goods = 0;

                bool t = true;

                List<MyTable> new_list = new List<MyTable>();
                new_list.Add(new MyTable(55, Height, Deph, Widh, Packing_count, Goods_life, t, Name));

                for (int i = 0; i < new_list.Count; i++)
                {
                    WIDH_shelf = 0;
                    DEPH_shelf = 0;
                    if (widh_shelf >= new_list[i].Widh)
                    {
                        WIDH_shelf = widh_shelf;
                        DEPH_shelf = new_list[i].Deph * new_list[i].Packing_count;

                        while (DEPH_shelf > deph_shelf)
                        {
                            DEPH_shelf -= new_list[i].Deph;
                            WIDH_shelf -= new_list[i].Widh;
                            COUNT_goods += new_list[i].Packing_count;
                            if (WIDH_shelf >= 0)
                            {
                                goodsGrid.ItemsSource = new_list;
                                COUNT_goods = 0;
                            }
                        }

                    }
                }

            }
        }
    }
