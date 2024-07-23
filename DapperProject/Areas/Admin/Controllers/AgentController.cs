using DapperProject.Dtos.AgentDtos;
using DapperProject.Dtos.CategoryDtos;
using DapperProject.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AgentController : Controller
	{
		private readonly IAgentService _agentService;

		public AgentController(IAgentService agentService)
		{
			_agentService = agentService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _agentService.GetAllAgentsAsync();
			return View(values);
		}

        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentDto createAgentDto)
        {
            await _agentService.CreateAgentAsync(createAgentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAgent(int id)
        {
            var value = await _agentService.GetByIdAgentAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAgent(UpdateAgentDto updateAgentDto)
        {
            await _agentService.UpdateAgentAsync(updateAgentDto);
            return RedirectToAction("Index");
        }
    }
}
