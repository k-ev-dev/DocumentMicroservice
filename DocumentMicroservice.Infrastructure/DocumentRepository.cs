using DocumentManager.Infrastructure.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentMicroservice.Infrastructure {
    public class DocumentRepository : IDocumentRepository {

        private readonly DocDataContext context;

        public DocumentRepository(DocDataContext context) {
            this.context = context;
        }
    }
}
