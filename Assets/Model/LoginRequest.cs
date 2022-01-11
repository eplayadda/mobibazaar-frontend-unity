using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mb.Model
{
    public class LoginRequest
    {
        public string mob_number { get; set; }
        public string password { get; set; }
    }
    public class LoginResponse
    {
        public string mob_number { get; set; }
        public string password { get; set; }
        public string access_token { get; set; }
    }
}

