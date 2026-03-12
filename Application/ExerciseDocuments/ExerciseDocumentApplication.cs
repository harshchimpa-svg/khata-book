using Application.ExerciseDocuments.Dto;
using Data.ExerciseDocuments;
using Data.Services; 
using Domain;

namespace Application.ExerciseDocuments
{
    public class ExerciseDocumentApplication : IExerciseDocumentApplication
    {
        private readonly IExerciseDocumentRepository _exerciseDocumentRepository;
        private readonly IFileService _fileService;

        public ExerciseDocumentApplication(
            IExerciseDocumentRepository exerciseDocumentRepository, 
            IFileService fileService)
        {
            _exerciseDocumentRepository = exerciseDocumentRepository;
            _fileService = fileService;
        }

        public async Task<string> Create(CreateExerciseDocumentDto dto)
        {
            if (dto.Document == null || !dto.Document.Any())
                return "No files uploaded";

            foreach (var file in dto.Document)
            {
                var path = await _fileService.UploadImage(file, "exercise-documents");

                var document = new ExerciseDocument
                {
                    ExerciseId = dto.ExerciseId,
                    Document = path
                };

                await _exerciseDocumentRepository.Create(document);
            }

            return "Exercise Documents Uploaded";
        }

        public async Task Update(int id, CreateExerciseDocumentDto dto)
        {
            var existingDocument = await _exerciseDocumentRepository.GetById(id);
            if (existingDocument == null)
                throw new Exception("Exercise Document not found");

            if (dto.Document != null && dto.Document.Any())
            {
                var path = await _fileService.UploadImage(dto.Document.First(), "exercise-documents");
                existingDocument.Document = path;
            }

            existingDocument.ExerciseId = dto.ExerciseId;

            await _exerciseDocumentRepository.Update(existingDocument);
        }

        public async Task Delete(int id)
        {
            await _exerciseDocumentRepository.Delete(id);
        }

        public async Task<List<ExerciseDocumentDto>> GetAll()
        {
            var documents = await _exerciseDocumentRepository.GetAll();
            return documents.Select(d => new ExerciseDocumentDto
            {
                Id = d.Id,
                ExerciseId = d.ExerciseId,
                Document = d.Document
            }).ToList();
        }

        public async Task<ExerciseDocumentDto> GetById(int id)
        {
            var document = await _exerciseDocumentRepository.GetById(id);
            if (document == null) return null;

            return new ExerciseDocumentDto
            {
                Id = document.Id,
                ExerciseId = document.ExerciseId,
                Document = document.Document
            };
        }
    }
}