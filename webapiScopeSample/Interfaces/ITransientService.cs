﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiScopeSample.interfaces
{
    public interface ITransientService
    {
        Guid GetOperationID();
    }
}
