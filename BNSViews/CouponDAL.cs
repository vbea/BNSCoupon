using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BNSLogic
{
    public class CouponDAL
    {
        private string connectionString;

        public CouponDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        #region 获取列表
        /// <summary>
        /// 根据ID排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListById(string order)
        {
            string sql = "select distinct * from BNSVIEW1 order by id " + order;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 根据等级排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListByLevel(string order)
        {
            string sql = "select distinct * from BNSVIEW1 order by level " + order + ",stard " + order + ",id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 根据点券排序获取列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getBNSListByCoupon(string order)
        {
            string sql = "select distinct * from BNSVIEW1 order by coupon " + order + ",id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取补登列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getCouponList()
        {
            string sql = "select distinct * from BNSVIEW1 order by checkdate, id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 账号数据操作
        /// <summary>
        /// 获取账号列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getAccountList()
        {
            string sql = "select t.id,qq,psd,name,gender,race,v.vocation,redate,level,stard,remark from (select b.id,qq,psd,name,gender,vocation,redate,level,stard,remark from BNSCoupon b left join gender g on b.sex=g.pid where valid=1)t join Vocation v on t.vocation=v.id order by id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取账号列表
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>数据集</returns>
        public DataSet getAccountList(int id)
        {
            string sql = "select * from BNSCoupon where id=@id";
            SqlParameter pars = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(pars);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取账号回收列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getRecycleAccountList()
        {
            string sql = "select t.id,qq,psd,name,gender,race,v.vocation,redate,level,stard,remark from (select b.id,qq,psd,name,gender,vocation,redate,level,stard,remark from BNSCoupon b left join gender g on b.sex=g.pid where valid=0)t join Vocation v on t.vocation=v.id order by id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        } 

        public int addAccount(string qq, string pwd, string name, int sex,int vocation,DateTime redate, int level, int stard,long coupon, string remark,DateTime checkesd)
        {
            string sql = "insert into BNSCoupon (qq,psd,name,sex,vocation,redate,level,stard,coupon,remark,checkdate,checktime,valid) values (@qq,@psd,@name,@sex,@vocation,@redate,@level,@stard,@coupon,@remark,@check1,@check2,@valid)";
            SqlParameter[] paras = { 
                                       new SqlParameter("@qq",qq),
                                       new SqlParameter("@psd",pwd),
                                       new SqlParameter("@name",name),
                                       new SqlParameter("@sex",sex),
                                       new SqlParameter("@vocation",vocation),
                                       new SqlParameter("@redate",redate),
                                       new SqlParameter("@level",level),
                                       new SqlParameter("@stard",stard),
                                       new SqlParameter("@coupon",coupon),
                                       new SqlParameter("@remark",remark),
                                       new SqlParameter("@check1",checkesd.Date),
                                       new SqlParameter("@check2",checkesd.TimeOfDay),
                                       new SqlParameter("@valid",1)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int setAccount(int id, string pwd, string name, int sex,int vocation,DateTime redate, int level, int stard, string remark)
        {
            string sql = "update BNSCoupon set psd=@psd,name=@name,sex=@sex,vocation=@vocation,redate=@redate,level=@level,stard=@stard,remark=@remark where id=@id";
            SqlParameter[] paras = { 
                                       new SqlParameter("@psd",pwd),
                                       new SqlParameter("@name",name),
                                       new SqlParameter("@sex",sex),
                                       new SqlParameter("@vocation",vocation),
                                       new SqlParameter("@redate",redate),
                                       new SqlParameter("@level",level),
                                       new SqlParameter("@stard",stard),
                                       new SqlParameter("@remark",remark),
                                       new SqlParameter("@id",id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int setAccount(int id, long coupon,DateTime check)
        {
            string sql = "update BNSCoupon set coupon=@coupon,checkdate=@check,checktime=@check2 where id=@id";
            SqlParameter[] paras = { 
                                       new SqlParameter("@coupon",coupon),
                                       new SqlParameter("@check",check.Date),
                                       new SqlParameter("@check2",check.TimeOfDay),
                                       new SqlParameter("@id",id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int enableAccount(int id,bool action)
        {
            string sql = "update BNSCoupon set valid=@action where id=@id";
            SqlParameter[] paras = {
                                       new SqlParameter("@action", action),
                                       new SqlParameter("@id",id)
                                    };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int deleteAccount(int id)
        {
            string sql = "delete from BNSCoupon where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取账号统计列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getStatisticsList()
        {
            string sql = "select qq,v.race,v.vocation from BNSCoupon b left join Vocation v on b.vocation=v.id where b.valid=1";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 获取条件数据
        /// <summary>
        /// 获取当前条件数据
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getWhere()
        {
            string sql = "select minlevel,minStard,coupon,cycle,dates,remark,id from Threshold where isvalid=1";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取条件数据列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getWhereList()
        {
            string sql = "select * from Threshold";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 条件列表数据操作
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="minLvel">最低等级</param>
        /// <param name="minStard">最低星级</param>
        /// <param name="coupon">数量</param>
        /// <param name="cycle">周期</param>
        /// <param name="remark">备注/说明</param>
        /// <returns>受影响的行数</returns>
        public int setWhere(int id, string minLvel, string minStard, string coupon, string cycle, string date, string remark)
        {
            string sql = "update Threshold set minlevel=@minlevel,minStard=@minStard,coupon=@coupon,cycle=@cycle,dates=@date,remark=@remark where id=@id";
            SqlParameter[] paras = {
                                       new SqlParameter("@minlevel",minLvel),
                                       new SqlParameter("@minStard",minStard),
                                       new SqlParameter("@coupon",coupon),
                                       new SqlParameter("@cycle",cycle),
                                       new SqlParameter("@date",SqlDbType.Date),
                                       new SqlParameter("@remark",remark),
                                       new SqlParameter("@id",id)
                                   };
            if (date.Equals(""))
                paras[4].Value = DBNull.Value;
            else
                paras[4].Value = date;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="invalid">状态</param>
        /// <returns>受影响的行数</returns>
        public int setWhere(int id, int invalid)
        {
            string sql = "update Threshold set isvalid=@isvalid where id=@id";
            SqlParameter[] paras = {
                                        new SqlParameter("@isvalid", invalid),
                                        new SqlParameter("@id", id)
                                    };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="minLvel">最低等级</param>
        /// <param name="minStard">最低星级</param>
        /// <param name="coupon">数量</param>
        /// <param name="cycle">周期</param>
        /// <param name="remark">备注/说明</param>
        /// <returns>受影响的行数</returns>
        public int addWhere(string minLvel, string minStard, string coupon, string cycle, string remark)
        {
            string sql = "insert into Threshold (minlevel,minStard,coupon,cycle,remark,isvalid) values (@minlevel,@minStard,@coupon,@cycle,@remark,@isvalid)";
            SqlParameter[] paras = {
                                       new SqlParameter("@minlevel",minLvel),
                                       new SqlParameter("@minStard",minStard),
                                       new SqlParameter("@coupon",coupon),
                                       new SqlParameter("@cycle",cycle),
                                       new SqlParameter("@remark",remark),
                                       new SqlParameter("@isvalid",1)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int deleteWhere(int id)
        {
            string sql = "delete from Threshold where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 获取性别列表
        /// <summary>
        /// 获取性别列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getGenders()
        {
            string sql = "select * from Gender";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 获取职业列表
        /// <summary>
        /// 获取职业列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getVocationList()
        {
            string sql = "select * from Vocation";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取职业列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getVocationList(int id)
        {
            string sql = "select * from Vocation where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取包含性别的职业列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getVocationList(string sex)
        {
            string sql = "select * from Vocation where sex like @sex";
            SqlParameter para = new SqlParameter("@sex", "%" + sex + "%");
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 获取单一职业列表
        /// </summary>
        /// <returns></returns>
        public DataSet getSingleVocation()
        {
            string sql = "select distinct vocation from Vocation";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 职业列表数据操作
        /// <summary>
        /// 添加职业数据
        /// </summary>
        /// <param name="race">种族</param>
        /// <param name="vocation">职业</param>
        /// <param name="gender">包含性别</param>
        /// <returns>受影响的行数</returns>
        public int addVocation(string race, string vocation, string gender)
        {
            string sql = "insert into Vocation (race,vocation,sex) values (@race,@vocation,@sex)";
            SqlParameter[] paras = {
                                       new SqlParameter("@race",race),
                                       new SqlParameter("@vocation",vocation),
                                       new SqlParameter("@sex",gender),
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 修改职业数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="race">种族</param>
        /// <param name="vocation">职业</param>
        /// <param name="gender">包含性别</param>
        /// <returns>受影响的行数</returns>
        public int setVocation(int id, string race, string vocation, string gender)
        {
            string sql = "update Vocation set race=@race,vocation=@vocation,sex=@sex where id=@id";
            SqlParameter[] paras = {
                                       new SqlParameter("@race",race),
                                       new SqlParameter("@vocation",vocation),
                                       new SqlParameter("@sex",gender),
                                       new SqlParameter("@id",id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 删除职业数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>受影响的行数</returns>
        public int deleteVocation(int id)
        {
            string sql = "delete from Vocation where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region 性别表数据操作
        /// <summary>
        /// 删除性别
        /// </summary>
        /// <param name="id">PID</param>
        /// <returns>受影响的行数</returns>
        public int deleteGenders(int id)
        {
            string sql = "delete from Gender where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 新增性别
        /// </summary>
        /// <param name="id">PID</param>
        /// <param name="str">Gender</param>
        /// <returns>受影响的行数</returns>
        public int addGenders(int id, string str)
        {
            string sql = "insert into Gender (pid,gender) values (@pid,@gender)";
            SqlParameter[] paras = {
                                        new SqlParameter("@pid",id),
                                        new SqlParameter("@gender", str)
                                    };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 商品表数据操作
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getCommodityList(bool state)
        {
            string sql = "select s.id,name,catename,cost,price,maxs,mark from Store s left join Category c on c.id=s.category where isDelete=@delete";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@delete", state);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityList(int id)
        {
            string sql = "select id,name,category,cost,price,maxs,mark from Store where id=@id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 添加商品数据
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="category">分类编号</param>
        /// <param name="price">价格</param>
        /// <param name="maxs">最大购买</param>
        /// <param name="mark">说明</param>
        /// <param name="delete">是否删除</param>
        /// <returns>受影响的行数</returns>
        public int addCommodity(string name, int category, int cost, int price, int maxs, string mark, int delete)
        {
            string sql = "insert into Store (name,category,cost,price,maxs,mark,isDelete) values (@name,@category,@cost,@price,@maxs,@mark,@delete)";
            SqlParameter[] paras = { 
                                       new SqlParameter("@name",name),
                                       new SqlParameter("@category",category),
                                       new SqlParameter("@cost", cost),
                                       new SqlParameter("@price",price),
                                       new SqlParameter("@maxs",maxs),
                                       new SqlParameter("@mark",mark),
                                       new SqlParameter("@delete", delete)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="category">分类编号</param>
        /// <param name="price">价格</param>
        /// <param name="maxs">最大购买</param>
        /// <param name="mark">说明</param>
        /// <returns>受影响的行数</returns>
        public int setCommodity(int id, string name, int category, int cost, int price, int maxs, string mark)
        {
            string sql = "update Store set name=@name,category=@category,cost=@cost,price=@price,maxs=@maxs,mark=@mark where id=@id";
            SqlParameter[] paras = { 
                                       new SqlParameter("@name",name),
                                       new SqlParameter("@category",category),
                                       new SqlParameter("@cost", cost),
                                       new SqlParameter("@price",price),
                                       new SqlParameter("@maxs",maxs),
                                       new SqlParameter("@mark",mark),
                                       new SqlParameter("@id", id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 回收或还原商品
        /// </summary>
        /// <param name="delete">是否删除</param>
        /// <returns>受影响的行数</returns>
        public int setCommodity(int id, int delete)
        {
            string sql = "update Store set isDelete=@delete where id=@id";
            SqlParameter[] paras = {
                                       new SqlParameter("@delete", delete),
                                       new SqlParameter("@id", id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品编号</param>
        /// <returns>受影响的行数</returns>
        public int delCommodity(int id)
        {
            string sql = "delete Store where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 商品分类表数据操作
        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns>数据集</returns>
        public DataSet getCategory()
        {
            string sql = "select * from Category order by id desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="catename">分类名称</param>
        /// <returns>受影响的行数</returns>
        public int addCategory(string catename)
        {
            string sql = "insert into Category (catename) values (@name)";
            SqlParameter para = new SqlParameter("@name",catename);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        
        /// <summary>
        /// 修改商品分类
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="catename">分类名称</param>
        /// <returns>受影响的行数</returns>
        public int updateCategory(int id, string catename)
        {
            string sql = "update Category set catename=@catename where id=@id";
            SqlParameter[] paras = { 
                                       new SqlParameter("@catename",catename),
                                       new SqlParameter("@id",id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>受影响的行数</returns>
        public int delCategory(int id)
        {
            string sql = "delete Category where id=@id";
            SqlParameter para = new SqlParameter("@id", id);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 商品购买的方法
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityListByKey(string key)
        {
            string sql = "select s.id,name,catename,cost,price,maxs,mark from Store s left join Category c on c.id=s.category where name like @key and isDelete=0";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@key", "%" + key + "%");
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityListByIds(int id)
        {
            string sql = "select s.id,name,catename,cost,price,maxs,mark from Store s left join Category c on c.id=s.category where (name like @key or s.id=@id) and isDelete=0";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter[] paras = {
                                        new SqlParameter("@id", id),
                                        new SqlParameter("@key", "%" + id + "%")
                                    };
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 根据分类获取商品列表
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityListByCategory(int id)
        {
            string sql = "select s.id,name,catename,cost,price,maxs,mark from Store s left join Category c on c.id=s.category where category=@id and isDelete=0";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 根据ID获取商品列表
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>数据集</returns>
        public DataSet getCommodityListById(int id)
        {
            string sql = "select s.id,name,catename,cost,price,maxs,mark from Store s left join Category c on c.id=s.category where s.id=@id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", id);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 扣除账号点券
        /// </summary>
        /// <param name="id">账号ID</param>
        /// <param name="coupon">新的点券余额</param>
        /// <returns>受影响的行数</returns>
        public int deductCoupon(int id, long coupon)
        {
            string sql = "update BNSCoupon set coupon=@coupon where id=@id";
            SqlParameter[] paras = { 
                                       new SqlParameter("@coupon",coupon),
                                       new SqlParameter("@id",id)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
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
        public int addOrderLog(int account, int cid, string cname, int unit, int count, int price, DateTime date)
        {
            string sql = "insert into OrderLog (account,cid,cname,cunit,ccount,price,dates) values (@account,@cid,@cname,@cunit,@ccount,@price,@dates)";
            SqlParameter[] paras = { 
                                       new SqlParameter("@account",account),
                                       new SqlParameter("@cid",cid),
                                       new SqlParameter("@cname",cname),
                                       new SqlParameter("@cunit",unit),
                                       new SqlParameter("@ccount",count),
                                       new SqlParameter("@price",price),
                                       new SqlParameter("@dates", date)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 获取购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderList(int account)
        {
            string sql = "select top(10)* from OrderLog where account=@id and DATEDIFF(m, dates, GETDATE())=0 order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取本月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderThisMonth(int account)
        {
            string sql = "select * from OrderLog where account=@id and DATEDIFF(m, dates, GETDATE())=0 order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取上月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderLastMonth(int account)
        {
            string sql = "select * from OrderLog where account=@id and DATEDIFF(m, dates, GETDATE())=1 order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取近三月购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderThreeMonth(int account)
        {
            string sql = "select * from OrderLog where account=@id and DATEDIFF(m, dates, GETDATE())<=2 order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取三个月前购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderLastThreeMonth(int account)
        {
            string sql = "select * from OrderLog where account=@id and DATEDIFF(m, dates, GETDATE())>2 order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 获取全部购买记录
        /// </summary>
        /// <param name="account">账号ID</param>
        /// <returns>数据集</returns>
        public DataSet getOrderAll(int account)      
        {
            string sql = "select * from OrderLog where account=@id order by dates desc";
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter para = new SqlParameter("@id", account);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(para);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region 设置表数据操作
        public DataSet getSettings()
        {
            string sql = "select keys,state,value from Setting";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        } 

        /// <summary>
        /// 更新设置表数据
        /// </summary>
        /// <param name="key">设置key</param>
        /// <param name="state">value1</param>
        /// <param name="value">value2</param>
        /// <returns></returns>
        public int setSettings(string key, bool state, int value)
        {
            string sql = "update Setting set state=@state,value=@value where keys=@keys";
            SqlParameter[] paras = {
                                        new SqlParameter("@keys",key),
                                        new SqlParameter("@state", state),
                                        new SqlParameter("@value", value)
                                   };
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
