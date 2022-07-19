using DocumentManager.Infrastructure.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {

        private readonly IDocumentRepository repository;

        public DocumentsController(IDocumentRepository repository) {
            this.repository = repository;
        }

        // GET: api/Documents
        [HttpGet]
        public async void GetDocuments() {            
        }
    }
}
