using ShopBridgeBLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeBLL.Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public int AuthenticateUser(string username, string password)
        {
            return userRepository.AuthenticateUser(username, password);
        }
    }
}
