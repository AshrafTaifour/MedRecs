using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoginPageTest
{
    [TestClass]
    public class UnitTest1 //to test if HEALTHCAREPERSONNEL can login
    {
        HEALTHCARE_PERSONNEL userData = new HEALTHCARE_PERSONNEL();
        string inputName, inputPassword;
        int actualUserId;

        [TestMethod]
        public void TestMethod1()
        {
            //declare value of test inputs
            inputName = "John"; //inputname is fname
            inputPassword = "jd123456";

            //specify value of expected outputs
            Boolean expectedReturn = true;
            int expectedUserId = 1;

            //call method to obtain actual outputs
            Boolean actualReturn = userData.Login(inputName, inputPassword);
            actualUserId = userData.empid;
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
    }
}
