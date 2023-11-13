#pragma warning disable

Enumerable.Range(1, Int16.MaxValue)
    .Select(static i => (Value: i, ValueRangeWidth: 200, Divisor: 202.5 * 2 * Math.PI, Amplitude: 15, Delay: 50))
    .Select(static t => { Thread.Sleep(t.Delay); return t; })
    .Select(static t => (t.Value, Inflection: (Int32)Math.Ceiling(t.ValueRangeWidth / 2d), ClampedValue: t.Value % t.ValueRangeWidth, t.Amplitude, Period: t.ValueRangeWidth / t.Divisor, t.ValueRangeWidth))
    .Select(static t => (
        PeriodicValue: t.ClampedValue > t.Inflection ? t.ValueRangeWidth - t.ClampedValue : t.ClampedValue,
        t.Value,
        t.Amplitude,
        t.Period))
    .Select(static t => (
        Output: t.PeriodicValue % 15 == 0 ? "FizzBuzz" :
                t.PeriodicValue % 3 == 0 ? "Fizz" :
                t.PeriodicValue % 5 == 0 ? "Buzz" :
                t.PeriodicValue.ToString(),
        CursorLeft: Console.WindowWidth / 2 + (Int32)(Math.Sin(t.Value * t.Period) * t.Amplitude),
        Color: (ConsoleColor)(t.PeriodicValue % 15 + 1)))
    .Select(static t => { Console.CursorLeft = t.CursorLeft; Console.ForegroundColor = t.Color; return t.Output; })
    .Select(static o => { Console.WriteLine(o); return 0; })
    .ToList();
