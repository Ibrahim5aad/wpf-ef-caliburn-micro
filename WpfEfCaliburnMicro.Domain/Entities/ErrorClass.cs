using System.ComponentModel.DataAnnotations;

namespace WpfEfCaliburnMicro.Domain.Entities
{
  public class ErrorClassModel
  {

    [Key]
    public string ErrorClass { get; set; }


    public string ErrorClassDescription { get; set; }


    public int ErrorClassNumber { get; set; }

  }
}
