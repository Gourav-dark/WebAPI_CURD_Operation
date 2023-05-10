using System.ComponentModel.DataAnnotations;

namespace WebAPI_CURD_Operations.Models.AddClassModels
{
    public class AddContact
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
