using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentMicroservice.Domain {
    public class Document {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
