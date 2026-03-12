using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Application.DietDocuments.Dto
{
    public class CreateDietDocumentDto
    {
        public int? DietId { get; set; }
        public List<IFormFile> Document { get; set; }
    }
}