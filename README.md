# DictionariesReadoutBenchmarks

We use a simple class to compare reference type (Cat) vs struct type (int)
```C#
    class Cat
    {
        public int TailLength { get; set; }
    }
```

```C#   
    var dictStrInt = new Dictionary<string, int> { { "One", 1}, {"Two", 2}, {"Three",3}};
            var dictLongStrInt = new Dictionary<string, int> { { "TheLongLongSameStringOne", 1 }, { "TheLongLongSameStringTwo", 2 }, { "TheLongLongSameStringThree", 3 } };
            var dictStrCat = new Dictionary<string, Cat> { { "One", new Cat {TailLength = 1} }, { "Two", new Cat { TailLength = 2 } }, { "Three", new Cat { TailLength = 3 } } };
            var dictIntInt = new Dictionary<int, int> { { 0, 1 }, { 1, 2 }, { 2, 3 } };
            var dictIntCat = new Dictionary<int, Cat> { { 0, new Cat { TailLength = 1 } }, { 1, new Cat { TailLength = 2 } }, { 2, new Cat { TailLength = 3 } } };
            var listInt = new List<int> {1, 2, 3};
            var listCat = new List<Cat> { new Cat { TailLength = 1 } , new Cat { TailLength = 2 }, new Cat { TailLength = 3 } };
```


Run 1000000 times of random pick

A small and simple benchmark to compare readout time for .NET standard dictionaries

    Name      | Average time [ms] | Min time [ms] | Max time [ms]
    ----------|------------|------------|---------
    dictStrInt| 20.68  |  19.4  | 24.4
dictLongStrInt| 26.42  |  25.5  | 29.2
    dictStrCat| 21.85  |  20.9  | 27.3
    dictIntInt|  9.86  |   9.4  | 11.9
    dictIntCat| 12.49  |  11.2  | 21.1
       listInt|  1.36  |   1.3  |  1.5
 listInt(enum)|  1.48  |   1.4  |  1.5
       listCat|  3.50  |   3.4  |  3.7


The empty loop time:
```       
         empty| 16.33[ms]  |  16.1[ms]  | 16.9[ms]
```         
