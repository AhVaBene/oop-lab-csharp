using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly Dictionary<string, ISet<TUser>> _followers = new Dictionary<string, ISet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {

        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (_followers.ContainsKey(group))
            {
                _followers[group].Add(user);
                return false;
            }
            var set = new HashSet<TUser>();
            _followers[group] = set;
            _followers[group].Add(user);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                var list = new List<TUser>();
                foreach(var groups in _followers.Values)
                {
                    foreach(var follower in groups)
                    {
                        list.Add(follower);
                    }
                }
                return list;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (_followers.ContainsKey(group))
            {
                return new HashSet<TUser>(_followers[group]);
            }
            return new HashSet<TUser>();
        }
    }
}
