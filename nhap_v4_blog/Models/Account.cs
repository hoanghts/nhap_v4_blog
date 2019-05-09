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
        public numberDetail numberBlog { get; set; }
        public numberDetail numberPost { get; set; }
        public numberDetail numberComment { get; set; }
    }
    public struct numberDetail
    {
        public int number { get; set; }
        public IList<string> Detail { get; set; }
    }
}
