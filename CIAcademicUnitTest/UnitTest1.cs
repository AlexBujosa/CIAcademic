namespace CIAcademicUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogIn1()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000000;
            string password = "A28CJFHD";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsFalse(rtn); 
        }
        [TestMethod]
        public void TestLogIn2()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000000;
            string password = "Ab28CJsh";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestLogIn3()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000000;
            string password = "Alex12345";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsFalse(rtn);
        }
        [TestMethod]
        public void TestLogIn4()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000000;
            string password = "AJ28bcVBJ";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestLogIn5()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000002;
            string password = "SeBas12345";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestLogIn6()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            int id = 1000003;
            string password = "FernanD12345";
            bool rtn = val.ValidatePassword(password) && val.ValidateId(id);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestInsertUser1()
        {
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            //Email, nombre, apellido y contrase;a corecto se espera respuesta true
            string name = "Alex Jose";
            string lastName = "Bujosa Cruz";
            string email = "bujosa2012@gmail.com";
            string password = "BJ28CjhDD";
            bool rtn = val.ValidatePassword(password) && val.ValidateEmail(email) 
                    && val.ValidateNameOrLastName(name) && val.ValidateNameOrLastName(lastName);
            Assert.IsTrue(rtn);
        }
        [TestMethod]
        public void TestInsertUser2()
        {
            //Email incorrecto pues lo que se espera es ua respuesta false
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            string name = "Alex Jose";
            string lastName = "Bujosa Cruz";
            string email = "bujosa@gmail.con";
            string password = "BJ28CjhDD";
            bool rtn = val.ValidatePassword(password) && val.ValidateEmail(email)
                    && val.ValidateNameOrLastName(name) && val.ValidateNameOrLastName(lastName);
            Assert.IsFalse(rtn);
        }
        [TestMethod]
        public void TestInsertUser3()
        {
            //Apellido incorrecto pues lo que se espera es ua respuesta false, ademas de que un apellido no puede ser una sola letra, como minimo 3
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            string name = "Alex Jose";
            string lastName = "Bujosa C";
            string email = "bujosa@gmail.con";
            string password = "BJ28CjhDD";
            bool rtn = val.ValidatePassword(password) && val.ValidateEmail(email)
                    && val.ValidateNameOrLastName(name) && val.ValidateNameOrLastName(lastName);
            Assert.IsFalse(rtn);
        }
        [TestMethod]
        public void TestInsertUser4()
        {
            //Respuesa correcta 
            CIAcademicApp.BusinessLayer.Validation val = new CIAcademicApp.BusinessLayer.Validation();
            string name = "William Emil";
            string lastName = "Sam Diaz";
            string email = "williamsam123@hotmail.com";
            string password = "WIlly123";
            bool rtn = val.ValidatePassword(password) && val.ValidateEmail(email)
                    && val.ValidateNameOrLastName(name) && val.ValidateNameOrLastName(lastName);
            Assert.IsTrue(rtn);
        }

    }
}