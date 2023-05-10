using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H23_DevInfo_IntroTests.Tests
{
    public class DateServicePourLesTests : IDateService
    {
        public DateTime ObtenirDateCourante()
        {
            return new DateTime(2023, 05, 11);
        }
    }
}
