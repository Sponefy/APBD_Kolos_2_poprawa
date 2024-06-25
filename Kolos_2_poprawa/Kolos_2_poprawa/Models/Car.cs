using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos_2_poprawa.Models;

[Table("cars")]
public class Car
{
    [Key]
    public int Id { get; set; }
    [MaxLength(17)]
    public string VIN { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int Seats { get; set; }
    public int PricePerDay { get; set; }
    public int ModelId { get; set; }
    public int ColorId { get; set; }
    
    public ICollection<CarRental> rentals { get; set; }
    
    [ForeignKey(nameof(ModelId))]
    public Model Model { get; set; }
    
    [ForeignKey(nameof(ColorId))]
    public Color Color { get; set; }
}