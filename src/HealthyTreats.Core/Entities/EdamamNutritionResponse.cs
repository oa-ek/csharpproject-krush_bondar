using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
	public class EdamamNutritionResponse
	{
		public string uri { get; set; }
		public string yield { get; set; }
		public string calories { get; set; }
		public string totalWeight { get; set; }
		public string dietLabels { get; set; }
		public string healthLabels { get; set; }
		// Добавьте другие свойства, если они есть в JSON-ответе
	}
}
