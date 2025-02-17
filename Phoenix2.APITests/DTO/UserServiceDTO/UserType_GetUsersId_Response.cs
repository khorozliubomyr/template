﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class UserType_GetUsersId_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}
