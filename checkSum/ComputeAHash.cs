// (c) Khaled A Alwan .
// All other rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading;


namespace checkSum
{
    public class ComputeAHash
    {
        public ComputeAHash() { }

        public string Hashvalue = null;

        public void MD5(string fname)//TODO: check for null fname
        {
            if (string.IsNullOrWhiteSpace(fname))
                return;
            StreamReader sr = new StreamReader(fname);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] cmphash = md5.ComputeHash(sr.BaseStream);
            Hashvalue = No2Hex(cmphash);
        }

        public void RIPEMD160(string fname)//skip for now.
        {
            //if (string.IsNullOrWhiteSpace(fname))
            //    return;
            //StreamReader sr = new StreamReader(fname);
            //RIPEMD160 ripmd160 = RIPEMD160Managed.Create();
            //byte[] cmphash = ripmd160.ComputeHash(sr.BaseStream);
            //Hashvalue = No2Hex(cmphash);
        }

        public void SHA1(string fname)//TODO: check for null fname
        {
            if (string.IsNullOrWhiteSpace(fname))
                return;
            StreamReader sr = new StreamReader(fname);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] cmphash = sha1.ComputeHash(sr.BaseStream);
            Hashvalue = No2Hex(cmphash);
        }
        public void SHA256(string fname)//TODO: check for null fname
        {
            if (string.IsNullOrWhiteSpace(fname))
                return;
            StreamReader sr = new StreamReader(fname);

            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] cmphash = sha256.ComputeHash(sr.BaseStream);
            Hashvalue = No2Hex(cmphash);
        }

        public void SHA384(string fname)//TODO: check for null fname
        {
            if (string.IsNullOrWhiteSpace(fname))
                return;
            StreamReader sr = new StreamReader(fname);

            SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
            byte[] cmphash = sha384.ComputeHash(sr.BaseStream);
            Hashvalue = No2Hex(cmphash);
        }

        public void SHA512(string fname)//TODO: check for null fname
        {
            if (string.IsNullOrWhiteSpace(fname))
                return;
            StreamReader sr = new StreamReader(fname);

            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            byte[] cmphash = sha512.ComputeHash(sr.BaseStream);
            Hashvalue = No2Hex(cmphash);
        }

        string No2Hex(byte[] cmphash)
        {
            if (cmphash == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cmphash.Length; i++)
            {
                sb.Append(cmphash[i].ToString("X2"));
            }
            return sb.ToString();
        }




    }
}
