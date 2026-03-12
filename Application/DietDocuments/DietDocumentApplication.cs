using Application.DietDocuments.Dto;
using Data.DiteDocuments; 
using Data.Services;       
using Domain;

namespace Application.DietDocuments
{
    public class DietDocumentApplication : IDietDocumentApplication
    {
        private readonly IDietDocumentRepository _dietDocumentRepository;
        private readonly IFileService _fileService;

        public DietDocumentApplication(IDietDocumentRepository dietDocumentRepository, IFileService fileService)
        {
            _dietDocumentRepository = dietDocumentRepository;
            _fileService = fileService;
        }

        public async Task<string> Create(CreateDietDocumentDto dto)
        {
            if (dto.Document == null || !dto.Document.Any())
                return "No files uploaded";

            foreach (var file in dto.Document)
            {
                var path = await _fileService.UploadImage(file, "diet-documents");

                var document = new DietDocument
                {
                    DietId = dto.DietId,
                    Document = path
                };

                await _dietDocumentRepository.Create(document);
            }

            return "Diet Documents Uploaded";
        }

        public async Task Update(int id, CreateDietDocumentDto dto)
        {
            var existingDocument = await _dietDocumentRepository.GetById(id);
            if (existingDocument == null) throw new Exception("Diet Document not found");

            if (dto.Document != null && dto.Document.Any())
            {
                var path = await _fileService.UploadImage(dto.Document.First(), "diet-documents"); 
                existingDocument.Document = path;
            }

            existingDocument.DietId = dto.DietId;

            await _dietDocumentRepository.Update(existingDocument);
        }

        public async Task Delete(int id)
        {
            await _dietDocumentRepository.Delete(id);
        }

        public async Task<List<DietDocumentDto>> GetAll()
        {
            var documents = await _dietDocumentRepository.GetAll();
            return documents.Select(d => new DietDocumentDto
            {
                Id = d.Id,
                DietId = d.DietId,
                Document = d.Document
            }).ToList();
        }

        public async Task<DietDocumentDto> GetById(int id)
        {
            var document = await _dietDocumentRepository.GetById(id);
            if (document == null) return null;

            return new DietDocumentDto
            {
                Id = document.Id,
                DietId = document.DietId,
                Document = document.Document
            };
        }
    }
}