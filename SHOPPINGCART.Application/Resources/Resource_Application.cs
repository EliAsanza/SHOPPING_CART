using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
namespace SHOPPINGCART.Application.Resources
{
    public class Resource_Application //PARA ENVIAR CORREO PARA LA CONTRASEÑA AL USUARIO AUTOMATICAMENTE.
    {
        public static string GeneratedPassword()  //Permite hacer una clave autogenerada
        {
            string password=Guid.NewGuid().ToString("N").Substring(0, 8);
            return password;
        }

        // Encriptación de Texto en SHA256
        public static string ConvertSha256(string text)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 sha = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = sha.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            }
        }

        public static bool SendEmail(string email, string subject, string menssage)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage(); //cuerpo del mensaje
                mail.To.Add(email);
                mail.From = new MailAddress("charito106sebas@gmail.com");
                mail.Subject = subject;
                mail.Body = menssage;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient() //servidor cliente, que se encraga de enviar el email
                {
                    Credentials = new NetworkCredential("charito106sebas@gmail.com", "mlbugejenphjmwvk"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true, // certificado de seguridad
                };
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
