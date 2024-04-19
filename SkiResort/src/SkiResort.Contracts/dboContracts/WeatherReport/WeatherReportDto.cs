using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.WeatherReport;

public class WeatherReportDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public required string WeatherCondition { get; set; }
    public int Temperature { get; set; }
}
