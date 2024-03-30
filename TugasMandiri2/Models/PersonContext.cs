using TugasMandiri2.Helpers;
using TugasMandiri2.Models;
using Npgsql;


namespace TugasMandiri2.Models
{
    public class PersonContext
    {
        private string __constr;
        private string __ErrorMsg;

        public PersonContext(string pConstr)
        {
            __constr = pConstr;
        }
        public List<Murid> ListMurid()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT id_murid, nama, alamat, email FROM users.murid;");
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
            return list1;

        }

        // CREATE //

        public void AddMurid(Murid murid)
        {
            string query = string.Format(@"INSERT INTO users.murid (nama, alamat, email) VALUES ('{0}', '{1}', '{2}');",
            murid.nama, murid.alamat, murid.email);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        // UPDATE //
        public void UpdateMurid(Murid murid)
        {
            string query = string.Format(@"UPDATE users.murid SET nama = '{0}', alamat = '{1}', email = '{2}' WHERE id_murid = {3};",
            murid.nama, murid.alamat, murid.email, murid.id_murid);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        // DELETE //

        public void DeleteMurid(int id)
        {
            string query = string.Format(@"DELETE FROM users.murid WHERE id_murid = {0};", id);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

    }
}
