using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.WeatherReport;

public class CreateWeatherReportDto
{
    public DateTime Date { get; set; }
    public required string WeatherCondition { get; set; }
    public int Temperature { get; set; }
}
