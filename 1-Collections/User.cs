using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            FullName = fullName;
            Username = username;
            Age = age;
            if(Username.Equals(null))
            {
                throw new ArgumentNullException("Username is null");
            }
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
        public override int GetHashCode() => HashCode.Combine(Age, FullName, Username);
        private bool Equals(User u) => (Age.Equals(u.Age) && FullName.Equals(u.FullName) && Username.Equals(u.Username));
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }
        public override string ToString() => "Name = " + FullName + ", Username = " + Username + ", Age = " + Age;
    }
}
