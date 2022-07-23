using DocumentManager.Infrastructure.InterfaceRepository;
using DocumentMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMicroservice.Infrastructure {
    public class DocumentRepository : IDocumentRepository {

        private readonly DocDataContext context;

        public DocumentRepository(DocDataContext context) {
            this.context = context;
        }

        public async Task AddAsync(Document document) {
            Document tmp = await context.Documents.FindAsync(document.Id);
            if (tmp != null)
                throw new Exception("this object exists");
            await context.Documents.AddAsync(document);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Document>> GetAllAsync() {
            return await context.Documents.ToListAsync();
        }

        public async Task<Document> GetByIdAsync(Guid idDoc) {
            var document = await context.Documents.Where(docProp => docProp.Id == idDoc)
                .FirstOrDefaultAsync();
            return document;
        }

        public async Task UpdateAsync(Document document) {
            context.Documents.Update(document);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid idDoc) {
            Document doc = await context.Documents.FindAsync(idDoc);
            context.Documents.Remove(doc);
            await context.SaveChangesAsync();
        }
    }
}
