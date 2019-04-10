namespace RomanNumerals

module RomanNumerals = 

    // Naiive arabic number -> roman numeral library
    let private arabicToRoman' arabic = 
           (String.replicate arabic "I")
            .Replace("IIIII","V")
            .Replace("VV","X")
            .Replace("XXXXX","L")
            .Replace("LL","C")
            .Replace("CCCCC","D")
            .Replace("DD","M")
            // optional substitutions
            .Replace("IIII","IV")
            .Replace("VIV","IX")
            .Replace("XXXX","XL")
            .Replace("LXL","XC")
            .Replace("CCCC","CD")
            .Replace("DCD","CM")
 
    let arabicToRoman arabic = 
       if arabic < 0 || arabic > 4000 
       then failwith "Number out of range"
       else arabicToRoman' arabic