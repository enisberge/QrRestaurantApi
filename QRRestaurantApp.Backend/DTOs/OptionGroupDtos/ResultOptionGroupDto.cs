using QRRestaurantApp.Backend.Enums;

namespace QRRestaurantApp.Backend.DTOs.OptionGroupDtos
{
    public class ResultOptionGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public VariationType VariationType { get; set; }
        public bool IsRequired { get; set; }
        public int MinSelect { get; set; }
        public int MaxSelect { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
