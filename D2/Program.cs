// See https://aka.ms/new-console-template for more information


using D2;

ReportManager reportManager = new ReportManager("real_inputs.txt");


Console.WriteLine(reportManager.CalculateValidReports());
Console.WriteLine(reportManager.CalculateValidReportsWithProblemDampener());


