

namespace AdminGateWay.Entities
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int? Nooforders { get; set; }
        public int? Failedorders { get; set; }
    }
}
