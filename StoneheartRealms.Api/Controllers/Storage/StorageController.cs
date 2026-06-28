using Microsoft.AspNetCore.Mvc;
using StoneheartRealms.Data.Constants;
using StoneheartRealms.Services.DTOs.StorageResources;
using StoneheartRealms.Services.Services.StorageManager;

namespace StoneheartRealms.Api.Controllers.Storage;

[ApiController]
[Route("api/storage")]

public class StorageController(IStorageService storageService) : ControllerBase
{
    private readonly IStorageService _storageService = storageService;
    
    [HttpGet]
    public async Task<IEnumerable<ResourceDto?>> GetResources()
    {
        return await _storageService.GetResources(StorageTypeIds.MainStorage);
    }
}