using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificacionesTest;
using NotificacionesTest.Models;
using System;

namespace otificacionesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnvioCorreoMinimoOK()
        {
            MailService.SendMail(new Mail()
            {
                Title = "Prueba minima",
                Body = "test ",
                To = "rodrigo.vidal@humansite.com.mx"
            });

        }


        [TestMethod]
        public void VerificarHostInexistente()
        {
            try
            {
                MailService.SendMail(new Mail()
                {
                    Title = "Prueba minima",
                    Body = "test ",
                    To = "rodrigo.vidal@humansite.com.mx",
                    Host = "hosthosthost.gasdsadasds.com.notexist"

                });
                Assert.AreEqual("", "aqui no llega 35 ");
            }
            catch (Exception ex)
            {

                Console.WriteLine("**************" + ex);
                Assert.IsTrue(ex.Message.Contains("Failure sending mail"));
            }


        }

        [TestMethod]
        public void EnvioCorreoBadRequest()
        {
            try
            {
                MailService.SendMail(new Mail()
                {
                    Title = "error"
                });
                Assert.AreEqual("", "aqui no llega ");
            }

            catch (Exception ex)
            {
                Console.WriteLine("*********" + ex.Message);
                Assert.IsTrue(ex.Message.Contains("cannot be null"));

            }
        }

        [TestMethod]
        public void EnvioCorreoConfigSMTTP()
        {
            try
            {
                MailService.SendMail(new Mail()
                {
                    Title = "error",
                    BCC = new string[] { },
                    CC = new string[] { },
                    Body = "body",
                    From = "kyagamypump1@gmail.com",
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DefaultCredentiasl = false,
                    To = "rodrigo.vidal@humansite.com.mx",
                    UseSSL = true

                });
            }

            catch (Exception ex)
            {
                Console.WriteLine("*********" + ex.Message);
                Assert.AreEqual("", "aqui no llega ");
            }
        }





    }
}
