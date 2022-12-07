using ConsoleTables;
using CrossTable;
using CrossTableTester;

CrossTableService<TableHeader, TableIndex, TableContent> crossTableService = new();

crossTableService.SetHeaderOrderFunc(x => x.Index);
crossTableService.SetIndexOrderFunc(x => x.Index);

List<TableIndex> tableIndexes = new();
List<TableHeader> tableHeaders = new();

for (int index = 1; index <= 1000; index++)
{
    tableIndexes.Add(new($"Index - {index}", index));
}

for (int header = 1; header <= 8; header++)
{
    tableHeaders.Add(new($"Header - {header}", header));
}

foreach (var tableIndex in tableIndexes)
{
    foreach (var tableHeader in tableHeaders)
    {
        TableContent tableContent = new($"Content - Index {tableIndex.Index} - Header {tableHeader.Index}", tableIndex.Index, tableHeader.Index);
        crossTableService.AddContent(new(tableHeader, tableIndex, tableContent));
    }
}

var headerArray = crossTableService.GetHeader().Select(x => x.Name).ToArray();
var table = new ConsoleTable(headerArray);

foreach (var row in crossTableService.GetRows())
{
    var rowArray = row.Select(x => x.Content.Content).ToArray();
    table.AddRow(rowArray);
}

table.Write();

Console.ReadKey();