//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlog.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
            this.User1 = new HashSet<User>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Nullable<bool> Sex { get; set; }
        public Nullable<int> Country { get; set; }
        public string City { get; set; }
        public string Skype { get; set; }
        public string Icq { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<User> User1 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
