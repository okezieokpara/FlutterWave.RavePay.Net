using System;

using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Customers
{
    public class Customer
    {
        public Customer()
        {
            
        }

        public Customer(long id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("customertoken")]
        public string CustomerToken { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public DateTime DeletedAt { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }
    }
}