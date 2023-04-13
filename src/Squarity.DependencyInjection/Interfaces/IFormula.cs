namespace Squarity.DependencyInjection.Interfaces;

/// <summary>
/// </summary>
/// <typeparam name="TResult">
/// 
/// </typeparam>
public interface IFormula<TResult>
{
    public TResult Calculate();
}
