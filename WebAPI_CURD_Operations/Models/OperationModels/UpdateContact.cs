namespace WebAPI_CURD_Operations.Models.OperationModels
{
    public class UpdateContact
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
