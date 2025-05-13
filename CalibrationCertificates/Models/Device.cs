using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificates.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string FactoryNumber { get; set; }
        public string InventoryNumber { get; set; }
        public int Periodicity { get; set; }
        public string DocumentName { get; set; }
        public int Department { get; set; }
    }
}
