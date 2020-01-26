using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("coba1");

            //get mongodb collection
            var collection = database.GetCollection<BsonDocument>("koleksi1");
            /**
             * buatlah sebuah document JSON
             * */
            var documnt = new BsonDocument
            {
                {"Brand","Dell"},
                {"Price","400"},
                {"Ram","8GB"},
                {"HardDisk","1TB"},
                {"Screen","16inch"}
            };
            /**
             * menambah sebuah dokumen
             * */
            collection.InsertOneAsync(documnt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("coba1");

            var documnt = new BsonDocument
            {
                {comboBox1.Text, textBox1.Text}
            };
            //get mongodb collection
            var collection = database.GetCollection<BsonDocument>("siswa");

            var hasil = collection.Find(documnt).ToList();

            DataTable tbA = new DataTable();
            //    tbA.Columns.Add()
            int jmlkolom=0;
            for (int i = 0; i < hasil.Count; i++)
            {
                MessageBox.Show(hasil[0].ToString());
                dateTimePicker1.Value = hasil[0]["tgl"].AsDateTime;
                //if (jmlkolom < i + 1) jmlkolom = i + 1;
            }
            //for(int i=0;i<jmlkolom;i++)
            //    tbA.Columns

        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("coba1");

            //get mongodb collection
            var collection = database.GetCollection<BsonDocument>("siswa");
            /**
             * buatlah sebuah document JSON
             * */
            var documnt = new BsonDocument
            {
                {"nim",TxtNim.Text},
                {"nama", TxtNama.Text},
                {"alamat", TxtAlamat.Text},
                {"tgl", dateTimePicker1.Value}
            };
            /**
             * menambah sebuah dokumen
             * */
            collection.InsertOneAsync(documnt);
        }
    }
}
