using System.ComponentModel.DataAnnotations;

public class Nombres
{
    [Key]
    public int NombreId { get; set; }
    [Required(ErrorMessage ="Es obligatorio")]
    public String? Descripcion { get; set; }
    [Range(1,1_000_000)]
    public double Salario { get; set; }
}