﻿using System;

namespace Stranne.VasttrafikNET.Models
{
    internal class Token
    {
        private DateTime _createDate = DateTime.Now;

        public string Scope { get; set; }

        public string Token_Type { get; set; }

        public int Expires_In { get; set; }

        public string Refresh_Token { get; set; }

        public string Access_Token { get; set; }
        
        public bool IsValid() => _createDate.AddSeconds(Expires_In) < DateTime.Now;
    }
}