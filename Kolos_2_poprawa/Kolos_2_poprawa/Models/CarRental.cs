using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos_2_poprawa.Models;

[Table("car_rentals")]
public class CarRental
{
    [Key]
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int CarId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int TotalPrice { get; set; }
    public int? Discount { get; set; }
    
    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
    
    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; }
}