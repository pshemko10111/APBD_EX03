
using MySql.Data.MySqlClient;

namespace APBD_EX03;

public class AnimalDS : IAnimalDS
{
    private readonly string _connection = "Data source=localhost;Initial Catalog=Testowa;User Id=root;Password=1234";

    public void addAnimal(Animal animal)
    {
        using (var conn = new MySqlConnection(_connection))
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = ("INSERT INTO Animal VALUES" + "(@animalId,@Name,@Description,@Category,@Area)");
            command.Parameters.AddWithValue("@animalId", animal.IdAnimal);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

        }
    }

    public void deleteAnimal(string animalId)
    {
        using (var conn = new MySqlConnection(_connection))
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @animalId";
            command.Parameters.AddWithValue("@animalId", animalId);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }

    public List<Animal> GetAnimals(string orderBy)
    {
        if (orderBy == null || orderBy.Trim() == "" || orderBy.Equals("IdAnimal")) orderBy = "Name";
        
        var list = new List<Animal>();
        using (var conn = new MySqlConnection(_connection))
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM Animal ORDER BY " + orderBy;
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Animal()
                {
                    IdAnimal = int.Parse(reader["IdAnimal"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Category = reader["Category"].ToString(),
                    Area = reader["Area"].ToString()
                });
            }
            conn.Close();
            return list;
        }
    }

    public void updateAnimal(string animalId, Animal animal)
    {
        using (var conn = new MySqlConnection(_connection))
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "Update Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE idAnimal = @IdAnimal";

            command.Parameters.AddWithValue("@IdAnimal", animalId);
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Description", animal.Description);
            command.Parameters.AddWithValue("@Category", animal.Category);
            command.Parameters.AddWithValue("@Area", animal.Area);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();


        }
    }
}
