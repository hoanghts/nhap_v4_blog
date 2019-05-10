using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_v4_blog.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender _Gender { get; set; }
        public string Email { get; set; }
    }
    public enum Gender
    {
        Men = 1,
        Women = 2
    }
    public struct DetailAccountItem {
        public Detail Blog { get; set; }
        public Detail Post { get; set; }
        public Detail Comment { get; set; }
    }
    public struct Detail
    {
        public IList<int> Id { get; set; }
        public IList<string> Content { get; set; }
    }
}
