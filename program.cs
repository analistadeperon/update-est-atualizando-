// Botão de altualizar - teste novamente antes de usar .....
// update certo é assim: string inserir = "UPDATE contatos SET Nome='" + cadast.Nome_c + "',cpf='" + cadast.cpf + "',Email='" + cadast.email + "',cod_empresa='" + cadast.ncod_empresa + "',Celular='" + cadast.celular_c + "' WHERE Cd_contato = " + cadast.cd_contato;

private void Alterardadosempresa_Click(object sender, EventArgs e)
        {
            int indice = dataGridView1.CurrentRow.Index;
            string temporaria = dataGridView1[0, indice].Value.ToString();

            Contato fcc = new Contato(temporaria);
            fcc.ShowDialog();
        }

//metodo que faz a alteração
 public Contato(string Cd)
        {
            InitializeComponent();

            MySqlConnection conexao = new MySqlConnection();
            conexao = new MySqlConnection("SERVER=localhost;DATABASE=teste;UID=root;PASSWORD=;");

            string sql = "SELECT Cd_Contato,Nome,cpf,Email,cod_empresa,Celular FROM contatos where Cd_Contato ='" + Cd + "'";



            DataTable dtt = new DataTable();

            try
            {

                conexao.Open();
                if (conexao.State == ConnectionState.Open)
                {
                    objAdapter = new MySqlDataAdapter(sql, conexao);
                    objAdapter.Fill(dtt);

                    textBox7.Text = dtt.Rows[0]["Cd_Contato"].ToString();
                    textBox1.Text = dtt.Rows[0]["Nome"].ToString();
                    textBox2.Text = dtt.Rows[0]["cpf"].ToString();
                    textBox4.Text = dtt.Rows[0]["Email"].ToString();
                    textBox5.Text = dtt.Rows[0]["cod_empresa"].ToString();
                    textBox3.Text = dtt.Rows[0]["Celular"].ToString();


                    this.Text = "Alteração de dados";

                    button1.Visible = false;
                    button2.Visible = true;



                }
                else
                {
                    MessageBox.Show("Falha na  abertura da conexão", "Erro");
                }
            }
            catch
            {
                MessageBox.Show("Falha na leitura dos dados no banco", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

//classe que faz o update
   class atualizar_contato
    {


        private MySqlConnection conexao;

        public void cadastro(cadas_contato cadast)
        {
            string caminho = "SERVER=localhost;DATABASE=Agenda;UID=root;PASSWORD=;";

            try
            {

                conexao = new MySqlConnection(caminho);
                conexao.Open();

               

                string inserir = "UPDATE contatos SET Nome='" + cadast.Nome_c + "',cpf='" + cadast.cpf + "',Email='" + cadast.email + "',cod_empresa='" + cadast.ncod_empresa + "',Celular='" + cadast.celular_c + "'";


                MySqlCommand comandos = new MySqlCommand(inserir, conexao);

                comandos.ExecuteNonQuery();
                MessageBox.Show("Contato Atualizado com Sucesso!");
                conexao.Close();

            }

            catch (Exception ex)
            {

                throw new Exception("Erro de comandos" + ex.Message);
            }
        }
    }
