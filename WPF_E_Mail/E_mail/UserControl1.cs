using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace E_mail
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = "smtp.163.com";// 邮件服务器smtp.163.com表示网易邮箱服务器    
            string userName = "q273404452@163.com";// 发送端账号   
            string password = "q123456";// 发送端密码(这个客户端重置后的密码)




            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式    
            client.Host = host;//邮件服务器
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(userName, password);//用户名、密码

            //////////////////////////////////////
            string strfrom = userName;
            string strto = "273404452@qq.com";
            string strcc = "2404259360@qq.com";//抄送


            string subject = "这是测试邮件标题";//邮件的主题             
            string body = "测试邮件内容";//发送的邮件正文  

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress(strfrom, "hedrich");
            msg.To.Add(strto);
            msg.CC.Add(strcc);

            msg.Subject = subject;//邮件标题   
            msg.Body = body;//邮件内容   
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
            msg.IsBodyHtml = true;//是否是HTML邮件   
            msg.Priority = MailPriority.High;//邮件优先级   


            try
            {
                //MessageBox.Show("开始发送");
                client.Send(msg);
                Console.WriteLine("发送成功");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message, "发送邮件出错");
            }
        }    
    }
   
}
