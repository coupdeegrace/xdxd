using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Converters;


namespace xdxd
{
        public class Users
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string[] Firends { get; set; }
        }
}
