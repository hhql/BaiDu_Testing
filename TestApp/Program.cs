using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Web.Services.Description;
using System.ServiceModel;

namespace TestApp
{
    internal class Program
    {
        static string asdf = "0";
        private static System.IO.Ports.SerialPort serialPortTest;

        private static System.IO.Ports.SerialPort serialPortTest1;
        static void Main(string[] args)
        {

            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
            Console.WriteLine(strID);
            return;
            uint seed = Convert.ToUInt32("0C0C0C0C", 16);
            uint ukey = canculate_app_security_access_xxx(seed);//86dc90f
            string strKey = ukey.ToString("X8");
            
            string normalizedKeys = string.Join(" ", Regex.Matches(strKey, @"..").Cast<Match>().ToList());






           // double F1 = 0.44 / Math.Pow(10, 6);
           // double F2 = 0.0066 / Math.Pow(10, 6);
           // double F3 = 10 / Math.Pow(10, 9);
           // Console.WriteLine(F1+","+ F2 + ","+ F3 + ",");
           // double num=F1* Math.Pow(336, 2) + F2* Math.Pow(336, 2) + F3* Math.Pow(336, 2);
           // Console.WriteLine(num);
           // Console.WriteLine(num/2);
           // return;
           // uint[] send = { 0xB2,0xD3, 0xB2, 0xD3 };
           //uint key= seedToKey(send);
           // string strKey = key.ToString("X2");
           // Console.WriteLine("种子== 0xB2,0xD3, 0xB2, 0xD3");
           // string normalizedKeys = string.Join(" ", Regex.Matches(strKey, @"..").Cast<Match>().ToList());
           // Console.WriteLine("解密的密钥 =" + normalizedKeys);
           // return;
           // string str = ">0.00GOhm";


           // string result = Regex.Replace(str, @"[^\d.\d]", "");
           // double asdkfasf = Convert.ToDouble(result);
           // int fasfa = Convert.ToInt32(result);
           // Console.WriteLine(result);
           // string datad= WordToNumber("三");

           // Console.WriteLine("");

           // serialPortTest = new System.IO.Ports.SerialPort();
           // serialPortTest.DataReceived += SerialPortTest_DataReceived;
           // serialPortTest.BaudRate = 19200;
           // serialPortTest.PortName = "COM3";

           //   serialPortTest.Open();
           // while (true)
           // {
           //     asdf = Console.ReadKey().Key.ToString();
           //     Console.WriteLine(asdf);
           // }


            Console.WriteLine();
            DateTime dt2 = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

            Console.WriteLine("Hello World!");
            byte[] buff = new byte[] { 0x01, 0x01, 0x00, 0x00, 0x00, 0x01,0x0C,0x0A };
            string doData = Encoding.Default.GetString(buff);

            //RDD 0,2,0,0.3s,500V,3.228G??
            // str = data.Substring(data.IndexOf('V') + 1, data.Length - (data.IndexOf("G")) - 1).Replace(",", "") + "GΩ";

            // string privateKey = "-----BEGIN PRIVATE KEY-----MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC4E8gB6VSnzqSyOV0cCBiBKuoPOXTgcocj0UWVTGoWMZWsXcUEBO17Q9aKT3U501HJnvQGpuO2 + m9BB3SfqpZf3iNJScYniqs6Ir + AQ1fbajvOw + FXvPRur8V3SC5RWszfl / pQVs0GCPacKzUsMdVSZ3 + bzjVCk / a / nvPTKLion82bw0KHtojf7pdD / 3 / KN3irj8KIuLIOu + 9 /E2w2eeD + vdpwySm20lHr6KvgVtdz4PR / su9VAd62wEBeYyuk7AialxYTw7 / DeclIs1HHRFjq8CB9dkL1u8t0Ts0Hr9O1yozVQZ4OWhISFJjIB4dzCp7pvCAUM60KjWq /eFAG9tdVAgMBAAECggEANytmlHwULT8XyXq71zzt6zirceisiOCKdEeybS671O8DhueLtsqrSnhogoeSAMS / DIihZqT6NssUMQ9E + t2ruAvh04NS6mL7Mq9badvFJzPNvQikLyGouMvhiQCPMT7fjFwGX7HEPPzOvLuOcjJ1Vv9CFbZV7CBgocnIFg9sWM0aNAGBNiC7t5gTazjCvkXMcFzcpftjC252xSRr5xJ7zxJCJkV687xWhStkHsWIh7fv41dEL / 0Rkopvu + 5WVW + kjRAcAvk8bAq + H / z8yeiNUZHF4RpZmwtJ + kWTflrjZOroYUIWqXd3Uzmim3SEBYfv3zJ5v63kkFQq2bZiXEA7 + QKBgQDc1aZFbWCWKitPLJqjqNnlp98ckhoQZa9q8W5Qlay2Ec + 3g + nvklLRbwLW5Gr8yaXQeyYRZIAdQlpo4rouu5CquilKw5FrfAPlxzBhNW16MbBHn6VwuhLqdas70FpHUGTPua / 2aQfd6p3mUCZm37c2FIfjH8mQOn7fqRej + TXNywKBgQDVY7c1drC9c6JzWFLSf5ApBopX4gbOZ / Dic0auXRNNKCBnKSSMXefr3NLxZQAQm0NApfcy38gkJdvreKlZc26T9KXgIFkfyloMIlqaxdnMrxhjtjeyYzeUhWIJ9R670FGSg0F5njQIy + ETvA4Sp8M3hq / cEC4apXRYE5 / h839LXwKBgAO8pcyk9i50VjlHwvIkCFPnjFH6cvB2GArSPRCmB78o +//Z/ppsOnSK0Vx7jwfqDaFChDllHvnfxpHhzE7AI8mPzuUR / CL6fUJlJX9vnQOlVZtQq0cGDw3iodwoQW7VgG83cC / WRSjPMI7WKmAxRvNmU4pXXlzPcJguT1UaAXwTAoGAM7PIZSzP3 + dPmhDxaE0 + GaKbDHYYXhRzGfsCSicFETHCwBwI3fW2xsAnYBOvs1ZbMiPERFBSRufhZClFJwY / 6ZtiQW61CW3W6Y + 9UjjT77MQ / r / cuN0vT04OFgmNG8Z6rTweNiBtzR / Q9h4fbse1FhQNMg29jfk + ukRu / ako05MCgYEAgASD + opwySK + zg5RRAMv75p1IO / Yw / sCn05p0ACAxggwHzbbhCUfMZJTsb7fFMTga2UXz8uMlefA0rK3aBWUlFB + 3TGD9z3zhG7WC9yXnzxTqHIjA7xUMxmPgKCQe0mDjFeWr + yCmWnYWEpyeKC2i0q / etqlaDsZs / jl / wW6UIY =-----END PRIVATE KEY-----";
            string publickey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuBPIAelUp86ksjldHAgYgSrqDzl04HKHI9FFlUxqFjGVrF3FBATte0PWik91OdNRyZ70BqbjtvpvQQd0n6qWX94jSUnGJ4qrOiK / gENX22o7zsPhV7z0bq / Fd0guUVrM35f6UFbNBgj2nCs1LDHVUmd / m841QpP2v57z0yi4qJ / Nm8NCh7aI3 + 6XQ / 9 / yjd4q4 / CiLiyDrvvfxNsNnng/ r3acMkpttJR6 + ir4FbXc + D0f7LvVQHetsBAXmMrpOwImpcWE8O / w3nJSLNRx0RY6vAgfXZC9bvLdE7NB6 / TtcqM1UGeDloSEhSYyAeHcwqe6bwgFDOtCo1qv3hQBvbXVQIDAQAB";
            string privatekey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC4E8gB6VSnzqSyOV0cCBiBKuoPOXTgcocj0UWVTGoWMZWsXcUEBO17Q9aKT3U501HJnvQGpuO2 + m9BB3SfqpZf3iNJScYniqs6Ir + AQ1fbajvOw + FXvPRur8V3SC5RWszfl / pQVs0GCPacKzUsMdVSZ3 + bzjVCk / a / nvPTKLion82bw0KHtojf7pdD / 3 / KN3irj8KIuLIOu + 9 /E2w2eeD + vdpwySm20lHr6KvgVtdz4PR / su9VAd62wEBeYyuk7AialxYTw7 / DeclIs1HHRFjq8CB9dkL1u8t0Ts0Hr9O1yozVQZ4OWhISFJjIB4dzCp7pvCAUM60KjWq /eFAG9tdVAgMBAAECggEANytmlHwULT8XyXq71zzt6zirceisiOCKdEeybS671O8DhueLtsqrSnhogoeSAMS / DIihZqT6NssUMQ9E + t2ruAvh04NS6mL7Mq9badvFJzPNvQikLyGouMvhiQCPMT7fjFwGX7HEPPzOvLuOcjJ1Vv9CFbZV7CBgocnIFg9sWM0aNAGBNiC7t5gTazjCvkXMcFzcpftjC252xSRr5xJ7zxJCJkV687xWhStkHsWIh7fv41dEL / 0Rkopvu + 5WVW + kjRAcAvk8bAq + H / z8yeiNUZHF4RpZmwtJ + kWTflrjZOroYUIWqXd3Uzmim3SEBYfv3zJ5v63kkFQq2bZiXEA7 + QKBgQDc1aZFbWCWKitPLJqjqNnlp98ckhoQZa9q8W5Qlay2Ec + 3g + nvklLRbwLW5Gr8yaXQeyYRZIAdQlpo4rouu5CquilKw5FrfAPlxzBhNW16MbBHn6VwuhLqdas70FpHUGTPua / 2aQfd6p3mUCZm37c2FIfjH8mQOn7fqRej + TXNywKBgQDVY7c1drC9c6JzWFLSf5ApBopX4gbOZ / Dic0auXRNNKCBnKSSMXefr3NLxZQAQm0NApfcy38gkJdvreKlZc26T9KXgIFkfyloMIlqaxdnMrxhjtjeyYzeUhWIJ9R670FGSg0F5njQIy + ETvA4Sp8M3hq / cEC4apXRYE5 / h839LXwKBgAO8pcyk9i50VjlHwvIkCFPnjFH6cvB2GArSPRCmB78o +//Z/ppsOnSK0Vx7jwfqDaFChDllHvnfxpHhzE7AI8mPzuUR / CL6fUJlJX9vnQOlVZtQq0cGDw3iodwoQW7VgG83cC / WRSjPMI7WKmAxRvNmU4pXXlzPcJguT1UaAXwTAoGAM7PIZSzP3 + dPmhDxaE0 + GaKbDHYYXhRzGfsCSicFETHCwBwI3fW2xsAnYBOvs1ZbMiPERFBSRufhZClFJwY / 6ZtiQW61CW3W6Y + 9UjjT77MQ / r / cuN0vT04OFgmNG8Z6rTweNiBtzR / Q9h4fbse1FhQNMg29jfk + ukRu / ako05MCgYEAgASD + opwySK + zg5RRAMv75p1IO / Yw / sCn05p0ACAxggwHzbbhCUfMZJTsb7fFMTga2UXz8uMlefA0rK3aBWUlFB + 3TGD9z3zhG7WC9yXnzxTqHIjA7xUMxmPgKCQe0mDjFeWr + yCmWnYWEpyeKC2i0q / etqlaDsZs / jl / wW6UIY =";
            // string strs = "e80E+HwuKDpW4yM0XiZipz68P7EQnniS/Xry/HaRkIztPmoabTCpmz1E9qNPYywabxp95xuzr0mwm2q92vc5ODL5kQyHqh3dJWFjW8vi2c+kaNveKSQANH4RyDSoFsHA2Dr3+epNlFgZ4rGQ6uW1ErbBgXJ1ZYTnCHyVCZGTzF78Oygb7gOe2EQGCJJTJ5ho2Q/Zjs0ZG5QQ2E+lIWHis/AfbipUs4mxxioHCptmVQiszTw3wVTmZJ9qWJauL+LNxIiN8AzGrGwLOGHacFSDh5HDBY7W6YZT/hF+NpqFRv9miBXfiRZXC5nw9FgZQIf/TCt5yaIuYlkdC7nNy4lcyA==";
            string publickey2xml = RSAPublicKey2xml(publickey);                 //公钥转换成xml格式
            string xml2publickey = RSAxml2PublicKey(publickey2xml);             //xml格式转换为公钥
            string password = Encrypt("tfk123", publickey2xml);                  //公钥加密
            string privatekey2xml = RSAPrivateKey2xml(privatekey);              //公钥转换成xml格式
            string passwords= Decrypt(password, privatekey2xml); //私钥解密
            Console.WriteLine(password);


            double safsdfasdfa = 47;
            // float asdfaaaaa = Convert.ToSingle(safsdfasdfa);
            string dfafdafasd = safsdfasdfa.ToString("0.0");
            //45 DB B3 33
            byte[] bytes = new byte[4];
            //bytes[0] = Convert.ToByte("45", 16);
            //bytes[1] = Convert.ToByte("DB", 16);
            //bytes[2] = Convert.ToByte("B3", 16);
            //bytes[3] = Convert.ToByte("33", 16);
            bytes[0] =0x45;
            bytes[1] =0xDB;
            bytes[2] =0xB3;
            bytes[3] =0x33;
            // float floatValue = BitConverter.ToSingle(bytes, 0);
            // //7000W
            //var ffdsadsfa=  float.Parse("8.375222E-08", System.Globalization.NumberStyles.Float);
            // Printimage();


            //06 04 00 12 00 02 D0 79 读取寄存器值
            //06 04 04 45 DB B3 33 DD 56  读取到的值

            //06 06 00 10 AA AA 77 67
            //06 06 00 10 55 55 76 D7

            //05 06 00 10 AA AA 77 54
            //05 06 00 10 55 55 76 E4
            


            byte[] data = new byte[8];
            byte[] dataIO = new byte[] { 0x01, 0x02, 0x00, 0x00, 0x00, 0x02 };
            byte[] crc = ToModbusCRC(dataIO);
            data[0] = dataIO[0];
            data[1] = dataIO[1];
            data[2] = dataIO[2];
            data[3] = dataIO[3];
            data[4] = dataIO[4];
            data[5] = dataIO[5];
            data[6] = crc[0];
            data[7] = crc[1];
            Console.WriteLine(crc[0]+","+crc[1]);

            return;
            
            try
            {
                serialPortTest=new System.IO.Ports.SerialPort();
                serialPortTest.DataReceived += SerialPortTest_DataReceived;
                serialPortTest.BaudRate = 115200;
                serialPortTest.PortName = "COM3";

              //  serialPortTest.Open();


                serialPortTest1 = new System.IO.Ports.SerialPort();
                serialPortTest1.DataReceived += SerialPortTest_DataReceived1;
                serialPortTest1.BaudRate = 115200;
                serialPortTest1.PortName = "COM4";
                //serialPortTest1.Open();
               // caozuo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static uint  canculate_app_security_access_xxx(uint seed)
        {

            //VCU  0x113289D7
            //BMS  0x1101D43A
            uint tmpseed = seed;
            uint key_1 = tmpseed ^ 0x1101D43A;
            uint seed_2 = tmpseed;
            seed_2 = (seed_2 ^ 0x66666666) << 1 ^ (seed_2 ^ 0xBBBBBBBB) >> 1;
            seed_2 = (seed_2 ^ 0x44444444) << 2 ^ (seed_2 ^ 0xDDDDDDDD) >> 2;
            seed_2 = (seed_2 ^ 0x0F0F0F0F) << 4 ^ (seed_2 ^ 0xF0F0F0F0) >> 4;
            seed_2 = (seed_2 ^ 0x00FF00FF) << 8 ^ (seed_2 ^ 0xFF00FF00) >> 8;
            seed_2 = (seed_2 ^ 0x0000FFFF) << 16 ^ (seed_2 ^ 0xFFFF0000) >> 16;
            uint key_2 = seed_2 & 0x1101D43A;
            uint key = key_1 + key_2;
            return key;
        }
        public static uint Lx_seedToKey(uint wSeed)
        {
            uint MASK = 0x70F27304;
            if (wSeed == 0)
            {
                return wSeed;
            }

            uint tmpseed = wSeed;

            //Step2
            uint key_1 = tmpseed ^ MASK;

            //Step3
            uint seed_2 = tmpseed;
            seed_2 = (seed_2 & 0x55555555) << 1 | (seed_2 & 0xAAAAAAAA) >> 1;
            seed_2 = (seed_2 & 0x33333333) << 2 | (seed_2 & 0xCCCCCCCC) >> 2;
            seed_2 = (seed_2 & 0x0F0F0F0F) << 4 | (seed_2 & 0xF0F0F0F0) >> 4;
            seed_2 = (seed_2 & 0x00FF00FF) << 8 | (seed_2 & 0xFF00FF00) >> 8;
            seed_2 = (seed_2 & 0x0000FFFF) << 16 | (seed_2 & 0xFFFF0000) >> 16;

            uint key_2 = seed_2 ^ MASK;

            uint key = key_1 + key_2;

            return key;
        }
        public static uint seedToKey(uint[] seed)
        {
            uint i;
            uint retLen;
            uint key = 0;
            uint MASK = 0x08DCF908;
            /* The array for SEED starts with [1], the array for KEY starts with [0] */
            /* seed contains the SEED from the ECU */
            /* length contains the number of bytes of seed */
            /* key contains the KEY to send to ECU */
            /* retLen contains the number of bytes to send to ECU as key */
            if (seed[0] == 0 && seed[1] == 0)
                retLen = 0;
            else
            {
                key = ((uint)seed[0] << 24) + ((uint)seed[1] << 16) + ((uint)seed[2] << 8) + (uint)seed[3];
                for (i = 0; i < 35; i++)
                {
                    if ((key & 0x80000000) != 0)
                    {
                        key = key << 1;
                        key = key ^ MASK;
                    }
                    else
                    {
                        key = key << 1;
                    }
                }


            }
            return key;
        }
        public static string WordToNumber(string word)
        {
            string e = "([零一二三四五六七八九十百千万亿])+";
            MatchCollection mc = Regex.Matches(word, e);

            foreach (Match m in mc)
            {
                word = word.Replace(m.Value, Word2Number(m.Value));
            }
            return word;
        }

        private static string Word2Number(string w)
       {
           if(w == "")
               return w;

           string e = "零一二三四五六七八九";
           string[] ew = new string[] { "十", "百", "千" };
           string ewJoin = "十百千";
           string[] ej = new string[] { "万", "亿" };

           string rss = "^([" + e + ewJoin + "]+" + ej[1] + ")?([" + e
               + ewJoin + "]+" +ej[0] + ")?([" + e + ewJoin + "]+)?$";
           string[] mcollect = Regex.Split(w, rss);
           if(mcollect.Length< 4)
               return w;
           return (
               Convert.ToInt64(foh(mcollect[1])) * 100000000 +
               Convert.ToInt64(foh(mcollect[2])) * 10000 +
            Convert.ToInt64(foh(mcollect[3]))
               ).ToString();
       }
        private static int foh(string str)
    {
        string e = "零一二三四五六七八九";
        string[] ew = new string[] { "十", "百", "千" };
        string[] ej = new string[] { "万", "亿" };

        int a = 0;
        if(str.IndexOf(ew[0]) == 0)
            a = 10;
        str = Regex.Replace(str, e[0].ToString(), "");

        if(Regex.IsMatch(str, "([" + e + "])$"))
        {
            a += e.IndexOf(Regex.Match(str, "([" + e + "])$").Value[0]);
        }

        if(Regex.IsMatch(str, "([" + e + "])" + ew[0]))
        {
            a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[0]).Value[0]) * 10;
        }

        if (Regex.IsMatch(str, "([" + e + "])" + ew[1]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[1]).Value[0]) * 100;
            }

        if (Regex.IsMatch(str, "([" + e + "])" + ew[2]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[2]).Value[0]) * 1000;
            }
        return a;
    }

    static string RSAPublicKey2xml(string publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        static string RSAxml2PublicKey(string publickey2xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publickey2xml);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            RsaKeyParameters pub = new RsaKeyParameters(false, m, p);
            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pub);
            byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
            return Convert.ToBase64String(serializedPublicBytes);
        }

        static string Encrypt(string content, string key)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(key);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
            return Convert.ToBase64String(cipherbytes);
        }

        static string RSAPrivateKey2xml(string privateKey)
        {
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        static string RSAxml2PrivateKey(string privatekey2xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(privatekey2xml);
            BigInteger m = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Modulus")[0].InnerText));
            BigInteger exp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Exponent")[0].InnerText));
            BigInteger d = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("D")[0].InnerText));
            BigInteger p = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("P")[0].InnerText));
            BigInteger q = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("Q")[0].InnerText));
            BigInteger dp = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DP")[0].InnerText));
            BigInteger dq = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("DQ")[0].InnerText));
            BigInteger qinv = new BigInteger(1, Convert.FromBase64String(doc.DocumentElement.GetElementsByTagName("InverseQ")[0].InnerText));
            RsaPrivateCrtKeyParameters privateKeyParam = new RsaPrivateCrtKeyParameters(m, exp, d, p, q, dp, dq, qinv);
            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParam);
            byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetEncoded();
            return Convert.ToBase64String(serializedPrivateBytes);
        }

        static string Decrypt(string content, string key)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(key);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
            return Encoding.UTF8.GetString(cipherbytes);
        }

        static string AnkuiData = string.Empty;
        public static float  ScientificToFloat(int [] datas) 
        {
            int data = datas[0] << 24 | datas[1] << 16 | datas[2] << 8 | datas[3];

            int nSign;
            if ((data & 0x80000000) > 0)
            {
                nSign = -1;
            }
            else
            {
                nSign = 1;
            }
            int nExp = data & (0x7F800000);
            nExp = nExp >> 23;
            float nMantissa = data & (0x7FFFFF);

            if (nMantissa != 0)
                nMantissa = 1 + nMantissa / 8388608;

            float value= nSign * nMantissa * (2 << (nExp - 128));
            return value;
        }
        public static void Printimage() 
        {
            
               Bitmap bit = new Bitmap(200, 200);
            Graphics g = Graphics.FromImage(bit);

            g.DrawString("          整车负载绝缘电阻检测", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
           g.DrawString("耐压检测仪        组装二线1工位", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));
            
            //else if (Convert.ToInt32(ConfigurationManager.AppSettings["Station_ID"]) == 2)
            //{
            //    e.Graphics.DrawString("          电位均衡检测2", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
            //    e.Graphics.DrawString("日置检测仪        组装二线1工位", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));

            //}
            //else if (Convert.ToInt32(ConfigurationManager.AppSettings["Station_ID"]) == 1)
            //{
            //    e.Graphics.DrawString("          电位均衡检测1", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
            //    e.Graphics.DrawString("日置检测仪        底盘二线13工位左侧", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));
            //}

            g.DrawString("--------------------------------", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 50));
            g.DrawString("日期时间：" + DateTime.Now, new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 70));
            g.DrawString("VIN：" + "VIN1234567890ABCD", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 90));
            g.DrawString("*********************************", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 110));
           g.DrawString("序号   名称        阻值   标准  合格", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 140));
            int i = 1;
            string str = "";
            List<listsen> listsens = new List<listsen>();
            listsens.Add(new listsen 
            {
                state="1",
                descName="直流充电口检测",
                parameter_value="30MΩ",
                range_value= ">10MΩ"
            });
            foreach (var item in listsens)
            {
                string nok = item.state == "1" ? "√" : "×";
                string descName = item.descName;
                // string parvalue = item.parameter_value.Length > 4 ? item.parameter_value.Substring(0, 4) : item.parameter_value;
                str = i.ToString() + "   " + descName + "     " + item.parameter_value + "  " + item.range_value + "    " + nok;

                if (item.state == "0")
                {
                    g.DrawString(str, new Font("宋体", 10), new SolidBrush(Color.Red), new PointF(0, 140 + i * 20));
                }
                else
                {
                    g.DrawString(str, new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 140 + i * 20));
                }
                i++;
            }

            bit.Save("G:\\Manager\\CCAG\\Safety_BD\\doc\\111.jpeg");
        }
        private static void SerialPortTest_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            AnkuiData+= serialPortTest1.ReadExisting();
            if (AnkuiData.Length==11)
            {
                Decimal data = ChangeDataToD(AnkuiData);
                Console.WriteLine(data);
                AnkuiData = "";
            }
            

        }
        private static void SerialPortTest_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int len = serialPortTest.BytesToRead;
            if (len>0)
            {
                byte[] buff = new byte[len];
                serialPortTest.Read(buff, 0, len);
                string sb = "";
               
                if (buff[1]!=0x04)
                {
                    return;
                }
                foreach (var item in buff)
                {
                    sb += (Convert.ToString(item, 16)).PadLeft(2, '0') + " ";
                }
                Console.WriteLine(sb);
                byte[] dataIO1 = new byte[] { 0x06, 0x04, 0x04, 0x045, 0x0B, 0xB3, 0x33, 0xDD, 0x56 };
                byte[] dataIO2 = new byte[] { 0x06, 0x04, 0x04, 0x00, 0x00, 0x00, 0x01, 0xDD, 0x56 };
                if (asdf.Contains("0"))
                {
                    serialPortTest.Write(dataIO2, 0, dataIO2.Length);
                }
                else
                {
                    serialPortTest.Write(dataIO1, 0, dataIO1.Length);
                }
            }
           
           

           // Console.WriteLine(barcode);
        }
        static bool Isopen = true;
        public static void caozuo() 
        {
            string str =Console.ReadLine();
            if (str == "true")
            {
                Isopen = true;
            }
            else if (str=="start")
            {
                serialPortTest1.Write("READ?"+"\r\n");
            }
            else if (str == "false") 
            { Isopen = false;}
            else
            {
                int val = Convert.ToInt32(str);
                byte[] data = new byte[8];
                byte[] dataIO = new byte[] { 0x01, 0x05, 0x00, 0x00, 0xFF, 0x00 };
                if (!Isopen)
                {
                    dataIO[4] = 0x00;
                }
                dataIO[3] = (byte)val;
                byte[] crc = ToModbusCRC(dataIO);
                data[0] = dataIO[0];
                data[1] = dataIO[1];
                data[2] = dataIO[2];
                data[3] = dataIO[3];
                data[4] = dataIO[4];
                data[5] = dataIO[5];
                data[6] = crc[0];
                data[7] = crc[1];
                serialPortTest.Write(data, 0, data.Length);
            }
            

            
            caozuo();
        }


        public static Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }

        public static byte[] ToModbusCRC(byte[] byteData)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteData.Length; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;

        }
    }
      class listsen 
    {
        public string state { get; set; }
        public string descName { get; set; }
        public string parameter_value { get; set; }

        public string range_value { get; set; }
    }
}
