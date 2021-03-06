﻿using NetoDotNET.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetoDotNET.Entities
{
    public class Item : ItemBase
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Image>))]
        public List<Image> Images { get; set; }
    }
}
