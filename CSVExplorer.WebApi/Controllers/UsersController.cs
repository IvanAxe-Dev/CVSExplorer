using AutoMapper;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.DTOs;
using CSVExplorer.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace CSVExplorer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("import-csv")]
        public async Task<IActionResult> ImportCSVFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            var users = new List<UserDto>();
            var validationResults = new List<ValidationResult>();

            while (await csv.ReadAsync())
            {
                try
                {
                    var user = csv.GetRecord<UserDto>();

                    var context = new ValidationContext(user, serviceProvider: null, items: null);
                    var results = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(user, context, results, true))
                    {
                        validationResults.AddRange(results);
                        return BadRequest(new { Errors = validationResults });
                    }

                    users.Add(user);
                }
                catch (Exception e)
                {
                    return BadRequest($"Invalid data: \n{e.Message}");
                }
            }

            await _userService.InsertRangeAsync(users);

            return Ok("User date from CSV file processed successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDto>>> GetAll()
        {
            List<User> users = await _userService.GetAllAsync();

            return Ok(_mapper.Map<List<UserResponseDto>>(users));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserResponseDto>> GetById(Guid id)
        {
            User? user = await _userService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResponse = _mapper.Map<UserResponseDto>(user);

            return Ok(userResponse);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _mapper.Map<User>(userDto);

            User newUser = await _userService.Insert(user);

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, _mapper.Map<UserResponseDto>(newUser));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserResponseDto>> Update(Guid id, UserDto userDto)
        {
            User? existingUser = await _userService.FindByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            User user = _mapper.Map(userDto, existingUser);

            return Ok(_mapper.Map<UserResponseDto>(await _userService.Update(user)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            User? session = await _userService.FindByIdAsync(id);

            if (session == null)
            {
                return NotFound();
            }
                
            await _userService.DeleteAsync(session);
            return NoContent();
        }
    }
}
