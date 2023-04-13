using Squarity.DependencyInjection.Interfaces;

namespace Squarity.DependencyInjection.Services;

/// <summary>
/// Стандартная реализация <see cref="IFormulaCalculator" />
/// </summary>
public class DefaultFormulaCalculator : IFormulaCalculator
{
    public virtual TResult Calculate<TResult>(IFormula<TResult> formula)
    {
        ArgumentNullException.ThrowIfNull(formula);
        return formula.Calculate();
    }
}
