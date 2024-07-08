
using DapperProject.Dtos.AgentDtos;

namespace DapperProject.Services.AgentServices
{
    public interface IAgentService
	{
		Task<List<AgentDtos>> GetAllAgentsAsync();
		Task<int> GetAgentCount();
	}
}
