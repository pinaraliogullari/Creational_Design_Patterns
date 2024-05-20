using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Singleton_Design_Pattern_AspNetCore_Pratic.Services;

namespace Singleton_Design_Pattern_AspNetCore_Pratic.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		[HttpGet("[action]")]
		public IActionResult X()
		{
			DatabaseService databaseService = DatabaseService.GetInstance;
			databaseService.Connection();
			databaseService.Disconnect();
			return Ok(databaseService.Count);
		}

		[HttpGet("[action]")]
		public IActionResult Y()
		{
			DatabaseService databaseService = DatabaseService.GetInstance;
			databaseService.Connection();
			databaseService.Disconnect();
			return Ok(databaseService.Count);
		}
	}
}
