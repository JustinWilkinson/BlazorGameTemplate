using BlazorGameTemplate.Server.Extensions;
using Xunit;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BlazorGameTemplate.Test.Server.Extensions
{
    public class JsonExtensionsTests
    {

        private static readonly TestSerializerClass _testObject = new() { IntValue = 1, StringValue = "Value", BooleanValue = true, camelCaseStringValue = "value", camelCaseBooleanValue = false };
        private static readonly JsonElement _objectJsonElement = JsonDocument.Parse(JsonSerializer.Serialize(_testObject)).RootElement;

        private static readonly TestWithObjectProperty _testWithObjectProperty = new() { ObjectProperty = _testObject, camelCaseObjectProperty = _testObject };
        private static readonly JsonElement _testWithObjectPropertyJsonElement = JsonDocument.Parse(JsonSerializer.Serialize(_testWithObjectProperty)).RootElement;

        [Fact]
        public void GetStringProperty_ValidJsonElementObjectPascalCase_ExtractsStringPropertySuccessfully()
        {
            Assert.Equal("Value", _objectJsonElement.GetStringProperty("StringValue"));
        }

        [Fact]
        public void GetStringProperty_ValidJsonElementObjectCamelCase_ExtractsStringPropertySuccessfully()
        {
            Assert.Equal("value", _objectJsonElement.GetStringProperty("camelCaseStringValue"));
            Assert.Equal("value", _objectJsonElement.GetStringProperty("CamelCaseStringValue"));
        }

        [Fact]
        public void GetObjectProperty_ValidJsonElementObjectPascalCase_ExtractsObjectPropertySuccessfully()
        {
            var result = _testWithObjectPropertyJsonElement.GetObjectProperty<TestSerializerClass>("ObjectProperty");
            Assert.IsType<TestSerializerClass>(result);
            Assert.Equal(_testObject, result);
        }

        [Fact]
        public void GetObjectProperty_ValidJsonElementObjectCamelCase_ExtractsObjectPropertySuccessfully()
        {
            var result1 = _testWithObjectPropertyJsonElement.GetObjectProperty<TestSerializerClass>("camelCaseObjectProperty");
            var result2 = _testWithObjectPropertyJsonElement.GetObjectProperty<TestSerializerClass>("CamelCaseObjectProperty");

            Assert.IsType<TestSerializerClass>(result1);
            Assert.Equal(_testObject, result1);
            Assert.IsType<TestSerializerClass>(result2);
            Assert.Equal(_testObject, result2);
        }

        [Fact]
        public void GetBooleanProperty_ValidJsonElementObjectPascalCase_ExtractsBooleanPropertySuccessfully() 
            => Assert.True(_objectJsonElement.GetBooleanProperty("BooleanValue"));

        [Fact]
        public void GetBooleanProperty_ValidJsonElementObjectCamelCase_ExtractsBooleanPropertySuccessfully()
        {
            Assert.False(_objectJsonElement.GetBooleanProperty("camelCaseBooleanValue"));
            Assert.False(_objectJsonElement.GetBooleanProperty("CamelCaseBooleanValue"));
        }

        private record TestSerializerClass
        {
            public int IntValue { get; init; }

            public string StringValue { get; init; }

            public bool BooleanValue { get; init; }

            public bool camelCaseBooleanValue { get; init; }

            public string camelCaseStringValue { get; init; }
        }

        private record TestWithObjectProperty
        {
            public object ObjectProperty { get; init; }

            public object camelCaseObjectProperty { get; init; }
        }
    }
}