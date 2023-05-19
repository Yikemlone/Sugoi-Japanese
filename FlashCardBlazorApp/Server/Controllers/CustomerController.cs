using FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Security.Claims;

namespace FlashCardBlazorApp.Server.Controllers
{
    [Authorize(Policy = "IsCustomer")]
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<VocabProgress>>> GetCustomersVocabs()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();
            else return Ok(user.VocabProgresses);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> UpdateVocabs([FromBody] List<VocabProgress> vocabProgresses)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();

            user.VocabProgresses.AddRange(vocabProgresses);

            return Ok();
        }

        [HttpGet]
        [Route("get-options")]
        public async Task<ActionResult<UserFlashCardOptions>> GetCustomersOptions()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();
            return Ok(user.UserFlashCardOptions);
            //return Ok(new UserFlashCardOptions());
        }

        [HttpPost]
        [Route("set-options")]
        public async Task<ActionResult> UpdateUserOptions([FromBody] UserFlashCardOptions userFlashCardOptions)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();

            _unitOfWork.UserOptionsRepository.Add(userFlashCardOptions);
            _unitOfWork.Save();

            user.UserFlashCardOptions.ID = userFlashCardOptions.ID;

            return Ok();
        }
    }
}
