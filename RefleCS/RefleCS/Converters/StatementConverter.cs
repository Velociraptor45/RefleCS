using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class StatementConverter
{
    public Statement ToStatement(StatementSyntax statement)
    {
        return new Statement(statement.GetText().ToString().Trim());
    }

    public IEnumerable<Statement> ToStatement(IEnumerable<StatementSyntax> statements)
    {
        foreach (var statement in statements)
        {
            yield return ToStatement(statement);
        }
    }

    public StatementSyntax ToNode(Statement statement)
    {
        return SyntaxFactory.ParseStatement(statement.Value);
    }

    public IEnumerable<StatementSyntax> ToNode(IEnumerable<Statement> statements)
    {
        foreach (var statement in statements)
        {
            yield return ToNode(statement);
        }
    }
}