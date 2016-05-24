using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestful.Models;

namespace WorkflowRestfulTests
{
    class TestSectionDbSet : TestDbSet<Section>
    {
        public override Section Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
       
    }

    class TestSubsectionDbSet : TestDbSet<Subsection>
    {
        public override Subsection Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }

    class TestDocumentDbSet : TestDbSet<Document>
    {
        public override Document Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }

    class TestRevisionDbSet : TestDbSet<Revision>
    {
        public override Revision Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.RevisionNumber == (int)keyValues.Single());
        }
    }

    class TestSectionRevisionDbSet : TestDbSet<SectionRevision>
    {
        public override SectionRevision Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }

    class TestSubsectionRevisionDbSet : TestDbSet<SubsectionRevision>
    {
        public override SubsectionRevision Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }

    class TestTemplateDbSet : TestDbSet<Template>
    {
        public override Template Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }

    class TestFontDbSet : TestDbSet<Font>
    {
        public override Font Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.FontId == (int)keyValues.Single());
        }
    }
}
