using System.ComponentModel.DataAnnotations;

namespace BlazorWasmApp1.Shared.Models
{
    public class BadModelStateRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
