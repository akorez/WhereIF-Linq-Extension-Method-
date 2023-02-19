using EfCore.ExtensionMethod;

var context = new AppDbContext();

string nameFilter = "testName";
string descriptionFilter = "testDescription";

var products = context.Products
    .WhereIf(!string.IsNullOrEmpty(nameFilter), p => p.Name.Contains(nameFilter))
    .WhereIf(!string.IsNullOrEmpty(descriptionFilter), p => p.Name.Contains(descriptionFilter)).ToList();

Console.ReadLine();