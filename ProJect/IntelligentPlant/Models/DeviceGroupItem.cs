using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentPlant.Models
{
    class DeviceGroupItem
    {
        public string Image { get; set; }

        public List<DeviceItems> devices { get; set; }
    }
}
