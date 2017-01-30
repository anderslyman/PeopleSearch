using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Models
{
    public class Contact
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Interests { get; set; }
        public string Photo { get; set; }
    }
}