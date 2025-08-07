using OneCIntegration.Console;

var enterpriseDataExamples = new EnterpriseDataExamples();
await enterpriseDataExamples.GetDataWithСonfirmation();
//await examples.TestGetAndPutData();

var oDataExamples = new ODataExamples();
await oDataExamples.GetData();