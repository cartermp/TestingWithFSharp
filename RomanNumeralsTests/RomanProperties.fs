module RomanNumeralProperties
    // Determines that instances of 'ch' appear a max of 'count' times
    let maxRepetitionProperty ch count (input:string) = 
        let find = String.replicate (count+1) ch
        input.Contains find |> not

    // A property that holds for all roman numerals
    let ``has max rep of one V`` roman = 
        maxRepetitionProperty "V" 1 roman 

    // A property that holds for all roman numerals
    let ``has max rep of three Xs`` roman = 
        maxRepetitionProperty "X" 3 roman 