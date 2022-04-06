using BTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Reporting.WinForms;

namespace Controller
{
    public class ControllerAccount
    {
        AccountModels da1 = new AccountModels();

        public bool Checkusername(String username)
        {
            bool kq = false;
            if (da1.Checkusername(username))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckAccount(String username, String pwa)
        {
            bool kq = false;
            if (da1.Checkaccount(username, pwa))
            {
                kq = true;
            }
            return kq;
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        public bool checkkytu(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public bool checkregister(String username,String pwa, String pwa_hint, String email,  String name, String phone)
        {
            bool kq = false;
            if (da1.register(username, pwa,pwa_hint, email, name, phone))
            {
                kq = true;
            }
            return kq;
        }
        public bool forget(String tk, String email, String phone, String newpass, String newpass_hint)
        {
            bool kq = false;
            if (da1.forget(tk, email, phone, newpass, newpass_hint))
            {
                kq = true;
            }
            return kq;
        }
        public bool checkforget(String tk, String email, String phone)
        {
            bool kq = false;
            if (da1.checkforget(tk, email, phone))
            {
                kq = true;
            }
            return kq;
        }
       

      
        
        
       
       
       
      
        public bool checkchangeinfo(string id, String email, String pwa, String name, String phone)
        {
            bool kq = false;
            if (da1.changeinfo(id, email, pwa, name, phone))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckAdmin(String username)
        {
            bool kq = false;
            if (da1.Checkadmin(username))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckActivity(String username)
        {
            bool kq = false;
            if (da1.CheckActivity(username))
            {
                kq = true;
            }
            return kq;
        }
       
       
      
        
        public ReportDataSource ShowBill(string MaHD)
        {
            return da1.ShowBill(MaHD);

        }
        
    
    }
}
