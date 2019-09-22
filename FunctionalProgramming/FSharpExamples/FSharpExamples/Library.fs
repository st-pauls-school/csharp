namespace FSharpExamples


module public Years = 
    let leapYear x =
        if x % 400 = 0 then 
            true
        else if x % 100 = 0 then 
            false
        else
            x % 4 = 0

