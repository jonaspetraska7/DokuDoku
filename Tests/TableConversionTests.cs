using DokuDoku;
using DokuDoku.PDF;
using Newtonsoft.Json;

namespace Tests;

public class TableConversionTests
{
    [Theory]
    [InlineData("Json1")]
    [InlineData("Json2")]
    [InlineData("Json3")]
    [InlineData("Json4")]
    public void CanConvertToTable(string fileName)
    {
        string jsonString = File.ReadAllText(@$"..\..\..\TestData\{fileName}.txt");
        var myObject = JsonConvert.DeserializeObject(jsonString);
        Doku.PDF.Generate($"{fileName}", ".", x =>
        {
            x.ConvertToTable(myObject, "JsonTest");
        });
    }
}