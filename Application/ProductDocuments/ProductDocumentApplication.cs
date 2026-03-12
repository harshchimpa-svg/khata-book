using Application.ProductDocuments.Dto;
using Data.ProductDocuments;
using Data.Services;
using Domain;

namespace Application.ProductDocuments
{
    public class ProductDocumentApplication : IProductDocumentApplication
    {
        private readonly IProductDocumentRepository _productDocumentRepository;
        private readonly IFileService _fileService;

        public ProductDocumentApplication(
            IProductDocumentRepository productDocumentRepository,
            IFileService fileService)
        {
            _productDocumentRepository = productDocumentRepository;
            _fileService = fileService;
        }

        public async Task<string> Create(CreateProductDocumentDto dto)
        {
            if (dto.ImageUrl == null || !dto.ImageUrl.Any())
                return "No files uploaded";

            foreach (var file in dto.ImageUrl)
            {
                var path = await _fileService.UploadImage(file, "product-documents");

                var document = new ProductDocument
                {
                    GymProductId = dto.GymProductId,
                    ImageUrl = path
                };

                await _productDocumentRepository.Create(document);
            }

            return "Product Documents Uploaded";
        }

        public async Task Update(int id, CreateProductDocumentDto dto)
        {
            var existingDocument = await _productDocumentRepository.GetById(id);

            if (existingDocument == null)
                throw new Exception("Product Document not found");

            if (dto.ImageUrl != null && dto.ImageUrl.Any())
            {
                var path = await _fileService.UploadImage(dto.ImageUrl.First(), "product-documents");
                existingDocument.ImageUrl = path;
            }

            existingDocument.GymProductId = dto.GymProductId;

            await _productDocumentRepository.Update(existingDocument);
        }

        public async Task Delete(int id)
        {
            await _productDocumentRepository.Delete(id);
        }

        public async Task<List<ProductDocumentDto>> GetAll()
        {
            var documents = await _productDocumentRepository.GetAll();

            return documents.Select(d => new ProductDocumentDto
            {
                Id = d.Id,
                GymProductId = d.GymProductId,
                ImageUrl = d.ImageUrl
            }).ToList();
        }

        public async Task<ProductDocumentDto> GetById(int id)
        {
            var document = await _productDocumentRepository.GetById(id);

            if (document == null)
                return null;

            return new ProductDocumentDto
            {
                Id = document.Id,
                GymProductId = document.GymProductId,
                ImageUrl = document.ImageUrl
            };
        }
    }
}