using DocumentManager.Infrastructure.InterfaceRepository;
using DocumentMicroservice.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
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

        // POST: api/Documents (create)
        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument(Document requestDoc) {
            // TODO: Обработка ошибок DocumentController.PostDocument()
            try {
                await repository.AddAsync(requestDoc);
                return StatusCode(201, requestDoc);
            }
            catch {
                var errorResponse = "PostDocument error";
                return StatusCode(500, errorResponse);
            }
        }

        // GET: api/Documents (read all)
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Document>>> GetDocuments() {
            // TODO: Обработка ошибок DocumentController.GetDocuments()
            try {
                var responseDocs = await repository.GetAllAsync();
                var action = new ActionResult<IReadOnlyList<Document>>(responseDocs);
                return action;
            }
            catch {
                var errorResponse = "GetDocuments error";
                return StatusCode(404, errorResponse);
            }
        }

        // GET: api/Documents/docId (read)
        [HttpGet("{docId:Guid}")]
        // TODO: Обработка ошибок DocumentController.GetDocument(Guid id)
        public async Task<ActionResult<Document>> GetDocument(Guid docId) {
            var document = await repository.GetByIdAsync(docId);
            if (document == null) {
                var errorResponse = $"Not found {docId}";
                return StatusCode(404, errorResponse);
            }
            return document;
        }

        // PUT: api/Documents/ (update)
        [HttpPut]
        public async Task<ActionResult<Document>> PutDocument(Document requestDoc) {
            // TODO: Обработка ошибок DocumentController.PutDocument(Guid id, Document document)
            try {
                // TODO: изменить номер ответа
                await repository.UpdateAsync(requestDoc);
                return StatusCode(201, requestDoc);
            }
            catch {
                var errorResponse = "Error Response";
                return StatusCode(500, errorResponse);
            }
        }

        // DELETE: api/Documents/docId (delete)
        [HttpDelete("{docId:Guid}")]
        public async Task<ActionResult<String>> DeleteDocument(Guid docId) {
            try {
                await repository.DeleteAsync(docId);
                return StatusCode(202).StatusCode.ToString();
            }
            catch {
                var errorResponce = "Error Response";
                return StatusCode(500, errorResponce);
            }
        }
    }
}
