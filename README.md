# MysqlHelper
MySqlHelper

引用MySql.Data

MySql帮助类，可以方便操作数据库

List<T> list =new List<T>();//T为接收数据的实体类
string sql="select * from xxx"; //xxx为数据库名
DataSet ds = MySqlHelper.ExecuteDataSet(DataHelper.GetConfig(),sql);
list=DataHelper.DataSetAToEntitiyList<T>(ds);
