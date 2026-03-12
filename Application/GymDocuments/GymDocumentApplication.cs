using Application.GymDocuments.Dto;
using Data.GymDocuments;
using Data.Services;
using Domain;

namespace Application.GymDocuments
{
    public class GymDocumentApplication : IGymDocumentApplication
    {
        private readonly IGymDocumentRepository _gymDocumentRepository;
        private readonly IFileService _fileService;

        public GymDocumentApplication(
            IGymDocumentRepository gymDocumentRepository,
            IFileService fileService)
        {
            _gymDocumentRepository = gymDocumentRepository;
            _fileService = fileService;
        }

        public async Task<string> Create(CreateGymDocumentDto dto)
        {
            if (dto.ImageUrl == null || !dto.ImageUrl.Any())
                return "No files uploaded";

            foreach (var file in dto.ImageUrl)
            {
                var path = await _fileService.UploadImage(file, "gym-documents");

                var document = new GymDocument
                {
                    GymId = dto.GymId,
                    ImageUrl = path
                };

                await _gymDocumentRepository.Create(document);
            }

            return "Gym Documents Uploaded";
        }

        public async Task Update(int id, CreateGymDocumentDto dto)
        {
            var existingDocument = await _gymDocumentRepository.GetById(id);
            if (existingDocument == null)
                throw new Exception("Gym Document not found");

            if (dto.ImageUrl != null && dto.ImageUrl.Any())
            {
                var path = await _fileService.UploadImage(dto.ImageUrl.First(), "gym-documents");
                existingDocument.ImageUrl = path;
            }

            existingDocument.GymId = dto.GymId;

            await _gymDocumentRepository.Update(existingDocument);
        }

        public async Task Delete(int id)
        {
            await _gymDocumentRepository.Delete(id);
        }

        public async Task<List<GymDocumentDto>> GetAll()
        {
            var documents = await _gymDocumentRepository.GetAll();

            return documents.Select(d => new GymDocumentDto
            {
                Id = d.Id,
                GymId = d.GymId,
                ImageUrl = d.ImageUrl
            }).ToList();
        }

        public async Task<GymDocumentDto> GetById(int id)
        {
            var document = await _gymDocumentRepository.GetById(id);
            if (document == null) return null;

            return new GymDocumentDto
            {
                Id = document.Id,
                GymId = document.GymId,
                ImageUrl = document.ImageUrl
            };
        }
    }
}