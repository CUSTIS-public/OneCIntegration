using System.Linq.Expressions;

namespace OneCIntegration.Utils;

public static class ReflectionHelpers
{
    private static MemberExpression GetMemberExpression(Expression expression, bool throwEx)
    {
        if (expression is MemberExpression memberExpr) return memberExpr;
        else if (expression is UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MemberExpression memberExprUnary) return memberExprUnary;
        }
        if (throwEx) throw new InvalidOperationException("Expression must be a member expression.");
        return null;
    }

    public static IEnumerable<string> GetMembers<T>(Expression<Func<T, object>> expression)
    {
        var memberExpr = GetMemberExpression(expression.Body, true);
        var memberNames = new List<string>();
        while (memberExpr != null)
        {
            var member = memberExpr.Member;
            var name = member.Name;
            memberNames.Add(name);
            var nextExpr = GetMemberExpression(memberExpr.Expression, false);
            if (nextExpr != null) memberExpr = nextExpr;
            else break;
        }
        memberNames.Reverse();
        return memberNames;
    }
}