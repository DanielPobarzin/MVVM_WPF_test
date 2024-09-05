using Models.Human;
using Models.ModelsValidator;
using System.ComponentModel;

namespace Models.Travelling
{
    public class Flight : Travelling, IDataErrorInfo
	{
		public string Error { get; set; }

		public string this[string columnName]
		{
			get
			{
				if (validator == null)
				{
					validator = new FlightValidator();
				}
				var firstOrDefault = validator.Validate(this)
					.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
				return firstOrDefault?.ErrorMessage;
			}
		}

		private FlightValidator validator { get; set; }
	}
}
