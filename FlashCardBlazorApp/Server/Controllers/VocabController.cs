using FlashCardBlazorApp.DataAccess.Services.UnitOfWorkService;
using FlashCardBlazorApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardBlazorApp.Server.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class VocabController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VocabController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("vocabs")]
        public async Task<List<Vocab>> GetVocabs() 
        { 
            return _unitOfWork.VocabRepository.GetAll().ToList();
        }

        [HttpPost]
        [Route("create")]
        public async Task AddVocab([FromBody] Vocab vocab)
        {
            _unitOfWork.VocabRepository.Add(vocab);
            _unitOfWork.Save();
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateVocab([FromBody] Vocab vocab)
        {
            _unitOfWork.VocabRepository.Update(vocab);
            _unitOfWork.Save();
        }

        [HttpPost]
        [Route("delete")]
        public async Task DeleteVocab([FromBody] Vocab vocab)
        {
            _unitOfWork.VocabRepository.Delete(vocab);
            _unitOfWork.Save();
        }
    }
}
