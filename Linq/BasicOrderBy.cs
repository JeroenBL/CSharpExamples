var coWorkers = new[]
{
    new { Type = "Developer", Name = "Jeroen"},
    new { Type = "Developer", Name = "John"},
    new { Type = "AccountManager", Name = "Jane"},
};

var developers =
    from c in coWorkers
    where c.Type == "Developer"
    orderby c.Name ascending
    select c;

foreach (var dev in developers)
{
    Console.WriteLine(dev.Name);
}

Console.Read();
