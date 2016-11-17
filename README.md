# DictionariesReadoutBenchmarks
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
