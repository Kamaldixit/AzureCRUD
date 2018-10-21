using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.model;

namespace Azure.dao
{
     interface UserDetailsDAO
    {
         bool addUser(UserDetails user);

         bool removeUser(UserDetails user);

         bool updateUser(UserDetails user);
         List<UserDetails> getAllUsers();
         UserDetails getUsersById(UserDetails user);

         UserDetails getSqlDataById(UserDetails user);
         UserDetails getSqlDataByUserId(UserDetails user);
         
        
    }
}
