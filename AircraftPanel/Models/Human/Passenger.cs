using System.ComponentModel;
using Models.ModelsValidator;

namespace Models.Human
{
    public class Passenger : Person, IDataErrorInfo {
		public string Error { get; set; }

		public string this[string columnName]
		{
			get
			{
				if (validator == null)
				{
					validator = new PassengerValidator();
				}
				var firstOrDefault = validator.Validate(this)
					.Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
				return firstOrDefault?.ErrorMessage;
			}
		}

		private PassengerValidator validator { get; set; }


	}
}
