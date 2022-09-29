using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.API.Data;

namespace TimeManager.API.Tests
{
    public class TestActivityDbSet : TestDbSet<Activity>
    {
        public override Activity Find(params object[] keyValues)
        {
            return this.SingleOrDefault(activity => activity.Id == (int)keyValues.Single());
        }
    }
}
