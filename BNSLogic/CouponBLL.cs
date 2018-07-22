using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BNSLogic
{
    public class CouponBLL
    {
        private CouponDAL dal;
        public CouponBLL()
        {
            dal = new CouponDAL();
        }

        #region 账号表数据操作

        /// <summary>
        /// 根据ID排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListById(string order)
        {
            return dal.getBNSListById(order);
        }

        /// <summary>
        /// 根据等级排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListByLevel(string order)
        {
            return dal.getBNSListByLevel(order);
        }

        /// <summary>
        /// 根据点券排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListByCoupon(string order)
        {
            return dal.getBNSListByCoupon(order);
        }

        public DataSet getCouponList()
        {
            return dal.getCouponList();
        }
        public DataSet getAccountList()
        {
            return dal.getAccountList();
        }

        public DataSet getAccountList(int id)
        {
            return dal.getAccountList(id);
        }

        public DataSet getRecycleAccountList()
        {
            return dal.getRecycleAccountList();
        }

        public bool deleteAccount(int id)
        {
            return dal.deleteAccount(id) > 0;
        }

        public bool enableAccount(int id)
        {
            return dal.enableAccount(id, true) > 0;
        }

        public bool disableAccount(int id)
        {
            return dal.enableAccount(id, false) > 0;
        }

        public bool addAccount(string qq, string pwd, string name, int sex, int vocation, DateTime redate, int level, int stard, string remark)
        {
            return dal.addAccount(qq, pwd, name, sex, vocation, redate, level, stard, 0, remark, DateTime.Now) > 0;
        }

        public bool setAccount(int id, string pwd, string name, int sex, int vocation, DateTime redate, int level, int stard, string remark)
        {
            return dal.setAccount(id, pwd, name, sex, vocation, redate, level, stard, remark) > 0;
        }

        public bool setAccount(int id, long coupon, DateTime date)
        {
            return dal.setAccount(id, coupon, date) > 0;
        }

        /// <summary>
        /// 获取账号统计列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getStatisticsList()
        {
            return dal.getStatisticsList();
        }
        #endregion

        #region 条件表数据操作
        public DataSet getWhere()
        {
            return dal.getWhere();
        }

        public DataSet getWhereList()
        {
            return dal.getWhereList();
        }

        public bool setWhere(int id, string minLvel, string minStard, string coupon, string cycle,string date, string remark)
        {
            bool state = false;
            if (dal.setWhere(id, minLvel, minStard, coupon, cycle, date, remark) > 0)
                state = true;
            return state;
        }

        public bool setWhere(int id, int invalid)
        {
            return dal.setWhere(id, invalid) > 0;
        }

        public bool addWhere(string minLvel, string minStard, string coupon, string cycle, string remark)
        {
            return dal.addWhere(minLvel, minStard, coupon, cycle, remark) > 0;
        }

        public bool deleteWhere(int id)
        {
            return dal.deleteWhere(id) > 0;
        } 
        #endregion

        #region 性别表数据操作
        public DataSet getGenders()
        {
            return dal.getGenders();
        }

        public bool deleteGender(int id)
        {
            return dal.deleteGenders(id) > 0;
        }

        public bool addGender(int pid, string gender)
        {
            return dal.addGenders(pid, gender) > 0;
        } 
        #endregion

        #region 职业表数据操作
        public DataSet getVocationList()
        {
            return dal.getVocationList();
        }

        public DataSet getVocationList(int id)
        {
            return dal.getVocationList(id);
        }

        public DataSet getVocationList(string sex)
        {
            return dal.getVocationList(sex);
        }

        public bool addVocation(string race, string vocation, string gender)
        {
            return dal.addVocation(race, vocation, gender) > 0;
        }

        public bool setVocation(int id, string race, string vocation, string gender)
        {
            return dal.setVocation(id, race, vocation, gender) > 0;
        }

        public bool deleteVocation(int id)
        {
            return dal.deleteVocation(id) > 0;
        }

        /// <summary>
        /// 获取单一职业列表
        /// </summary>
        /// <returns></returns>
        public DataSet getSingleVocation()
        {
            return dal.getSingleVocation();
        }
        #endregion

        #region 商品表数据操作
        public DataSet getCommodityList()
        {
            return dal.getCommodityList(false);
        }

        public DataSet getReCommodityList()
        {
            return dal.getCommodityList(true);
        }

        public DataSet getCommodityList(int id)
        {
            return dal.getCommodityList(id);
        }

        public bool addCommodity(string name, int category, int cost, int price, int maxs, string mark)
        {
            return dal.addCommodity(name, category, cost, price, maxs, mark, 0) > 0;
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="category">分类编号</param>
        /// <param name="price">价格</param>
        /// <param name="maxs">最大购买</param>
        /// <param name="mark">说明</param>
        /// <returns>是否成功</returns>
        public bool setCommodity(int id, string name, int category, int cost, int price, int maxs, string mark)
        {
            return dal.setCommodity(id, name, category, cost, price, maxs, mark) > 0;
        }

        public bool recycleCommodity(int id)
        {
            return dal.setCommodity(id, 1) > 0;
        }

        public bool restoreCommodity(int id)
        {
            return dal.setCommodity(id, 0) > 0;
        }

        public bool delCommodity(int id)
        {
            return dal.delCommodity(id) > 0;
        }
        #endregion

        #region 商品分类表数据操作
        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getCategory()
        {
            return dal.getCategory();
        }

        public bool addCategory(string catename)
        {
            return dal.addCategory(catename) > 0;
        }
        public bool updateCategory(int id, string catename)
        {
            return dal.updateCategory(id, catename) > 0;
        }

        public bool delCategory(int id)
        {
            return dal.delCategory(id) > 0;
        }
        #endregion

        #region 商品购买的方法
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityList(string key)
        {
            try
            {
                return dal.getCommodityListByIds(Convert.ToInt32(key));
            }
            catch
            {
                return dal.getCommodityListByKey(key);
            }
        }

        /// <summary>
        /// 根据分类获取商品列表
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityListByCategory(int id)
        {
            return dal.getCommodityListByCategory(id);
        }

        public DataSet getCommodityListById(int id)
        {
            return dal.getCommodityListById(id);
        }

        public bool deductCoupon(int id, long coupon)
        {
            return dal.deductCoupon(id, coupon) > 0;
        }
        #endregion

        #region 购买记录表数据操作
        /// <summary>
        /// 添加购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <param name="cid">商品ID</param>
        /// <param name="cname">商品名称</param>
        /// <param name="unit">单价</param>
        /// <param name="count">数量</param>
        /// <param name="price">总价</param>
        /// <param name="date">购买时间</param>
        /// <returns>受影响的行数</returns>
        public bool addOrderLog(int account, int cid, string cname, int unit, int count, int price, DateTime date)
        {
            return dal.addOrderLog(account, cid, cname, unit, count, price, date) > 0;
        }

        /// <summary>
        /// 获取购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderList(int account)
        {
            return dal.getOrderList(account);
        }

        /// <summary>
        /// 获取本月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderThisMonth(int account)
        {
            return dal.getOrderThisMonth(account);
        }

        /// <summary>
        /// 获取上月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderLastMonth(int account)
        {
            return dal.getOrderLastMonth(account);
        }

        /// <summary>
        /// 获取近三月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderThreeMonth(int account)
        {
            return dal.getOrderThreeMonth(account);
        }

        /// <summary>
        /// 获取三个月前购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderLastThreeMonth(int account)
        {
            return dal.getOrderLastThreeMonth(account);
        }

        /// <summary>
        /// 获取全部购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderAll(int account)
        {
            return dal.getOrderAll(account);
        }
        #endregion

        #region 设置表数据操作
        public DataSet getSettings()
        {
            return dal.getSettings();
        }

        public bool setShowAccount(bool state)
        {
            return dal.setSettings("showAccount", state, 0) > 0;
        }

        public bool setShowCommodity(bool state)
        {
            return dal.setSettings("showStore", state, 0) > 0;
        }

        public bool setOrderBy(int order, bool asc)
        {
            return dal.setSettings("orderby", asc, order) > 0;
        }

        #endregion
    }
}
