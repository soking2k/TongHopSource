using BTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace Models
{
    public class AccountModels : DatabaseSerivce
    {

        DatabaseSerivce account = new DatabaseSerivce();
            public bool Checkaccount(string username, string pwd)
            {
                bool kq = false;
                try
                {
                    string sql = " Select * from Account Where Username = @Username and PassWord=@Password ";

                    SqlParameter parUsername = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar);
                     parUsername.Value = username;
                    SqlParameter parPwd = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar);
                    parPwd.Value = pwd;
                    SqlDataReader reader = ReadDataPars(sql, new[] { parUsername, parPwd });
                    if (reader.Read())
                    {
                        kq = true;
                    }
                    return kq;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    CloseConnection();
                }
                return kq;
            }
        public bool Checkusername(string username)
        {
            bool kq = false;
            try
            {
                string sql = " Select * from Account Where Username = @Username ";

                SqlParameter parUsername = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar);
                parUsername.Value = username;
                SqlDataReader reader = ReadDataPars(sql, new[] { parUsername });
                if (reader.Read())
                {
                    kq = true;
                }
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
       
       
        
     
       
     
        
       
      
        
      
       
        
       
        public ReportDataSource LayDS1()
            {
                //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
                //  SqlConnection cn = new SqlConnection(connectionString);
                var sql = "select c.MaHD,c.MaSP,c.TenSP,c.DonGia,c.SoLuong,b.NgayGiao ,(select Sum(DonGia) from dbo.ChiTietHoaDon) AS DoanhThu From HoaDon as b,ChiTietHoaDon as c  where b.MaHD = c.MaHD";
                DataSet2 m = new DataSet2();

                SqlDataAdapter Adapter = new SqlDataAdapter(sql, connection);
                Adapter.Fill(m, m.Tables[0].TableName);
                ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
                return dt1;
            }
        public ReportDataSource ShowBill(string MaHD)
        {
            //   const String connectionString = @"Data Source=(local);Initial Catalog=ProductOrder;User ID=sa;Password=123456";
            //  SqlConnection cn = new SqlConnection(connectionString);
            var sql = "select *,(select SUM(DonGia*SoLuong) from ChiTietHoaDon Where MaHD='" + MaHD + "') AS TongCong,(SELECT GETDATE()) AS ThoiGian From ChiTietHoaDon Where MaHD='" + MaHD+"'";
            DataSet2 m = new DataSet2();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(m, m.Tables[0].TableName);
            ReportDataSource dt1 = new ReportDataSource("DataSet1", m.Tables[0]);
            return dt1;
        }
       
       
        public bool register(string username, string pwd, String pwa_hint, String email, String name, String phone)
            {
                bool kq = false;
                try
                {
                    var sql = "Insert into account ( Username,PassWord,Password_hint,EMAIL,FullNAME,PHONE,STATUS,ACTIVITY) values (@username,@parPwd,@parPwd_hint,@email,@name,@phone,'0','0')";
                     SqlParameter parUsername = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
                     parUsername.Value = username;
                     SqlParameter parPwd = new SqlParameter("@parPwd", System.Data.SqlDbType.NVarChar);
                     parPwd.Value = pwd;
                     SqlParameter parPwd_hint = new SqlParameter("@parPwd_hint", System.Data.SqlDbType.NVarChar);
                     parPwd_hint.Value = pwa_hint;
                    SqlParameter parEmail = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
                    parEmail.Value = email;                 
                    SqlParameter parName = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                    parName.Value = name;
                    SqlParameter parPhone = new SqlParameter("@phone", System.Data.SqlDbType.NVarChar);
                    parPhone.Value = phone;
                    account.Excute(sql, new[] { parUsername, parPwd, parPwd_hint, parEmail, parName, parPhone });
                    kq = true;
                     return kq;
            }
            catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    CloseConnection();
                }
                return kq;
            }
        public bool checkforget(string tk, string email, String phone)
        {
            bool kq = false;
            try
            {
                var sql = "select * FROM account where Username=@tk and email=@email and phone=@phone";
                SqlParameter partk = new SqlParameter("@tk", System.Data.SqlDbType.NVarChar);
                partk.Value = tk;
                SqlParameter paremail = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
                paremail.Value = email;
                SqlParameter parphone = new SqlParameter("@phone", System.Data.SqlDbType.NVarChar);
                parphone.Value = phone;     
                SqlDataReader reader = ReadDataPars(sql, new[] { partk, paremail, parphone });
                if (reader.Read())
                {
                    kq = true;
                }
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool forget(String tk, String email, String phone, String newpass, String newpass_hint)
        {
            bool kq = false;
            try
            {
                var sql = "UPDATE account SET PassWord=@parPwd,PassWord_hint=@parPwd_hint where Username=@tk and Email=@email and Phone=@phone";
                SqlParameter parUsername = new SqlParameter("@tk", System.Data.SqlDbType.NVarChar);
                parUsername.Value = tk;
                SqlParameter parEmail = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
                parEmail.Value = email;
                SqlParameter parPhone = new SqlParameter("@phone", System.Data.SqlDbType.NVarChar);
                parPhone.Value = phone;
                SqlParameter parPwd = new SqlParameter("@parPwd", System.Data.SqlDbType.NVarChar);
                parPwd.Value = newpass;
                SqlParameter parPwd_hint = new SqlParameter("@parPwd_hint", System.Data.SqlDbType.NVarChar);
                parPwd_hint.Value = newpass_hint;

                account.Excute(sql, new[] { parPwd, parPwd_hint, parUsername, parEmail, parPhone });
                kq = true;
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        
       
       
      
     
        
        
       
       
       
        
        
       
        
       
        public bool changeinfo(string id, String email, string pwd, String name, String phone)
            {
                bool kq = false;
                try
                {
                    var sql = "UPDATE account SET Email = @email,Pass=@pwd,Name=@name,Phone=@phone where ID=@ID";
                    SqlParameter parID = new SqlParameter("@ID", System.Data.SqlDbType.NVarChar);
                    parID.Value = id;
                    SqlParameter parEmail = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
                    parEmail.Value = email;
                    SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.NVarChar);
                    parPwd.Value = pwd;
                    SqlParameter parName = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                    parName.Value = name;
                    SqlParameter parPhone = new SqlParameter("@phone", System.Data.SqlDbType.NVarChar);
                    parPhone.Value = phone;
                    account.Excute(sql, new[] { parEmail, parPwd, parName, parPhone, parID });
                    kq = true;

                    /*
                    string sql = " Insert into account (EMAIL, PASS,NAME,PHONE,ACCTYPE) values (@email,@pwd,@name,@phone)";

                    SqlParameter parEmail = new SqlParameter("@email", System.Data.SqlDbType.NVarChar);
                    parEmail.Value = email;
                    SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.NVarChar);
                    parPwd.Value = pwd;
                    SqlParameter parName = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                    parName.Value = name;
                    SqlParameter parPhone = new SqlParameter("@phone", System.Data.SqlDbType.NVarChar);
                    parPhone.Value = name;
                    SqlCommand succes = Excute(sql, new[] { parEmail, parPwd, parName, parPhone });                 
                    return kq;
           */
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    CloseConnection();
                }
                return kq;
            }
            public bool Checkadmin(String username)
            {
                bool kq = false;
                try
                {
                    string sql = " Select * from Account Where username = @username and Status ='1' ";

                    SqlParameter parusernamel = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
                parusernamel.Value = username;
              
                    SqlDataReader reader = ReadDataPars(sql, new[] { parusernamel });
                    if (reader.Read())
                    {
                        kq = true;
                    }
                    return kq;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    CloseConnection();
                }
                return kq;
            }
        public bool CheckActivity(String username)
        {
            bool kq = false;
            try
            {
                string sql = " Select * from Account Where username = @username and Activity ='1' ";

                SqlParameter parUsername = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);
                parUsername.Value = username;
                SqlDataReader reader = ReadDataPars(sql, new[] { parUsername});
                if (reader.Read())
                {
                    kq = true;
                }
                return kq;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }

    }
    
}
