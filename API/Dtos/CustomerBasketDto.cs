using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public int Id { get; set; }
        public List<BasketItemDto> Items { get; set; }

    }
}