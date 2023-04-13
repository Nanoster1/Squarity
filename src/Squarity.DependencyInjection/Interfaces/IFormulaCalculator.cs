namespace Squarity.DependencyInjection.Interfaces;

/// <summary>
/// Интерфейс сервиса для выполнения формул
/// </summary>
public interface IFormulaCalculator
{
    /// <summary>
    /// Высчитать результат формулы
    /// </summary>
    /// <param name="formula">Формула</param>
    /// <typeparam name="TResult">Тип результата</typeparam>
    TResult Calculate<TResult>(IFormula<TResult> formula);
}
