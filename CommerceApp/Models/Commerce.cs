using System;
using System.ComponentModel.DataAnnotations;


namespace CommerceApp.Models
{
    public class Commerce
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //[DataType(DataType.Date)]
        //public DateTime Manufactured { get; set; }

        //public DateTime Expiry { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        
    }
}