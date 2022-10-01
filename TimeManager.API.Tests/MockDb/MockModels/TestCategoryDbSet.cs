using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.API.Data;

namespace TimeManager.API.Tests
{
    public class TestCategoryDbSet : TestDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            return this.SingleOrDefault(category => category.Id == (int)keyValues.Single());
        }
    }
}
