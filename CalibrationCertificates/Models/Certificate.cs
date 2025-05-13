using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificates.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int StandardId { get; set; }
        public int CalibratorId { get; set; }
        public int ChiefMetrologistId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double Voltage { get; set; }
        public DateTime CalibrationDate { get; set; }
    }
}
