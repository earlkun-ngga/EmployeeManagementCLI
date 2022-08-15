using MySql.Data.MySqlClient;
using System;


namespace EmployeeManagementCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string opt;
            //DB CONFIG
            DBHelper dbHelper = new DBHelper();
            string dbConfig = "server=localhost;user=root;database=csharptestdb;password=";
            MySqlConnection conn = new MySqlConnection(dbConfig);


            Console.WriteLine("APLIKASI MANAGEMENT KARYAWAN 1.0");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Daftar Semua Karyawan ");
            Console.WriteLine("2. Input Karyawan Baru");
            Console.WriteLine("3. Hapus Karyawan ");
            Console.WriteLine("4. Informasi Aplikasi ");
            Console.WriteLine("-------------------------");
            Console.Write("Pilihan Mu : ");

            opt = Console.ReadLine();

            
            
            

           if (opt == "1")
            {
                Console.Clear();
                Console.WriteLine("Daftar Karyawan");
                Console.WriteLine("--------------------");
                Console.WriteLine();
                //SHOW ALL EMPLOYEE
                dbHelper.readAllEmployee(conn);
                Console.ReadLine();
            } else if(opt == "2")
            {
                string namaKaryawan;
                string umurKaryawan;
                string jenisKelaminKaryawan;

                Console.Clear();
                Console.Clear();
                Console.WriteLine("Input Karyawan Baru");
                Console.WriteLine("--------------------");

                //FORM INPUT
                Console.Write("Nama Karyawan : ");
                namaKaryawan = Console.ReadLine();
                Console.Write("Umur Karyawan : ");
                umurKaryawan = Console.ReadLine();
                Console.Write("Jenis Kelamin Karyawan : ");
                jenisKelaminKaryawan = Console.ReadLine();

                dbHelper.insertNewEmployee(conn, namaKaryawan, umurKaryawan, jenisKelaminKaryawan);
                Console.ReadLine();

            }else if(opt == "3")
            {
                string idKaryawan;

                Console.Clear();
                Console.WriteLine("Hapus 1 Karyawan");
                Console.WriteLine("Silahkan pilih ID Karyawan (Jangan Salah ID) : ");
                idKaryawan = Console.ReadLine();
                dbHelper.deleteOneEmployee(conn, idKaryawan);
                Console.ReadLine();
            } else if(opt == "4")
            {
                Console.Clear();
                Console.WriteLine("APLIKASI MANAGEMENT KARYAWAN 1.0");
                Console.WriteLine("================================");
                Console.WriteLine("Versi : 1.0 (Alpha)");
                Console.WriteLine("Release Date : 15 Agustus 2022");
                Console.WriteLine("Dev : Earl Angga");
            }

               





        }
    }


    class DBHelper
    {
        public void readAllEmployee(MySqlConnection con)
        {
            try
            {
                con.Open();

                //TRY FECTH SOME DATA FROM DATABASE / TABLE
                string sql = "SELECT * FROM csharptestdb.employee";
                MySqlCommand cmdSql = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmdSql.ExecuteReader();
                Console.WriteLine("NO --- NAMA --- UMUR --- JENIS KELAMIN");
                Console.WriteLine("--------------------------------------");
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " --- " + rdr[1] + " --- " + rdr[2] + " --- " + rdr[3]);
                }
                rdr.Close();

                //CLOSE CONNECTION
                con.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

        }


        public void insertNewEmployee(MySqlConnection con, string namaKaryawan,string umurKaryawan,string jenisKelaminKaryawan)
        {
            con.Open();

            string sql = $"INSERT INTO csharptestdb.employee VALUES ('', '{namaKaryawan}', '{umurKaryawan}', '{jenisKelaminKaryawan}')";
            MySqlCommand cmdSql = new MySqlCommand(sql, con);
            cmdSql.ExecuteNonQuery();

            con.Close();
        }


        public void deleteOneEmployee(MySqlConnection con, string idKaryawan)
        {
            con.Open();

            string sql = $"DELETE FROM csharptestdb.employee WHERE id = '{idKaryawan}'";
            MySqlCommand cmdSql = new MySqlCommand(sql, con);
            cmdSql.ExecuteNonQuery();
            con.Close();
        }
    }
}