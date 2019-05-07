using GraphQL.Types;
using DotNetCoreGraphQL.Database;

namespace DotNetCoreGraphQL.GraphQL
{
  public class BookType : ObjectGraphType<Book>
  {

    public BookType()
    {
      Name = "Book";

      Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the book");
      Field(x => x.Name).Description("The name of the book");
      Field(x => x.Genre).Description("Book Genre");
      Field(x => x.Published).Description("If the book is published or not");
    }

  }
}