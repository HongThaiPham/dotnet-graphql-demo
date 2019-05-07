using System.Linq;
using DotNetCoreGraphQL.Database;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreGraphQL.GraphQL
{
  public class AuthorQuery : ObjectGraphType
  {
    public AuthorQuery(ApplicationDbContext db)
    {
      Field<AuthorType>(
        "Author",
        arguments: new QueryArguments(
            new QueryArgument<IdGraphType>
            {
              Name = "id",
              Description = "The ID of the author."
            }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<int>("id");
          var author = db.Authors.Include(a => a.Books)
          .FirstOrDefault(i => i.Id == id);
          return author;
        }
      );

      Field<ListGraphType<AuthorType>>(
          "Authors",
          resolve: context =>
          {
            var authors = db.Authors.Include(a => a.Books);
            return authors;
          }
      );
    }
  }
}