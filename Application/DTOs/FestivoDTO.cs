
namespace Application.DTOs
{
    public class FestivoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int Dia { get; set; }

        public int Mes { get; set; }
        public int IdTipo { get; set; }
    }
}
