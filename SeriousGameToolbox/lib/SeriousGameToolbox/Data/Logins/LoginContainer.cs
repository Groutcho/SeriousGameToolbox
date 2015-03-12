using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Logins
{
    public class LoginContainer
    {
        private IEnumerable<Login> logins;
        public IEnumerable<Login> Logins { get { return logins; } }

        public LoginContainer()
        {
            logins = new List<Login>(0);
        }

        public LoginContainer(IEnumerable<Login> logins)
        {
            if (logins == null)
            {
                throw new ArgumentNullException("logins");
            }

            this.logins = logins;
        }
    }
}
