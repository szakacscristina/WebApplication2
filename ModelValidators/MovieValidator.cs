using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApplication2.Models;

namespace WebApplication2.ModelValidators
{
		public class MovieValidator : AbstractValidator<Movie>
		{
			public MovieValidator()
			{
			RuleFor(x => x.YearOfRelease).InclusiveBetween(1990, 2020);

			RuleFor(x => x.DateAdded).LessThan(DateTime.Now);

			RuleFor(x => x.Title).Length(1, 10);

		}
		}
	}

