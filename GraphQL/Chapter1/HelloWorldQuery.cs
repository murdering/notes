using GraphQL.Types;

namespace GraphQL.Samples.Chapter1
{
    public class HelloWorldQuery : ObjectGraphType
    {
        public HelloWorldQuery()
        {
            Field<StringGraphType>(
                name: "hello",
                resolve: context => "world!"
            );
            Field<StringGraphType>(
                name: "leo",
                resolve: context => "handsome!"
            );
        }
    }
}
