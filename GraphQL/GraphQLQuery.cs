using Newtonsoft.Json.Linq;

namespace DotNetCoreGraphQL.GraphQL
{
  public class GraphQLQuery
  {
    public string OperationName { get; set; }
    public string NamedQuery { get; set; }
    public string Query { get; set; }
    public JObject Variables { get; set; }
  }
}