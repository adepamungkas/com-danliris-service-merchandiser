﻿using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage
{
    public interface IAzureStorageService
    {
        CloudBlobContainer GetStorageContainer();
    }
}