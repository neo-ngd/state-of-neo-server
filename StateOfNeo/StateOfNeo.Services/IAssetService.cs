﻿using StateOfNeo.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateOfNeo.Services
{
    public interface IAssetService
    {
        Asset Find(string hash);
    }
}
