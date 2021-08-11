using System.Text.Json.Serialization;
using AdminDashboard.Wasm.Helpers;

namespace AdminDashboard.Wasm.Models.User
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool IsDeleting { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }
    }
}