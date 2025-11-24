using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberSystem.WindowsUI.Models
{
    public class SubscriberDto
    {
        public int SubscriberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SocialSecurity { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Phone { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
    }
}