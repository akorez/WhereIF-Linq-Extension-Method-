# WhereIf

When building a LINQ query, you may need to involve optional filtering criteria. Avoids if statements when building predicates & lambdas for a query. WhereIf extension method is useful when you don't know at compile time whether a filter should apply.

## Source

```C# 
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition, Expression<Func<T,bool>> predicate)
        {
            if (condition)
            {
                return queryable.Where(predicate);
            }

            return queryable;
        }
    }
    
 ```
 
 ## Example
 
 ```C#
 var context = new AppDbContext();

string nameFilter = "testName";
string descriptionFilter = "testDescription";

var products = context.Products
    .WhereIf(!string.IsNullOrEmpty(nameFilter), p => p.Name.Contains(nameFilter))
    .WhereIf(!string.IsNullOrEmpty(descriptionFilter), p => p.Name.Contains(descriptionFilter)).ToList();

Console.ReadLine();
 ```
