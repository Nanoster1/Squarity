# Squarity
(Рабочее название)\
Библиотека, предоставляющая API для работы с фигурами и формулами, а также базовые реализации некоторых фигур

## Core
---
> ### `IFigure2D`
> ---
> Чтобы сделать из класса 2D фигуру - достаточно реализовать этот интерфейс. *(В рамках задания интерфейс ограничен только площадью)*
> ### Базовые фигуры
> 1. ### `Circle` - Круг
> 2. ### `Triangle` - Треугольник

## Dependency Injection
---
> ### `IFigureCalculator`
> Чтобы внедрить работу с фигурами в виде сервиса - можно зарегистрировать в контейнере сервис `IFigureCalculator`.\
> *(Для сервиса по умолчанию можно воспользоваться методом `AddDefaultFigureCalculator`)*
> 
> ### `IFormulaCalculator`
> Есть также альтернативный способ указать формулы для фигур - создать класс, реализующий `IFormula`.\
> Также необходимо зарегистрировать сервис `IFormulaCalculator`.\
> *(Для сервиса по умолчанию можно воспользоваться методом `AddDefaultFormulaCalculator`)*\
> \
> Пример реализации площади круга:
> ```c#
> public class CircleAreaFormula : IFormula<double>
> {
>    private readonly Circle _circle;
>
>    public CircleAreaFormula(Circle circle)
>    {
>        _circle = circle;
>    }
>
>    public double Calculate()
>    {
>        return _circle.CalculateArea();
>    }
>}
> ```
> Пример использования в коде:
> ```c#
>public class ExampleService
>{
>    private readonly IFormulaCalculator _formulaCalculator;
>
>    public ExampleService(IFormulaCalculator formulaCalculator)
>    {
>        _formulaCalculator = formulaCalculator;
>    }
>
>    public void SomeMethod()
>    {
>        var circle = new Circle(5);
>        var formula = new CircleAreaFormula(circle);
>        var result = _formulaCalculator.Calculate(formula);
>        // Some code here...
>    }
>}
> ```

> **SQL Задание в папке Sql**