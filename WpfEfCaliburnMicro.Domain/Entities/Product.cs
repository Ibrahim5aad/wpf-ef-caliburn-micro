using System.ComponentModel.DataAnnotations;

namespace WpfEfCaliburnMicro.Domain.Entities
{
  public class Product
  {

    [Key]
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
  }
}
