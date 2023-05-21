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
            var userVocabs = await _unitOfWork.VocabProgressRepository.GetAll(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (userVocabs == null) return NotFound();
            else return Ok(userVocabs);
        }

        [HttpPost]
        [Route("add-progress")]
        public async Task<ActionResult> AddVocabsProgress([FromBody] List<VocabProgress> vocabProgresses)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return NotFound();

            user.VocabProgresses.AddRange(vocabProgresses);
            _unitOfWork.Save();

            return Ok();
        }

        // TODO
        [HttpPost]
        [Route("update-progress")]
        public async Task<ActionResult> UpdateVocabsProgress([FromBody] List<VocabProgress> vocabProgresses)
        {
            //var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //if (user == null) return NotFound();

            //user.VocabProgresses.AddRange(vocabProgresses);

            //return Ok();

            throw new NotImplementedException();
        }

        // TODO
        [HttpGet]
        [Route("get-progress/{rating}")]
        public async Task<ActionResult<List<VocabProgress>>> GetCustomersVocabsProgressWithRating(int rating)
        {
            var userVocabs = await _unitOfWork.VocabProgressRepository.GetAll(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (userVocabs == null) return NotFound();
            else return Ok(userVocabs);
        }


        [HttpGet]
        [Route("get-options")]
        public async Task<ActionResult<UserFlashCardOptions>> GetCustomersOptions()
        {
            var userOptions = await _unitOfWork.UserOptionsRepository.Get(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (userOptions == null) return NotFound();
            return Ok(userOptions);
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
        [Route("get-vocabs/{userID}")]
        public async Task<ActionResult<List<Vocab>>> GetNewVocabs(string userID)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userOptions = await _unitOfWork.UserOptionsRepository.Get(new Guid(userID));

            var vocabs = await _unitOfWork.VocabRepository.Get(userOptions, user.VocabProgresses);

            if (vocabs == null) return NotFound();
            return Ok(vocabs);
        }
    }
}
