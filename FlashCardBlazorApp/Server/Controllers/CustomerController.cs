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
        [Route("get-progress")]
        public async Task<ActionResult<List<VocabProgress>>> GetCustomersVocabsProgress()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();
            else return Ok(user.VocabProgresses);
        }

        [HttpPost]
        [Route("update-progress")]
        public async Task<ActionResult> UpdateVocabsProgress([FromBody] List<VocabProgress> vocabProgresses)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();

            user.VocabProgresses.AddRange(vocabProgresses);

            return Ok();
        }

        [HttpGet]
        [Route("get-options")]
        public async Task<UserFlashCardOptions> GetCustomersOptions()
        {
            var userOptions = await _unitOfWork.UserOptionsRepository.Get(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            return userOptions;
        }

        [HttpPost]
        [Route("set-options")]
        public async Task<ActionResult> UpdateUserOptions([FromBody] UserFlashCardOptions userFlashCardOptions)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
            if (user == null) return NotFound();

            _unitOfWork.UserOptionsRepository.Update(userFlashCardOptions);
            _unitOfWork.Save();
         
            return Ok();
        }

        [HttpGet]
        [Route("get-vocabs/{wordsPerSession}")]
        public async Task<List<Vocab>> GetNewVocabs(int wordsPerSession)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var vocabs = await _unitOfWork.VocabRepository.Get(wordsPerSession, user.VocabProgresses);

            return vocabs;
        }
    }
}
