#pragma warning disable

Enumerable.Range(0, Int32.MaxValue)
    .Select(i => (Value: i, Width: 1000))
    .Select(t => (t.Width, Range: Enumerable.Range(1, t.Width / 2).Concat(Enumerable.Range(1, (t.Width / 2) - 2).Select(v => (t.Width / 2) - v)).ToArray(), t.Value))
    .Select(t => t.Range[t.Value % (t.Width - 2)])
    .Select(static v => v % 15 == 0 ? "FizzBuzz" : v % 3 == 0 ? "Fizz" : v % 5 == 0 ? "Buzz" : v.ToString())
    .Select(static o => (Output: o, Amplitude: 20, Period: 0.1d))
    .Select(static (t, i) => (t.Amplitude, t.Output, Sine: Console.WindowWidth / 2 + (Int32)(Math.Sin(t.Period * i) * t.Amplitude)))
    .Select(static (t, i) => (t.Output, t.Sine, Color: (ConsoleColor)(i / 3 % 15 + 1)))
    .Select(static t => { Console.ForegroundColor = t.Color; return t; })
    .Select(static t => { Console.CursorLeft = t.Sine; return t; })
    .Select(static t => (t.Sine, Delay: 75, t.Output))
    .Select(static t => { Thread.Sleep(t.Delay); return t.Output; })
    .Select(static o => { Console.WriteLine(o); return 0; })
    .ToArray();
