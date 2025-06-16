using kolokwium2.DTOs;
using kolokwium2.Exceptions;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IDbService _dbService;

    public CustomerController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    
}