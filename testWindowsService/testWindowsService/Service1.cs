using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net.Mail;

namespace testWindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer1 = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 3000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            Library.WriteErrorLog("Test windows service started");
        }

        private void timer1_Tick(object sender,ElapsedEventArgs e)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("dharani.ameex@gmail.com", "Google admin");
            message.To.Add("autoemailtesting44@gmail.com");
            message.Subject = "Mail test";
            message.Body = "Testing";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("dharubtech22@gmail.com", "venusree");
            smtp.EnableSsl = true;
            smtp.Send(message);
     }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.WriteErrorLog("Test windows service stopped");
        }
    }
}
