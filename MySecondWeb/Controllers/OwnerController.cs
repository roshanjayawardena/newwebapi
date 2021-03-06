﻿using ApplicationCore.Interfaces;
using Infastructure.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace MySecondWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : BaseApiController
    {
        private ILoggerManager _logger;     
        private IOwnerService _ownerService;

        public OwnerController(ILoggerManager logger, IOwnerService ownerService)
        {
            _logger = logger;          
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            try
            {
                var owners = await _ownerService.GetAllOwners();
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

        //[HttpGet]
        //public async Task<IActionResult> GetAllOwnersAsync()
        //{
        //    try
        //    {
        //        var owners = _repository.Owner.GetAllOwners();
        //        _logger.LogInfo($"Returned all owners from database.");
        //        return Ok(owners);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
        //        // return StatusCode(500, "Internal server error");
        //        return await HandleException(ex);
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOwnerByIdAsync(Guid id)
        //{
        //    try
        //    {
        //        var owner = _repository.Owner.GetOwnerById(id);

        //        if (owner.Id.Equals(Guid.Empty))
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Returned owner with id: {id}");
        //            return Ok(owner);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
        //        // return StatusCode(500, "Internal server error");
        //        return await HandleException(ex);
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(int id)
        {
            try
            {
                var owner = await _ownerService.GetOwnerById(id);

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


        //[HttpGet("{id}/account")]
        //public async Task<IActionResult> GetOwnerWithDetailsAsync(Guid id)
        //{
        //    try
        //    {
        //        var owner = _repository.Owner.GetOwnerWithDetails(id);

        //        if (owner.IsEmptyObject())
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Returned owner with details for id: {id}");
        //            return Ok(owner);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
        //        // return StatusCode(500, "Internal server error");
        //        return await HandleException(ex);
        //    }
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreateOwnerAsync([FromBody]Owner owner)
        //{
        //    try
        //    {
        //        if (owner.IsObjectNull())
        //        {
        //            _logger.LogError("Owner object sent from client is null.");
        //            return BadRequest("Owner object is null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogError("Invalid owner object sent from client.");
        //            return BadRequest("Invalid model object");
        //        }

        //        _repository.Owner.CreateOwner(owner);
        //        _repository.Save();

        //        return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
        //        // return StatusCode(500, "Internal server error");
        //        return await HandleException(ex);
        //    }
        //}




    }
}