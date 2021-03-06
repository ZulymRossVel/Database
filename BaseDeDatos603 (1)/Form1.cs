﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BaseDeDatos603
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "SELECT * FROM test";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " "+reader.GetString(3));
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);

                    }
                }
                else
                {
                    Console.WriteLine("There is not data, try again. :'v");
                }
                conectionDatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void GuardarUsuario()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "INSERT INTO test(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            
            try
            {
                conectionDatabase.Open();
                MySqlDataReader reader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("SUCCESFULY REGISTERED");
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void SearchUser()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "SELECT * FROM test where id= ('" + textBox4.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };

                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];
                    }
                }
                else
                {
                    Console.WriteLine("Here is your result, :D");
                }
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    private void MostrarUsuario()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "SELECT * FROM test";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var ListViewItems = new ListViewItem(row);
                        listView1.Items.Add(ListViewItems);
                    }

                }
                else
                {
                    Console.WriteLine("No DATA :c");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DropUser()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "DELETE * FROM test where id= ('" + textBox4.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;
            
            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                MessageBox.Show("Deleted data");
                DropUser();

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        conectionDatabase.Close();

                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];
                    }
                }
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void AddUser()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=Juanito1311;database=reader";
            string query = "SELECT * FROM test where id= ('" + textBox4.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            
            try
            {
                conectionDatabase.Open();
                MySqlDataReader reader = databaseCommand.ExecuteReader();
                MessageBox.Show("Updated data");
                AddUser();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };

                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }
                }
                else
                {
                    Console.WriteLine("Here is what you request for, :D");
                }
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {// Guardar Datos
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("There is NOT name");
            }
            else if (textBox2.Text == "")
            {
                //MessageBox.Show("There is NOT last name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("There is NOT address, COME ON");
            }
            else
            {

                GuardarUsuario();
                MostrarUsuario();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Actualizar
            MostrarUsuario();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
