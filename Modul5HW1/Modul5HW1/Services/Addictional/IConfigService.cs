using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul5HW1.Models.DTO;
using Modul5HW1.Configurations;
using Modul5HW1.Services.Addictional;

namespace Modul5HW1.Services.Addictional
{
    public interface IConfigService
    {
        ConfigURL? ConfigDeserialize();
        void ConfigSerialize(object? config, string fileName);
    }
}
