using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Infastructure.Logging;
using Infastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities.Extention;
using ApplicationCore.Interfaces;

namespace MySecondWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : BaseApiController
    {

        private ILoggerManager _logger;
        // private IOwnerRepository _ownerRepository;
        private IRepositoryWrapper _repository;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository)
        {

            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database.");
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                // return StatusCode(500, "Internal server error");
                return await HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);

                if (owner.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                // return StatusCode(500, "Internal server error");
                return await HandleException(ex);
            }
        }


        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetailsAsync(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetails(id);

                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                // return StatusCode(500, "Internal server error");
                return await HandleException(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateOwnerAsync([FromBody]Owner owner)
        {
            try
            {
                if (owner.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Owner.CreateOwner(owner);
                _repository.Save();

                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                // return StatusCode(500, "Internal server error");
                return await HandleException(ex);
            }
        }




    }
}