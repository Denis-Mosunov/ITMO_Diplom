namespace CalibrationCertificates.Models
{
    public class CalibrationData
    {
        public int Id { get; set; }
        public int Periodicity { get; set; }               // Периодичность (месяцы)
        public int Department { get; set; }                // Номер отдела
        public string CertificateNumber { get; set; }      // Номер сертификата
        public string FactoryNumber { get; set; }          // Заводской номер
        public string InventoryNumber { get; set; }        // Инвентарный номер
        public string CalibrationDocument { get; set; }    // Документ калибровки
        public string Standards { get; set; }              // Эталоны
        public string Factors { get; set; }                // Влияющие факторы
        public string ChiefMetrologist { get; set; }        // Главный метролог
        public string Calibrator { get; set; }              // Калибровщик
        public DateTime CalibrationDate { get; set; }       // Дата калибровки
    }
}
