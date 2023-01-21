using RefleCS.TestKit.Nodes;

namespace RefleCS.Tests.Nodes;

public class RecordTests
{
    public class AddParameter
    {
        public AddParameter()
        {
        }

        private class AddParameterFixture
        {
            private readonly RecordBuilder _builder;

            public AddParameterFixture()
            {
                _builder = new RecordBuilder();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}