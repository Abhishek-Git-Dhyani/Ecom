using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace Ecom.Models
{
    internal interface IEncryptions
    {
        ValueTuple<string, string> Encrypt(string password);
        bool Decrypt(string password,string hashPassword,string salt);
    }
    public class HashEncryption : IEncryptions
    {
        public ValueTuple<string,string> Encrypt(string password)
        {
            string salt = string.Empty;
            string PASSWORD = string.Empty;
            try
            {
                salt = Crypto.GenerateSalt();
                password = password + salt;
                PASSWORD = Crypto.HashPassword(password);

                return ValueTuple.Create(PASSWORD, salt);
            }
            catch (Exception ex)
            {
                return ValueTuple.Create("","");
            }
        }

        public bool Decrypt(string password, string hashPassword, string salt)
        {
            bool isVerified = false;
            try
            {
                password = password + salt;

                isVerified = Crypto.VerifyHashedPassword(hashPassword, password);

                return isVerified;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}