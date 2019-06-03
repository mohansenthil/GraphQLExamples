using System;
using System.Linq;
using System.Threading.Tasks;
using BigBlueClothingFactory.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigBlueClothingFactory
{
    [Route("[Controller]")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if(query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables?.ToInputs();

            var executioOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,             
                Inputs = inputs,
                OperationName = query.OperationName
                

            };

            var result = await _documentExecuter.ExecuteAsync(executioOptions);

            if(result.Errors?.Any() == true)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
