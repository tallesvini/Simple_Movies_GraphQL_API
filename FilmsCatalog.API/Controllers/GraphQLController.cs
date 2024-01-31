using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using FilmsCatalog.Utilities;

namespace FilmsCatalog.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GraphQLController : ControllerBase
	{
		private readonly IDocumentExecuter _documentExecuter;
		private readonly ISchema _schema;

		public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
		{
			_schema = schema;
			_documentExecuter = documentExecuter;
		}

		[HttpPost]
		public async Task<IActionResult> Post(GraphQLQuery query)
		{
			if (query == null) throw new ArgumentNullException(nameof(query));
			
			var inputs = query.Variables.ToInputs();
			var executionOptions = new ExecutionOptions
			{
				Schema = _schema,
				Query = query.Query,
				Inputs = inputs
			};

			var result = await _documentExecuter.ExecuteAsync(executionOptions);

			if (result.Errors?.Count > 0) throw new Exception(result.Errors.ToString());
			
			return Ok(result);
		}
	}
}
