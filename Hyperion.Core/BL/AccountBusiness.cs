﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.BL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class AccountBusiness : AbstractBusiness<Account, int>, IBaseBL<Account, int>
    {
        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public AccountBusiness()
        {
            this.baseDal = RepositoryFactory<IAccountRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户名查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public Account FindByName(string userName)
        {
            return this.baseDal.FindOneByField("username", userName);
        }

        /// <summary>
        /// 查找设备操控用户
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public IEnumerable<Account> FindByEquipment(string serialNumber)
        {
            var dal = this.baseDal as IAccountRepository;
            return dal.FindByEquipment(serialNumber);
        }
        #endregion //Method
    }
}
