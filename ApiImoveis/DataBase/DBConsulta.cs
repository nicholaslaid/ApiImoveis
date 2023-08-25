using Npgsql;
using ApiImoveis.Models;

namespace ApiImoveis.DataBase
{
    public class DBConsulta
    {
        public bool Add(Imoveis imoveis)
        {
            bool result = false;

            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO imoveis (id, cidade, bairro, tipo, valor, qtd_de_quartos, qtd_de_vagas, qtd_de_banheiros, qtd_de_salas) " +
                                      @"VALUES (@id, @cidade, @bairro, @tipo, @valor, @qtd_de_quartos, @qtd_de_vagas, @qtd_de_banheiros, @qtd_de_salas);";

                    cmd.Parameters.AddWithValue("@id", imoveis.id);
                    cmd.Parameters.AddWithValue("@cidade", imoveis.cidade);
                    cmd.Parameters.AddWithValue("@bairro", imoveis.bairro);
                    cmd.Parameters.AddWithValue("@valor", imoveis.value);
                    cmd.Parameters.AddWithValue("@tipo", imoveis.type);
                    cmd.Parameters.AddWithValue("@qtd_de_quartos", imoveis.qtd_de_quartos);
                    cmd.Parameters.AddWithValue("@qtd_de_vagas", imoveis.qtd_de_vagas);
                    cmd.Parameters.AddWithValue("@qtd_de_banheiros", imoveis.qtd_de_banheiros);
                    cmd.Parameters.AddWithValue("@qtd_de_salas", imoveis.qtd_de_salas);


                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                    }
                    result = true;
                }

            }
            catch
            { }
            return result;
        }


        public Imoveis GetCidade(string cidade)
        {

            Imoveis imoveis = new Imoveis();
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM imoveis " +
                                      @"WHERE cidade = LIKE '@cidade %';";

                    cmd.Parameters.AddWithValue("@cidade", cidade);

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imoveis.id = Convert.ToInt32(reader["id"]);
                            imoveis.cidade = reader["cidade"].ToString();
                            imoveis.bairro = reader["bairro"].ToString();
                            imoveis.type = reader["tipo"].ToString();
                            imoveis.value = float.Parse(reader["valor"].ToString());
                            imoveis.qtd_de_quartos = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_vagas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_banheiros = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_salas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            


                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return imoveis;
        }

        public Imoveis GetBairro(string bairro)
        {

            Imoveis imoveis = new Imoveis();
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM imoveis " +
                                      @"WHERE bairro = @bairro;";

                    cmd.Parameters.AddWithValue("@bairro", bairro);

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imoveis.id = Convert.ToInt32(reader["id"]);
                            imoveis.cidade = reader["cidade"].ToString();
                            imoveis.bairro = reader["bairro"].ToString();
                            imoveis.value = float.Parse(reader["valor"].ToString());
                            imoveis.qtd_de_quartos = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_vagas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_banheiros = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_salas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.type = reader["tipo"].ToString();


                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return imoveis;
        }

        public Imoveis GetTipo(string tipo)
        {

            Imoveis imoveis = new Imoveis();
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM imoveis " +
                                      @"WHERE tipo = @tipo;";

                    cmd.Parameters.AddWithValue("@tipo", tipo);

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imoveis.id = Convert.ToInt32(reader["id"]);
                            imoveis.cidade = reader["cidade"].ToString();
                            imoveis.bairro = reader["bairro"].ToString();
                            imoveis.value = float.Parse(reader["valor"].ToString());
                            imoveis.qtd_de_quartos = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_vagas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_banheiros = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_salas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.type = reader["tipo"].ToString();


                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return imoveis;
        }

        public List<Imoveis> GetAll()
        {
            List<Imoveis> result = new List<Imoveis>();
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT i.id, i.cidade, i.bairro, i.tipo, i.valor, i.qtd_de_quartos, i.qtd_de_vagas, i.qtd_de_banheiros, i.qtd_de_salas " +
                                      @"FROM imoveis i " +
                                      @"ORDER BY i.id;";

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Imoveis imoveis = new Imoveis();

                            imoveis.id = Convert.ToInt32(reader["id"]);
                            imoveis.cidade = reader["cidade"].ToString();
                            imoveis.bairro = reader["bairro"].ToString();
                            imoveis.value = float.Parse(reader["valor"].ToString());
                            imoveis.qtd_de_quartos = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_vagas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_banheiros = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.qtd_de_salas = Convert.ToInt32(reader["qtd_de_quartos"]);
                            imoveis.type = reader["tipo"].ToString();



                            result.Add(imoveis);

                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM imoveis " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }


        public bool Update(Imoveis imoveis)
        {
            bool result = false;
            DataBaseAccess dba = new DataBaseAccess();

            try
            {

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE imoveis " +
                                      @"SET id = @id, cidade = @cidade, bairro = @bairro, tipo = @tipo, valor = @valor, qtd_de_quartos = @qtd_de_quartos, qtd_de_vagas = @qtd_de_vagas, qtd_de_banheiros = @qtd_de_banheiros, qtd_de_salas = @qtd_de_salas  " +
                                      @"WHERE id = @id;";


                    cmd.Parameters.AddWithValue("@id", imoveis.id);
                    cmd.Parameters.AddWithValue("@cidade", imoveis.cidade);
                    cmd.Parameters.AddWithValue("@bairro", imoveis.bairro);
                    cmd.Parameters.AddWithValue("@valor", imoveis.value);
                    cmd.Parameters.AddWithValue("@tipo", imoveis.type);
                    cmd.Parameters.AddWithValue("@qtd_de_quartos", imoveis.qtd_de_quartos);
                    cmd.Parameters.AddWithValue("@qtd_de_vagas", imoveis.qtd_de_vagas);
                    cmd.Parameters.AddWithValue("@qtd_de_banheiros", imoveis.qtd_de_banheiros);
                    cmd.Parameters.AddWithValue("@qtd_de_salas", imoveis.qtd_de_salas);


                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            { }

            return result;
        }
    }
}
