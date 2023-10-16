using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SafetyTesting.DB.Interface;
using SafetyTesting.DB.Entity;
using System.Linq;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;

namespace SafetyTesting
{
    public partial class LoginForm : Form
    {
        private readonly ISafetyDataRepository safetyDataRepository;
        public int Level=0;
        public string UserName=string.Empty;
        public LoginForm(ISafetyDataRepository _safetyDataRepository)
        {
            InitializeComponent();

            safetyDataRepository = _safetyDataRepository;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        #region 窗口拖动
        private Point mouseLocation;
        private bool isDragging;
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                mouseLocation = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newMouselocation = MousePosition;
                newMouselocation.Offset(mouseLocation.X, mouseLocation.Y);
                Location = newMouselocation;
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
            }
        }
        #endregion


        private void textBox_username_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox_username_Enter(object sender, EventArgs e)
        {
            textBox_username.Text = "";
        }

        private void textBox_username_Leave(object sender, EventArgs e)
        {
            if (textBox_username.Text == "")
            {
                textBox_username.Text = "JMEV";
            }
        }

        private void textBox_password_Enter(object sender, EventArgs e)
        {
            textBox_password.Text = "";
        }

        private void textBox_password_Leave(object sender, EventArgs e)
        {
            if (textBox_password.Text == "")
            {
                textBox_password.Text = "Password";
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string password = string.Empty;
            if (textBox_username.Text=="Admin")
            {
                User users = safetyDataRepository.GetData<User>().Where(x => x.UserName == textBox_username.Text).FirstOrDefault();
                string privatekey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC4E8gB6VSnzqSyOV0cCBiBKuoPOXTgcocj0UWVTGoWMZWsXcUEBO17Q9aKT3U501HJnvQGpuO2 + m9BB3SfqpZf3iNJScYniqs6Ir + AQ1fbajvOw + FXvPRur8V3SC5RWszfl / pQVs0GCPacKzUsMdVSZ3 + bzjVCk / a / nvPTKLion82bw0KHtojf7pdD / 3 / KN3irj8KIuLIOu + 9 /E2w2eeD + vdpwySm20lHr6KvgVtdz4PR / su9VAd62wEBeYyuk7AialxYTw7 / DeclIs1HHRFjq8CB9dkL1u8t0Ts0Hr9O1yozVQZ4OWhISFJjIB4dzCp7pvCAUM60KjWq /eFAG9tdVAgMBAAECggEANytmlHwULT8XyXq71zzt6zirceisiOCKdEeybS671O8DhueLtsqrSnhogoeSAMS / DIihZqT6NssUMQ9E + t2ruAvh04NS6mL7Mq9badvFJzPNvQikLyGouMvhiQCPMT7fjFwGX7HEPPzOvLuOcjJ1Vv9CFbZV7CBgocnIFg9sWM0aNAGBNiC7t5gTazjCvkXMcFzcpftjC252xSRr5xJ7zxJCJkV687xWhStkHsWIh7fv41dEL / 0Rkopvu + 5WVW + kjRAcAvk8bAq + H / z8yeiNUZHF4RpZmwtJ + kWTflrjZOroYUIWqXd3Uzmim3SEBYfv3zJ5v63kkFQq2bZiXEA7 + QKBgQDc1aZFbWCWKitPLJqjqNnlp98ckhoQZa9q8W5Qlay2Ec + 3g + nvklLRbwLW5Gr8yaXQeyYRZIAdQlpo4rouu5CquilKw5FrfAPlxzBhNW16MbBHn6VwuhLqdas70FpHUGTPua / 2aQfd6p3mUCZm37c2FIfjH8mQOn7fqRej + TXNywKBgQDVY7c1drC9c6JzWFLSf5ApBopX4gbOZ / Dic0auXRNNKCBnKSSMXefr3NLxZQAQm0NApfcy38gkJdvreKlZc26T9KXgIFkfyloMIlqaxdnMrxhjtjeyYzeUhWIJ9R670FGSg0F5njQIy + ETvA4Sp8M3hq / cEC4apXRYE5 / h839LXwKBgAO8pcyk9i50VjlHwvIkCFPnjFH6cvB2GArSPRCmB78o +//Z/ppsOnSK0Vx7jwfqDaFChDllHvnfxpHhzE7AI8mPzuUR / CL6fUJlJX9vnQOlVZtQq0cGDw3iodwoQW7VgG83cC / WRSjPMI7WKmAxRvNmU4pXXlzPcJguT1UaAXwTAoGAM7PIZSzP3 + dPmhDxaE0 + GaKbDHYYXhRzGfsCSicFETHCwBwI3fW2xsAnYBOvs1ZbMiPERFBSRufhZClFJwY / 6ZtiQW61CW3W6Y + 9UjjT77MQ / r / cuN0vT04OFgmNG8Z6rTweNiBtzR / Q9h4fbse1FhQNMg29jfk + ukRu / ako05MCgYEAgASD + opwySK + zg5RRAMv75p1IO / Yw / sCn05p0ACAxggwHzbbhCUfMZJTsb7fFMTga2UXz8uMlefA0rK3aBWUlFB + 3TGD9z3zhG7WC9yXnzxTqHIjA7xUMxmPgKCQe0mDjFeWr + yCmWnYWEpyeKC2i0q / etqlaDsZs / jl / wW6UIY =";
                if (users!=null)
                {
                    string privatekey2xml = RSAPrivateKey2xml(privatekey);              //公钥转换成xml格式
                    string passwords = Decrypt(users.UserPassword, privatekey2xml); //私钥解密

                    if (passwords!=textBox_password.Text)
                    {
                        MessageBox.Show("账号密码错误");
                        return;
                    }
                    Level = users.level;
                    UserName = users.UserName;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }

                return;
            }
           User user=  safetyDataRepository.GetData<User>().Where(x=>x.UserName==textBox_username.Text && x.UserPassword==textBox_password.Text).FirstOrDefault();
            if (user==null)
            {
                MessageBox.Show("账号密码错误");
                return;
            }
            Level = user.level;
            UserName=user.UserName;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                button_login_Click(null, null);
            }
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
        static string Decrypt(string content, string key)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(key);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
            return Encoding.UTF8.GetString(cipherbytes);
        }

    }
}
