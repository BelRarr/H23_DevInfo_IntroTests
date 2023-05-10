using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H23_DevInfo_IntroTests
{
    public class DateService : IDateService
    {
        public DateTime ObtenirDateCourante()
        {
            return DateTime.Now;
        }
    }
}
