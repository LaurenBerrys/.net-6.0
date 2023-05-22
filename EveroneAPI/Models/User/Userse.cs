using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EveroneAPI.Models.User
{


 
    /// <summary>
    ///用户
    /// </summary>
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    ///角色名字
    /// </summary>
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    ///用户，token
    /// </summary>
    public class UserTokenModel
    {
        public string Token { get; set; }
        public int UserId { get; set; }
    }

    /// <summary>
    ///用户，角色
    /// </summary>
    public class UserRoleModel
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    /// <summary>
    ///功能
    /// </summary>
    public class PowerModel
    {
        public int PowerId { get; set; }

        public int PageID { get; set; }

        public string Name { get; set; }
    }
    //角色，功能，
    public class PowerLinkModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int LinkId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MapClassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PowerId { get; set; }
    }

  
    //功能，角色模型
    public class PowerDemo
    {
        private List<UserModel> UserList = new List<UserModel>();
        private List<RoleModel> RoleList = new List<RoleModel>();
        private List<UserRoleModel> UserRoleList = new List<UserRoleModel>();
        private List<PowerModel> PowerList = new List<PowerModel>();
        private List<PowerLinkModel> PowerLinkList = new List<PowerLinkModel>();

        private List<UserTokenModel> UserTokenList = new List<UserTokenModel>();

        //public PowerDemo()
        //{
          
           
        //    RoleList.Add(new RoleModel
        //    {
        //        RoleId = 2,
        //        Name = "fdsfsd"
        //    });
        //    RoleList.Add(new RoleModel
        //    {
        //        RoleId = 3,
        //        Name = "fdsfsd"
        //    });

        //    UserRoleList.Add(new UserRoleModel
        //    {
        //        UserId = 1,RoleId = 1
        //    });
        //    UserRoleList.Add(new UserRoleModel
        //    {
        //        UserId = 1,
        //        RoleId = 2
        //    });

        //    UserRoleList.Add(new UserRoleModel
        //    {
        //        UserId = 2,
        //        RoleId = 2
        //    });
        //    UserRoleList.Add(new UserRoleModel
        //    {
        //        UserId = 2,
        //        RoleId = 3
        //    });

        //    UserRoleList.Add(new UserRoleModel
        //    {
        //        UserId = 3,
        //        RoleId = 3
        //    });

        //    PowerList.Add(new PowerModel
        //    {
        //        PowerId = 1,Name = "Add User"
        //    });

        //    PowerList.Add(new PowerModel
        //    {
        //        PowerId = 2,
        //        Name = "Edit User"
        //    });

        //    PowerLinkList.Add(new PowerLinkModel
        //    {
        //        LinkId = 1,PowerId =1,
        //        MapClassId = 1,     // MapClassId=1, MapId--》RoleId,   MapClassId=2, MapId--》UserId,  
        //        MapId = 2       // 
        //    });

        //    PowerLinkList.Add(new PowerLinkModel
        //    {
        //        LinkId = 2,
        //        PowerId = 2,
        //        MapClassId = 2,     // MapClassId=1, MapId--》RoleId,   MapClassId=2, MapId--》UserId,  
        //        MapId = 2
        //    });
        }
        
        //public string AddPower(string Name,int MapClassId,int MapId)
        //{
        //    var power = new PowerModel()
        //    {
        //        PowerId = PowerList.Count,
        //        Name = Name
        //    };
        //    PowerList.Add(power);

        //    // Next 
        //    PowerLinkList.Add(new PowerLinkModel
        //    {
        //        LinkId = PowerLinkList.Count,
        //        PowerId = power.PowerId,
        //        MapClassId = MapClassId,
        //        MapId = MapId
        //    });
        //    return "";
        //}
        
        //public bool OperatePower(string Name, int MapClassId, int MapId)
        //{
        //    var power = PowerList.Find(e => e.Name == Name);
        //    if(power == null)
        //    {
        //        return false;
        //    }

        //    var link = PowerLinkList.Find(e=>e.PowerId == power.PowerId && e.MapClassId == MapClassId && e.MapId == MapId);
        //    if (power == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public UserModel GetUserDetailByTonke(string token)
        //{
        //    var userToken = UserTokenList.Find(e => e.Token == token);
        //    if(userToken == null)
        //    {
        //        return null;
        //    }
        //    var user = UserList.Find(e => e.UserId == userToken.UserId);
        //    return user;
        //}
    }

  
