using DocumentMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentManager.Infrastructure.InterfaceRepository
{
    public interface IDocumentRepository {
        public Task AddAsync(Document document);
        public Task<IReadOnlyList<Document>> GetAllAsync();
        public Task<Document> GetByIdAsync(Guid idDoc);
        public Task UpdateAsync(Document document);
        public Task DeleteAsync(Guid idDoc);
    }
}
