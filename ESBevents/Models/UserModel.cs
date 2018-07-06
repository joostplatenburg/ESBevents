using System;

namespace ESBevents.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AangemaaktOp { get; set; }
        public string GewijzigdOp { get; set; }
        public string IngelogdOp { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Message { get; set; }
        public bool? Approved { get; set; }
   }
}
