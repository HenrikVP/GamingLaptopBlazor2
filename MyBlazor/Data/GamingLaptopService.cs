using System.Data.SqlClient;

namespace MyBlazor.Data
{
    public class GamingLaptopService
    {
        //Connection string shouldnt be public accessable
        private string conString = "Data Source=192.168.2.2;Initial Catalog=MyDB;User ID=sa;Password=Passw0rd;";

        public GamingLaptop ReadGamingLaptop()
        {
            //int id, string? name, string? brand, int rAM, string? gPU, string? cPU, float price)

            return new GamingLaptop(1, "Nitro 5", "Acer", 16, "Nvidia 1060 TI", "Intel i5 8600", 6000);
        }

        public List<GamingLaptop> ReadGamingLaptops(string query)
        {
            List<GamingLaptop> list = new();
            using (SqlConnection con = new(conString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GamingLaptop gamingLaptop = new();
                    gamingLaptop.Id = (int)reader[0];
                    gamingLaptop.Name = (string)reader[1];
                    gamingLaptop.Brand = (string)reader[2];
                    gamingLaptop.RAM = (int)reader[3];
                    gamingLaptop.GPU = (string)reader[4];
                    gamingLaptop.CPU = (string)reader[5];
                    gamingLaptop.Price = (double)reader[6];
                    list.Add(gamingLaptop);
                }
                con.Close();
            }
            return list;
        }

        public void CreateGamingLaptop(GamingLaptop gl)
        {
            using (SqlConnection con = new(conString))
            {
                string query = $"INSERT INTO GamingLaptop ([Name], Brand, RAM, GPU, CPU, Price) VALUES (@Name, @Brand, @RAM, @GPU, @CPU, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                if (gl.Name == null) gl.Name = "Name Not Set";
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = gl.Name;
                if (gl.Brand == null) gl.Brand = "Brand Not Set";
                cmd.Parameters.Add("@Brand", System.Data.SqlDbType.NVarChar).Value = gl.Brand;
                cmd.Parameters.Add("@RAM", System.Data.SqlDbType.Int).Value = gl.RAM;
                if (gl.GPU == null) gl.GPU = "GPU Not Set"; 
                cmd.Parameters.Add("@GPU", System.Data.SqlDbType.NVarChar).Value = gl.GPU;
                if (gl.CPU == null) gl.CPU = "CPU Not Set"; 
                cmd.Parameters.Add("@CPU", System.Data.SqlDbType.NVarChar).Value = gl.CPU;
                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = gl.Price;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteGamingLaptop(int id)
        {
            using (SqlConnection con = new(conString))
            {
                string query = $"DELETE FROM GamingLaptop WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateGamingLaptop(GamingLaptop gl)
        {
            using (SqlConnection con = new(conString))
            {
                //ToDo Set SET values in query
                string query = $"UPDATE GamingLaptop SET WHERE id = {gl.Id}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = gl.Id;
                if (gl.Name == null) gl.Name = "Name Not Set";
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = gl.Name;
                if (gl.Brand == null) gl.Brand = "Brand Not Set";
                cmd.Parameters.Add("@Brand", System.Data.SqlDbType.NVarChar).Value = gl.Brand;
                cmd.Parameters.Add("@RAM", System.Data.SqlDbType.Int).Value = gl.RAM;
                if (gl.GPU == null) gl.GPU = "GPU Not Set";
                cmd.Parameters.Add("@GPU", System.Data.SqlDbType.NVarChar).Value = gl.GPU;
                if (gl.CPU == null) gl.CPU = "CPU Not Set";
                cmd.Parameters.Add("@CPU", System.Data.SqlDbType.NVarChar).Value = gl.CPU;
                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = gl.Price;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
